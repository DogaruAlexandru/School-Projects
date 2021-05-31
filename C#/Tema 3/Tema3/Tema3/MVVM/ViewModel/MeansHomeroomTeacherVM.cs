using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tema3.Commands;
using Tema3.MVVM.Model.BusinessLogicLayer;
using Tema3.MVVM.Model.EntityLayer;

namespace Tema3.MVVM.ViewModel
{
    class MeansHomeroomTeacherVM : BaseNotification
    {
        public MeansHomeroomTeacherVM()
        {
            Pupils = PupilBLL.GetPupilInClass(HomeroomTeacherVM.Class.ClassID);
            Means = new ObservableCollection<Tuple<Subject, decimal?>>();
            Subjects = SubjectBLL.GetSubjectsOfClass(HomeroomTeacherVM.Class.ClassID);
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
                NotifyPropertyChanged("Pupils");
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

        private ObservableCollection<Tuple<Subject, decimal?>> means;
        public ObservableCollection<Tuple<Subject, decimal?>> Means
        {
            get
            {
                return means;
            }
            set
            {
                means = value;
                NotifyPropertyChanged("Means");
            }
        }

        private ICommand pupilCommand;
        public ICommand PupilCommand
        {
            get
            {
                pupilCommand = new RelayCommand<int?>(o =>
                {
                    Means = new ObservableCollection<Tuple<Subject, decimal?>>();
                    decimal sum = 0;
                    int count = 0;
                    foreach (Tuple<bool?, Subject> t in Subjects)
                    {
                        decimal? m = MeansBLL.GetPupilMeanAtSubject(o, t.Item2.SubjectID, t.Item1);
                        Means.Add(new Tuple<Subject, decimal?>(t.Item2, m));

                        if (m != null)
                        {
                            sum += m ?? default;
                            ++count;
                        }
                    }
                    if (count > 0)
                        Means.Add(new Tuple<Subject, decimal?>(new Subject()
                        {
                            SubjectName = "Medie generala"
                        },
                        Math.Round(sum / count, 2)));
                    else
                        Means.Add(new Tuple<Subject, decimal?>(new Subject()
                        {
                            SubjectName = "Medie generala"
                        },
                        null));

                });
                return pupilCommand;
            }
        }
    }
}
