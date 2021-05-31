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
    class AbsencesHomeroomTeacherVM : BaseNotification
    {
        public AbsencesHomeroomTeacherVM()
        {
            Pupils = PupilBLL.GetPupilInClass(HomeroomTeacherVM.Class.ClassID);
            Pupils.Insert(0, new Pupil() { PupilID = -1, FirstName = "Toti" });
            AllAbsences = true;
            PupilSelected = Pupils[0];
            GetAbsences();
        }

        private void GetAbsences()
        {
            Absences = new ObservableCollection<Tuple<int?, string, string, string>>();

            if (AllAbsences)
                if (PupilSelected.PupilID == -1)
                    foreach (Pupil p in Pupils)
                    {
                        foreach (Absence a in AbsenceBLL.GetPupilAllAbsences(p.PupilID))
                        {
                            Absences.Add(new Tuple<int?, string, string, string>(
                                a.AbsenceID, p.FirstName + " " + p.LastName, a.Date, a.StateToString));
                        }
                    }
                else
                    foreach (Absence a in AbsenceBLL.GetPupilAllAbsences(PupilSelected.PupilID))
                    {
                        Absences.Add(new Tuple<int?, string, string, string>(
                            a.AbsenceID, PupilSelected.FirstName + " " +
                            PupilSelected.LastName, a.Date, a.StateToString));
                    }
            else if (PupilSelected.PupilID == -1)
                foreach (Pupil p in Pupils)
                {
                    foreach (Absence a in AbsenceBLL.GetPupilAllAbsences(p.PupilID))
                    {
                        if (a.MarkState != Absence.State.Motivated)
                            Absences.Add(new Tuple<int?, string, string, string>(
                                a.AbsenceID, p.FirstName + " " + p.LastName, a.Date, a.StateToString));
                    }
                }
            else
                foreach (Absence a in AbsenceBLL.GetPupilAllAbsences(PupilSelected.PupilID))
                {
                    if (a.MarkState != Absence.State.Motivated)
                        Absences.Add(new Tuple<int?, string, string, string>(
                        a.AbsenceID, PupilSelected.FirstName + " " +
                        PupilSelected.LastName, a.Date, a.StateToString));
                }
            NotifyPropertyChanged("Count");
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

        private ObservableCollection<Tuple<int?, string, string, string>> absences;
        public ObservableCollection<Tuple<int?, string, string, string>> Absences
        {
            get
            {
                return absences;
            }
            set
            {
                absences = value;
                NotifyPropertyChanged("Absences");
            }
        }

        private bool allAbsences;
        public bool AllAbsences
        {
            get
            {
                return allAbsences;
            }
            set
            {
                allAbsences = value;
                NotifyPropertyChanged("AllAbsences");
            }
        }

        private Pupil pupilSelected;
        public Pupil PupilSelected
        {
            get
            {
                return pupilSelected;
            }
            set
            {
                pupilSelected = value;
                NotifyPropertyChanged("PupilSelected");
            }
        }

        public string Count
        {
            get
            {
                return Absences.Count + " absente nemotivate";
            }
        }


        private ICommand pupilCommand;
        public ICommand PupilCommand
        {
            get
            {
                pupilCommand = new RelayCommand<int?>(o =>
                {
                    if (o != -1)
                        PupilSelected = PupilBLL.GetPupilAtIndex(o);
                    else
                        PupilSelected = Pupils[0];
                    GetAbsences();

                });
                return pupilCommand;
            }
        }

        private ICommand stateCommand;
        public ICommand StateCommand
        {
            get
            {
                stateCommand = new RelayCommand<string>(o =>
                {
                    AllAbsences = o != "Toate";
                    GetAbsences();
                });
                return stateCommand;
            }
        }

        private ICommand motivateCommand;
        public ICommand MotivateCommand
        {
            get
            {
                motivateCommand = new RelayCommand<Tuple<int?, string, string, string>>(o =>
                {
                    if (o == null)
                    {
                        MessageBox.Show("Nicio absenta selectata!", "Error", MessageBoxButton.OK);
                        return;
                    }
                    if (o.Item4 == "Nemotivabila")
                    {
                        MessageBox.Show("Absenta nemotivabila!", "Error", MessageBoxButton.OK);
                        return;
                    }
                    if (o.Item4 == "Motivata")
                    {
                        MessageBox.Show("Absenta deja motivata!", "Error", MessageBoxButton.OK);
                        return;
                    }
                    Absence a = AbsenceBLL.GetAbsenceAtIndex(o.Item1);
                    a.MarkState = Absence.State.Motivated;
                    AbsenceBLL.ModifyAbsence(a);
                    GetAbsences();
                });
                return motivateCommand;
            }
        }
    }
}
