using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema3.MVVM.ViewModel;

namespace Tema3.MVVM.Model.EntityLayer
{
    class PupilAbsence : BaseNotification
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
        private State markState;
        public State MarkState
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
    }
}
