using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Tema3.Commands;
using Tema3.MVVM.Model.BusinessLogicLayer;
using Tema3.MVVM.Model.EntityLayer;

namespace Tema3.MVVM.ViewModel
{
    class MeansProfessorVM : BaseNotification
    {
        public MeansProfessorVM()
        {
            Subjects = SubjectBLL.GetSubjectsAndFinalExamAtProfessor(ProfessorVM.Professor.ProfessorID);
            Pupils = new ObservableCollection<Tuple<Pupil, decimal?, bool?>>();
        }

        private bool FindSubjectHasFinalExam(int? id)
        {
            foreach (Tuple<bool?, Subject> s in Subjects)
            {
                if (s.Item2.SubjectID == id)
                    return s.Item1 ?? default;
            }
            return false;
        }

        private void SetPupils()
        {
            ObservableCollection<Pupil> ps = PupilBLL.GetPupilsAtSubject(SubjectIDSelected);
            Pupils = new ObservableCollection<Tuple<Pupil, decimal?, bool?>>();
            foreach (Pupil p in ps)
            {
                Pupils.Add(new Tuple<Pupil, decimal?, bool?>(p, MeansBLL.GetPupilMeanAtSubject(
                    p.PupilID, SubjectIDSelected, FindSubjectHasFinalExam(SubjectIDSelected)),
                    SubjectPupilBLL.GetCalculatedMean(p.PupilID, SubjectIDSelected)));
            }
        }

        private ObservableCollection<Tuple<bool?, Subject>> subjects;
        public ObservableCollection<Tuple<bool?, Subject>> Subjects
        {
            get
            {
                return subjects;
            }
            set
            {
                subjects = value;
                NotifyPropertyChanged("Subjects");
            }
        }
        public ObservableCollection<Tuple<int?, string>> SubjectsList
        {
            get
            {
                ObservableCollection<Tuple<int?, string>> list = new ObservableCollection<Tuple<int?, string>>();
                foreach (Tuple<bool?, Subject> t in Subjects)
                {
                    list.Add(new Tuple<int?, string>(t.Item2.SubjectID,
                        t.Item2.SubjectName + " - An: " + t.Item2.Year +
                        " - Sem: " + t.Item2.Semester + " - Cu teza: " +
                        (t.Item1 ?? default ? "Da" : "Nu")));
                }
                return list;
            }
        }

        private ObservableCollection<Tuple<Pupil, decimal?, bool?>> pupils;
        public ObservableCollection<Tuple<Pupil, decimal?, bool?>> Pupils
        {
            get
            {
                return pupils;
            }
            set
            {
                pupils = value;
                NotifyPropertyChanged("Pupils");
            }
        }

        private int? subjectIDSelected;
        public int? SubjectIDSelected
        {
            get
            {
                return subjectIDSelected;
            }
            set
            {
                subjectIDSelected = value;
                NotifyPropertyChanged("SubjectIDSelected");
            }
        }

        private ICommand getPupilsCommand;
        public ICommand GetPupilsCommand
        {
            get
            {
                getPupilsCommand = new RelayCommand<int?>(o =>
                {
                    SubjectIDSelected = o;
                    SetPupils();
                });
                return getPupilsCommand;
            }
        }

        private ICommand finishMeanCommand;
        public ICommand FinishMeanCommand
        {
            get
            {
                finishMeanCommand = new RelayCommand<Tuple<Pupil, decimal?, bool?>>(o =>
                {
                    if (o == null)
                    {
                        MessageBox.Show("Nicio persoana selectata!", "Error", MessageBoxButton.OK);
                        return;
                    }

                    if(o.Item2==null)
                    {
                        MessageBox.Show("Media nu se poate incheia!", "Error", MessageBoxButton.OK);
                        return;
                    }

                    switch (o.Item3)
                    {
                        case true:
                            MessageBox.Show("Media este Incheiata!", "Error", MessageBoxButton.OK);
                            return;
                        case false:
                            SubjectPupilBLL.ModifySubjectPupil(new SubjectPupil()
                            {
                                PupilID = o.Item1.PupilID,
                                SubjectID = subjectIDSelected,
                                CalculatedMean = true
                            });
                            break;
                        default:
                            SubjectPupilBLL.AddSubjectPupil(new SubjectPupil()
                            {
                                PupilID = o.Item1.PupilID,
                                SubjectID = subjectIDSelected,
                                CalculatedMean = true
                            });
                            break;
                    }

                    SetPupils();
                });
                return finishMeanCommand;
            }
        }
    }
}
