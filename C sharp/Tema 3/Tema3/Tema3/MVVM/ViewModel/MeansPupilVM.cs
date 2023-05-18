using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema3.MVVM.Model.BusinessLogicLayer;
using Tema3.MVVM.Model.EntityLayer;

namespace Tema3.MVVM.ViewModel
{
    class MeansPupilVM : BaseNotification
    {
        public MeansPupilVM()
        {
            pupilID = PupilVM.Pupil.PupilID;
            Means = MeansBLL.GetPupilMeans(pupilID);
            AddMean();
        }

        private ObservableCollection<Mean> means;
        public ObservableCollection<Mean> Means
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

        private int? pupilID;
        public int? PupilID
        {
            get
            {
                return pupilID;
            }
            set
            {
                pupilID = value;
                NotifyPropertyChanged("PupilID");
            }
        }

        private void AddMean()
        {
            int count = 0;
            decimal? sum = 0;
            foreach (Mean mean in Means)
            {
                if (mean.MeanMark != null)
                {
                    sum += mean.MeanMark;
                    ++count;
                }
            }
            Means.Add(new Mean()
            {
                SubjectName = "Medie Generala",
                MeanMark = Math.Round(sum / count ?? default, 2)
            });;
        }
    }
}
