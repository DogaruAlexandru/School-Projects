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
    class MarksProfessorVM : BaseNotification
    {
        public MarksProfessorVM()
        {
            Subjects = SubjectBLL.GetSubjectsAndFinalExamAtProfessor(ProfessorVM.Professor.ProfessorID);
            Pupils = new ObservableCollection<Pupil>();
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

        #region Properties

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

        private ObservableCollection<Pupil> pupils;
        public ObservableCollection<Pupil> Pupils
        {
            get
            {
                return pupils;
            }
            set
            {
                pupils = value;
                NotifyPropertyChanged("Pupils");
                NotifyPropertyChanged("PupilsList");
            }
        }
        public ObservableCollection<Tuple<int?, string>> PupilsList
        {
            get
            {
                ObservableCollection<Tuple<int?, string>> list = new ObservableCollection<Tuple<int?, string>>();
                foreach (Pupil pupil in Pupils)
                {
                    list.Add(new Tuple<int?, string>(pupil.PupilID, pupil.FirstName + " " + pupil.LastName));
                }
                return list;
            }
        }

        private ObservableCollection<Mark> marks;
        public ObservableCollection<Mark> Marks
        {
            get
            {
                return marks;
            }
            set
            {
                marks = value;
                NotifyPropertyChanged("Marks");
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

        private int? pupilIDSelected;
        public int? PupilIDSelected
        {
            get
            {
                return pupilIDSelected;
            }
            set
            {
                pupilIDSelected = value;
                NotifyPropertyChanged("PupilIDSelected");
            }
        }

        private bool subjectHasFinalExam;
        public bool SubjectHasFinalExam
        {
            get
            {
                return subjectHasFinalExam;
            }
            set
            {
                subjectHasFinalExam = value;
                NotifyPropertyChanged("SubjectHasFinalExam");
            }
        }

        private bool completedMean;
        public bool CompletedMean
        {
            get
            {
                return completedMean;
            }
            set
            {
                completedMean = value;
                NotifyPropertyChanged("CompletedMean");
            }
        }

        #endregion

        #region Icommands

        private ICommand getPupilsCommand;
        public ICommand GetPupilsCommand
        {
            get
            {
                getPupilsCommand = new RelayCommand<int?>(o =>
                {
                    SubjectIDSelected = o;
                    SubjectHasFinalExam = FindSubjectHasFinalExam(o);
                    Pupils = PupilBLL.GetPupilsAtSubject(o);
                    Marks = MarkBLL.GetPupilMarksAtSubject(PupilIDSelected, SubjectIDSelected);
                    switch (SubjectPupilBLL.GetCalculatedMean(PupilIDSelected, SubjectIDSelected))
                    {
                        case true:
                            CompletedMean = true;
                            break;
                        default:
                            CompletedMean = false;
                            break;
                    }
                });
                return getPupilsCommand;
            }
        }

        private ICommand getMarksCommand;
        public ICommand GetMarksCommand
        {
            get
            {
                getMarksCommand = new RelayCommand<int?>(o =>
                {
                    PupilIDSelected = o;
                    Marks = MarkBLL.GetPupilMarksAtSubject(PupilIDSelected, SubjectIDSelected);
                    switch (SubjectPupilBLL.GetCalculatedMean(PupilIDSelected, SubjectIDSelected))
                    {
                        case true:
                            CompletedMean = true;
                            break;
                        default:
                            CompletedMean = false;
                            break;
                    }
                });
                return getMarksCommand;
            }
        }

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                addCommand = new RelayCommand<Mark>(o =>
                {
                    if (!CompletedMean)
                    {
                        if (o == null || o.DateTime == null || o.MarkScore == null ||
                              o.MarkScore == null || o.PupilID == null || o.SubjectID == null)
                        {
                            MessageBox.Show("Nu sunt completate toate campurile!", "Error", MessageBoxButton.OK);
                            return;
                        }

                        if (SubjectHasFinalExam == false)
                            o.FinalExam = false;
                        else if (o.FinalExam == null)
                        {
                            MessageBox.Show("Nu sunt completate toate campurile!", "Error", MessageBoxButton.OK);
                            return;
                        }

                        if (o.MarkScore > 10 || o.MarkScore < 1)
                        {
                            MessageBox.Show("Nota nu are format corect!", "Error", MessageBoxButton.OK);
                            return;
                        }

                        MarkBLL.AddMark(o);
                        Marks = MarkBLL.GetPupilMarksAtSubject(PupilIDSelected, SubjectIDSelected);
                    }
                    else
                        MessageBox.Show("Medie incheiata!", "Error", MessageBoxButton.OK);
                });
                return addCommand;
            }
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                deleteCommand = new RelayCommand<Mark>(o =>
                {
                    if (!CompletedMean)
                    {
                        if (o == null || o.MarkID == null)
                        {
                            MessageBox.Show("Nici o nota selectata!", "Error", MessageBoxButton.OK);
                            return;
                        }
                        MarkBLL.DeleteMark(o);
                        Marks = MarkBLL.GetPupilMarksAtSubject(PupilIDSelected, SubjectIDSelected);
                    }
                    else
                        MessageBox.Show("Medie incheiata!", "Error", MessageBoxButton.OK);
                });
                return deleteCommand;
            }
        }

        #endregion
    }
}
