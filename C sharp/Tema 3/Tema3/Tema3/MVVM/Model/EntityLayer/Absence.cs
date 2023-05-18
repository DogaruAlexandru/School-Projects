using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema3.MVVM.ViewModel;

namespace Tema3.MVVM.Model.EntityLayer
{
    class Absence : BaseNotification
    {
        private int? absenceID;
        public int? AbsenceID
        {
            get
            {
                return absenceID;
            }
            set
            {
                absenceID = value;
                NotifyPropertyChanged("AbsenceID");
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

        public enum State
        {
            Unmotivated,
            Motivated,
            Unmotivable
        }
        private State? markState;
        public State? MarkState
        {
            get
            {
                return markState;
            }
            set
            {
                markState = value;
                NotifyPropertyChanged("MarkState");
            }
        }
        public string StateToString
        {
            get
            {
                switch (MarkState)
                {
                    case State.Unmotivated:
                        return "Nemotivata";
                    case State.Unmotivable:
                        return "Nemotivabila";
                    case State.Motivated:
                        return "Motivata";
                    default:
                        return "";
                }
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
