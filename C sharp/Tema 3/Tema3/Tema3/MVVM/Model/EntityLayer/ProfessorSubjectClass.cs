using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema3.MVVM.ViewModel;

namespace Tema3.MVVM.Model.EntityLayer
{
    class ProfessorSubjectClass : BaseNotification
    {
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

        private string teaching_materials;
        public string Teaching_materials
        {
            get
            {
                return teaching_materials;
            }
            set
            {
                teaching_materials = value;
                NotifyPropertyChanged("Teaching_materials");
            }
        }
    }
}
