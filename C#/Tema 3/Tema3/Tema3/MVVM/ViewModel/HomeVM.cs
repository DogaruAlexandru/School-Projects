using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Tema3.Commands;
using Tema3.MVVM.View;
using Tema3.MVVM.Model.EntityLayer;
using Tema3.MVVM.Model.DataAccessLayer;
using Tema3.MVVM.Model.BusinessLogicLayer;

namespace Tema3.MVVM.ViewModel
{
    class HomeVM : BaseNotification
    {
        private ICommand logInClicked;
        public ICommand LogInClicked
        {
            get
            {
                logInClicked = new RelayCommand<HomeUC>(Logging);
                return logInClicked;
            }
        }
        private void Logging(HomeUC homeUC)
        {
            MainWindow mainWindow = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            MainVM mainVM = mainWindow.DataContext as MainVM;

            switch (homeUC.logInMode.Text)
            {
                case "Admin":
                    if (homeUC.username.Text == "admin" && homeUC.password.Password == "admin")
                    {
                        mainWindow.adminButton.IsEnabled = true;
                        mainWindow.adminButton.IsChecked = true;
                        mainVM.CurrentView = mainVM.AdminVM;
                        return;
                    }
                    break;

                case "Profesor":
                    Professor professor = ProfessorDAL.
                        GetProfessor(homeUC.username.Text, homeUC.password.Password);
                    if(professor.ProfessorID != null)
                    {
                        mainWindow.professorButton.IsEnabled = true;
                        mainWindow.professorButton.IsChecked = true;
                        mainVM.CurrentView = mainVM.ProfessorVM;
                        ProfessorVM.Professor = professor;
                        return;
                    }
                    break;

                case "Diriginte":
                    Tuple<Professor, Class> result= ProfessorDAL.
                        GethomeroomTeacher(homeUC.username.Text, homeUC.password.Password);
                    if (result.Item1.ProfessorID != null && result.Item2.ClassID != null)
                    {
                        mainWindow.homeroomTeacherButton.IsEnabled = true;
                        mainWindow.homeroomTeacherButton.IsChecked = true;
                        mainVM.CurrentView = mainVM.HomeroomTeacherVM;
                        HomeroomTeacherVM.HomeroomTeacher = result.Item1;
                        HomeroomTeacherVM.Class = result.Item2;
                        return;
                    }
                    break;

                case "Elev":
                    Pupil pupil = PupilBLL.
                        GetPupil(homeUC.username.Text, homeUC.password.Password);
                    if (pupil.PupilID != null)
                    {
                        mainWindow.pupilButton.IsEnabled = true;
                        mainWindow.pupilButton.IsChecked = true;
                        mainVM.CurrentView = mainVM.PupilVM;
                        PupilVM.Pupil = pupil;
                        return;
                    }
                    break;
            }
            MessageBox.Show("Numele de utilizator, parola sau modul de intrare ales este gresit!",
                "Error", MessageBoxButton.OK);
        }
    }
}
