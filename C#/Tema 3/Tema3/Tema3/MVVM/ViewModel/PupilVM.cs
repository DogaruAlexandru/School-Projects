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
    class PupilVM
    {
        static private Pupil pupil;
        static public Pupil Pupil
        {
            get
            {
                return pupil;
            }
            set
            {
                pupil = value;
            }
        }

        private ICommand teachingMaterials;
        public ICommand TeachingMaterials
        {
            get
            {
                teachingMaterials = new RelayCommand<object>(o =>
                {
                    TeachingMaterialsPupilW window = new TeachingMaterialsPupilW();
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
                    MarksPupilW window = new MarksPupilW();
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
                    AbsencesPupilW window = new AbsencesPupilW();
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
                    MeansPupilW window = new MeansPupilW();
                    window.ShowDialog();
                });
                return means;
            }
        }
    }
}
