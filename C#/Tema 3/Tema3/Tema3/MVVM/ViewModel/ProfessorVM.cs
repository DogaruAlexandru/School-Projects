using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tema3.Commands;
using Tema3.MVVM.Model.EntityLayer;
using Tema3.MVVM.View;

namespace Tema3.MVVM.ViewModel
{
    class ProfessorVM : BaseNotification
    {
        static private Professor professor;
        static public Professor Professor
        {
            get
            {
                return professor;
            }
            set
            {
                professor = value;
            }
        }

        private ICommand teachingMaterials;
        public ICommand TeachingMaterials
        {
            get
            {
                teachingMaterials = new RelayCommand<object>(o =>
                {
                    TeachingMaterialsProfessorW window = new TeachingMaterialsProfessorW();
                    window.ShowDialog();
                });
                return teachingMaterials;
            }
        }

        private ICommand marks;
        public ICommand Marks
        {
            get
            {
                marks = new RelayCommand<object>(o =>
                {
                    MarksProfessorW window = new MarksProfessorW();
                    window.ShowDialog();
                });
                return marks;
            }
        }

        private ICommand absences;
        public ICommand Absences
        {
            get
            {
                absences = new RelayCommand<object>(o =>
                {
                    AbsencesProfessorW window = new AbsencesProfessorW();
                    window.ShowDialog();
                });
                return absences;
            }
        }

        private ICommand means;
        public ICommand Means
        {
            get
            {
                means = new RelayCommand<object>(o =>
                {
                    MeansProfessorW window = new MeansProfessorW();
                    window.ShowDialog();
                });
                return means;
            }
        }
    }
}
