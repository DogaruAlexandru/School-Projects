using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema3.MVVM.ViewModel;

namespace Tema3.MVVM.Model.EntityLayer
{
    class Mark : BaseNotification
    {
        private int? markID;
        public int? MarkID
        {
            get
            {
                return markID;
            }
            set
            {
                markID = value;
                NotifyPropertyChanged("MarkID");
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
                return DateTime.Value.Date.ToShortDateString();
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

        private int? subjectID;
        public int? SubjectID
        {
            get
            {
                return subjectID;
            }
            set
            {
                subjectID = value;
                NotifyPropertyChanged("SubjectID");
            }
        }
    }
}
