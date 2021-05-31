using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema3.MVVM.ViewModel;

namespace Tema3.MVVM.Model.EntityLayer
{
    class Mean : BaseNotification
    {
        private string subjectName;
        public string SubjectName
        {
            get
            {
                return subjectName;
            }
            set
            {
                subjectName = value;
                NotifyPropertyChanged("SubjectName");
            }
        }

        private int? semester;
        public int? Semester
        {
            get
            {
                return semester;
            }
            set
            {
                semester = value;
                NotifyPropertyChanged("Semester");
            }
        }

        private int? year;
        public int? Year
        {
            get
            {
                return year;
            }
            set
            {
                year = value;
                NotifyPropertyChanged("Year");
            }
        }

        private decimal? meanMark;
        public decimal? MeanMark
        {
            get
            {
                if (meanMark != null)
                    return Math.Round(meanMark ?? default, 2);
                return null;
            }
            set
            {
                meanMark = value;
                NotifyPropertyChanged("MeanMark");
            }
        }
    }
}
