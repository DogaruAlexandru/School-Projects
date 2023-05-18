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
using Tema3.MVVM.Model.DataAccessLayer;
using Tema3.MVVM.Model.EntityLayer;

namespace Tema3.MVVM.ViewModel
{
    class AbsencesProfessorVM : BaseNotification
    {
        public AbsencesProfessorVM()
        {
            Subjects = SubjectBLL.GetSubjectsAtProfessor(ProfessorVM.Professor.ProfessorID);
            Pupils = new ObservableCollection<Pupil>();
        }

        #region Properties

        private ObservableCollection<Subject> subjects;
        public ObservableCollection<Subject> Subjects
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
                foreach (Subject subject in Subjects)
                {
                    list.Add(new Tuple<int?, string>(subject.SubjectID,
                        subject.SubjectName + " - An: " + subject.Year + " - Sem: " + subject.Semester));
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

        private ObservableCollection<Absence> absneces;
        public ObservableCollection<Absence> Absences
        {
            get
            {
                return absneces;
            }
            set
            {
                absneces = value;
                NotifyPropertyChanged("Absences");
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

        #endregion

        #region IComands

        private ICommand getPupilsCommand;
        public ICommand GetPupilsCommand
        {
            get
            {
                getPupilsCommand = new RelayCommand<int?>(o =>
                {
                    SubjectIDSelected = o;
                    Pupils = PupilBLL.GetPupilsAtSubject(o);
                    Absences = AbsenceBLL.GetPupilAbsencesAtSubject(PupilIDSelected, SubjectIDSelected);
                });
                return getPupilsCommand;
            }
        }

        private ICommand getAbsencesCommand;
        public ICommand GetAbsencesCommand
        {
            get
            {
                getAbsencesCommand = new RelayCommand<int?>(o =>
                {
                    PupilIDSelected = o;
                    Absences = AbsenceBLL.GetPupilAbsencesAtSubject(PupilIDSelected, SubjectIDSelected);
                });
                return getAbsencesCommand;
            }
        }

        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                addCommand = new RelayCommand<Absence>(o =>
                {
                    if (o == null || o.DateTime == null || o.MarkState == null ||
                        o.PupilID == null || o.SubjectID == null)
                    {
                        MessageBox.Show("Campurile nu sunt completate", "Error", MessageBoxButton.OK);
                        return;
                    }
                    AbsenceBLL.AddAbsence(o);
                    Absences = AbsenceBLL.GetPupilAbsencesAtSubject(PupilIDSelected, SubjectIDSelected);
                });
                return addCommand;
            }
        }

        private ICommand motivateCommand;
        public ICommand MotivateCommand
        {
            get
            {
                motivateCommand = new RelayCommand<Absence>(o =>
                {
                    if (o == null)
                    {
                        MessageBox.Show("Nicio absenta selectata!", "Error", MessageBoxButton.OK);
                        return;
                    }
                    if (o.MarkState == Absence.State.Unmotivable)
                    {
                        MessageBox.Show("Absenta nemotivabila!", "Error", MessageBoxButton.OK);
                        return;
                    }
                    if (o.MarkState == Absence.State.Motivated)
                    {
                        MessageBox.Show("Absenta deja motivata!", "Error", MessageBoxButton.OK);
                        return;
                    }
                    o.MarkState = Absence.State.Motivated;
                    AbsenceBLL.ModifyAbsence(o);
                    Absences = AbsenceBLL.GetPupilAbsencesAtSubject(PupilIDSelected, SubjectIDSelected);
                });
                return motivateCommand;
            }
        }

        #endregion
    }
}
