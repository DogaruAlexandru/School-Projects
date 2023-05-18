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
    class TopVM : BaseNotification
    {
        public TopVM()
        {
            GetMeans();
        }

        private void GetMeans()
        {
            ObservableCollection<Tuple<bool?, Subject>> subjects =
                SubjectBLL.GetSubjectsOfClass(HomeroomTeacherVM.Class.ClassID);

            ObservableCollection<Pupil> pupils =
                PupilBLL.GetPupilInClass(HomeroomTeacherVM.Class.ClassID);

            string s = "";
            decimal? mean = 0;
            int count = 0;

            Means = new ObservableCollection<Tuple<Pupil, decimal?, string, ObservableCollection<string>>>();
            foreach (Pupil p in pupils)
            {
                ObservableCollection<string> failedSubject = new ObservableCollection<string>();

                mean = 0;
                count = 0;

                foreach (Tuple<bool?, Subject> t in subjects)
                {
                    decimal? m = MeansBLL.GetPupilMeanAtSubject(p.PupilID, t.Item2.SubjectID, t.Item1);

                    if (m == null)
                        continue;

                    if (m < 5)
                        failedSubject.Add(t.Item2.SubjectName + " - Sem: " + t.Item2.Semester);

                    mean += m;
                    ++count;
                }

                s = "";
                switch (failedSubject.Count)
                {
                    case 0:
                        break;
                    case 1:
                    case 2:
                        s = "Corigent";
                        break;
                    default:
                        s = "Repetent";
                        break;
                }

                mean = count == subjects.Count ? mean / count : null;
                mean = Math.Round(mean ?? default, 2);

                Means.Add(new Tuple<Pupil, decimal?, string, ObservableCollection<string>>(p, mean, s, failedSubject));
            }
            Means = new ObservableCollection<Tuple<Pupil, decimal?, string, ObservableCollection<string>>>
                (Means.OrderByDescending(x => x.Item2));

            mean = Means.Count > 0 ? Means[0].Item2 : null;
            count = 0;

            for (int i = 0; i < Means.Count; ++i)
            {
                if (Means[i].Item2 == null)
                    break;
                if (Means[i].Item3 != "")
                    continue;
                if (Means[i].Item2 != mean)
                    ++count;
                switch (count)
                {
                    case 0:
                        s = "Premiul I";
                        break;
                    case 1:
                        s = "Premiul II";
                        break;
                    case 2:
                        s = "Premiul III";
                        break;
                    case 3:
                        s = "Mentiune";
                        break;
                    default:
                        return;
                }
                Means[i] = new Tuple<Pupil, decimal?, string, ObservableCollection<string>>(
                    Means[i].Item1, Means[i].Item2, s, Means[i].Item4);
            }
        }

        private ObservableCollection<Tuple<Pupil, decimal?, string, ObservableCollection<string>>> means;
        public ObservableCollection<Tuple<Pupil, decimal?, string, ObservableCollection<string>>> Means
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

        private ObservableCollection<string> failed;
        public ObservableCollection<string> Failed
        {
            get
            {
                return failed;
            }
            set
            {
                failed = value;
                NotifyPropertyChanged("Failed");
            }
        }


        private ICommand selectedCommand;
        public ICommand SelectedCommand
        {
            get
            {
                selectedCommand = new RelayCommand<int>(o =>
                {
                    Failed = Means[o].Item4;
                });
                return selectedCommand;
            }
        }
    }
}
