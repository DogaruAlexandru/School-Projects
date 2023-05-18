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
    class HomeroomTeacherVM : BaseNotification
    {
        static private Class @class;
        static public Class Class
        {
            get
            {
                return @class;
            }
            set
            {
                @class = value;
            }
        }

        static private Professor homeroomTeacher;
        static public Professor HomeroomTeacher
        {
            get
            {
                return homeroomTeacher;
            }
            set
            {
                homeroomTeacher = value;
            }
        }

        private ICommand absences;
        public ICommand Absences
        {
            get
            {
                absences = new RelayCommand<object>(o =>
                {
                    AbsencesHomeroomTeacherW window = new AbsencesHomeroomTeacherW();
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
                    MeansHomeroomTeacherW window = new MeansHomeroomTeacherW();
                    window.ShowDialog();
                });
                return means;
            }
        }

        private ICommand top;
        public ICommand Top
        {
            get
            {
                top = new RelayCommand<object>(o =>
                {
                    TopW window = new TopW();
                    window.ShowDialog();
                });
                return top;
            }
        }

        private ICommand expulsion;
        public ICommand Expulsion
        {
            get
            {
                expulsion = new RelayCommand<object>(o =>
                {
                    ExpulsionW window = new ExpulsionW();
                    window.ShowDialog();
                });
                return expulsion;
            }
        }
    }
}
