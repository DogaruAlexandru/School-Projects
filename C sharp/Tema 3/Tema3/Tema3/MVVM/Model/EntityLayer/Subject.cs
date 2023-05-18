using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema3.MVVM.ViewModel;

namespace Tema3.MVVM.Model.EntityLayer
{
    class Subject : BaseNotification
    {
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
    }
}
