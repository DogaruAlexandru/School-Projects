using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tema3.Commands;
using Tema3.MVVM.View;

namespace Tema3.MVVM.ViewModel
{
    class AdminVM : BaseNotification
    {
        private ICommand pupilCommand;
        public ICommand PupilCommand
        {
            get
            {
                pupilCommand = new RelayCommand<object>(o =>
                {
                    AdminPupilW window = new AdminPupilW();
                    window.ShowDialog();
                });
                return pupilCommand;
            }
        }

        private ICommand professorCommand;
        public ICommand ProfessorCommand
        {
            get
            {
                professorCommand = new RelayCommand<object>(o =>
                {
                    AdminProfessorW window = new AdminProfessorW();
                    window.ShowDialog();
                });
                return professorCommand;
            }
        }

        private ICommand subjectCommand;
        public ICommand SubjectCommand
        {
            get
            {
                subjectCommand = new RelayCommand<object>(o =>
                {
                    AdminSubjectW window = new AdminSubjectW();
                    window.ShowDialog();
                });
                return subjectCommand;
            }
        }

        private ICommand classCommand;
        public ICommand ClassCommand
        {
            get
            {
                classCommand = new RelayCommand<object>(o =>
                {
                    AdminClassW window = new AdminClassW();
                    window.ShowDialog();
                });
                return classCommand;
            }
        }

        private ICommand relationComman;
        public ICommand RelationComman
        {
            get
            {
                relationComman = new RelayCommand<object>(o =>
                {
                    AdminRelationW window = new AdminRelationW();
                    window.ShowDialog();
                });
                return relationComman;
            }
        }
    }
}
