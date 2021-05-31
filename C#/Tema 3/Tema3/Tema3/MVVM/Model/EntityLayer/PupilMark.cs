using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema3.MVVM.ViewModel;

namespace Tema3.MVVM.Model.EntityLayer
{
    class PupilMark : BaseNotification
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

        private bool? hasFinalExam;
        public bool? HasFinalExam
        {
            get
            {
                return hasFinalExam;
            }
            set
            {
                hasFinalExam = value;
                NotifyPropertyChanged("HasFinalExam");
            }
        }

        private DateTime? dateTime;
        public DateTime? DateTime
        {
            get
            {
                return dateTime;
            }
            set
            {
                dateTime = value;
                NotifyPropertyChanged("DateTime");
            }
        }
        public string Date
        {
            get
            {
                return dateTime.Value.Date.ToShortDateString();
            }
        }

        private bool? finalExam;
        public bool? FinalExam
        {
            get
            {
                return finalExam;
            }
            set
            {
                finalExam = value;
                NotifyPropertyChanged("FinalExam");
            }
        }

        private decimal? markScore;
        public decimal? MarkScore
        {
            get
            {
                return markScore;
            }
            set
            {
                markScore = value;
                NotifyPropertyChanged("MarkScore");
            }
        }
    }
}
