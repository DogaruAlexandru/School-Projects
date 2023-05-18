using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Tema3.Commands;

namespace Tema3.MVVM.ViewModel
{
    class MainVM : BaseNotification
    {
        public HomeVM HomeVM { get; set; }
        public AdminVM AdminVM { get; set; }
        public ProfessorVM ProfessorVM { get; set; }
        public HomeroomTeacherVM HomeroomTeacherVM { get; set; }
        public PupilVM PupilVM { get; set; }

        private MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();

        public MainVM()
        {
            HomeVM = new HomeVM();
            AdminVM = new AdminVM();
            ProfessorVM = new ProfessorVM();
            HomeroomTeacherVM = new HomeroomTeacherVM();
            PupilVM = new PupilVM();

            CurrentView = HomeVM;
        }

        private object currentView;
        public object CurrentView
        {
            get { return currentView; }
            set
            {
                currentView = value;
                NotifyPropertyChanged("CurrentView");
            }
        }

        private ICommand homeClicked;
        public ICommand HomeClicked
        {
            get
            {
                homeClicked = new RelayCommand<object>(o =>
                {
                    CurrentView = HomeVM;
                    mainWindow.adminButton.IsEnabled = false;
                    mainWindow.professorButton.IsEnabled = false;
                    mainWindow.homeroomTeacherButton.IsEnabled = false;
                    mainWindow.pupilButton.IsEnabled = false;
                });
                return homeClicked;
            }
        }

        private ICommand adminClicked;
        public ICommand AdminClicked
        {
            get
            {
                adminClicked = new RelayCommand<object>(o =>
                {
                    CurrentView = AdminVM;
                });
                return adminClicked;
            }
        }

        private ICommand professorClicked;
        public ICommand ProfessorClicked
        {
            get
            {
                professorClicked = new RelayCommand<object>(o =>
                {
                    CurrentView = ProfessorVM;
                });
                return professorClicked;
            }
        }

        private ICommand homeroomTeacherClicked;
        public ICommand HomeroomTeacherClicked
        {
            get
            {
                homeroomTeacherClicked = new RelayCommand<object>(o =>
                {
                    CurrentView = HomeroomTeacherVM;
                });
                return homeroomTeacherClicked;
            }
        }

        private ICommand pupilClicked;
        public ICommand PupilClicked
        {
            get
            {
                pupilClicked = new RelayCommand<object>(o =>
                {
                    CurrentView = PupilVM;
                });
                return pupilClicked;
            }
        }
    }
}
