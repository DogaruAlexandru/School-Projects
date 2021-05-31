using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema3.MVVM.ViewModel;

namespace Tema3.MVVM.Model.EntityLayer
{
    class Class : BaseNotification
    {
        private int? classID;
        public int? ClassID
        {
            get
            {
                return classID;
            }
            set
            {
                classID = value;
                NotifyPropertyChanged("ClassID");
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

        private string group;
        public string Group
        {
            get
            {
                return group;
            }
            set
            {
                group = value;
                NotifyPropertyChanged("Group");
            }
        }

        private string specialization;
        public string Specialization
        {
            get
            {
                return specialization;
            }
            set
            {
                specialization = value;
                NotifyPropertyChanged("Specialization");
            }
        }

        private int? professorID;
        public int? ProfessorID
        {
            get
            {
                return professorID;
            }
            set
            {
                professorID = value;
                NotifyPropertyChanged("ProfessorID");
            }
        }

        public string ClassName
        {
            get
            {
                return Year + Group + " " + Specialization;
            }
        }
    }
}
