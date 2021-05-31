using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Tema3.Commands;
using Tema3.MVVM.Model.BusinessLogicLayer;
using Tema3.MVVM.Model.EntityLayer;
using Tema3.MVVM.View;

namespace Tema3.MVVM.ViewModel
{
    class AdminPupilVM : BaseNotification
    {
        public AdminPupilVM()
        {
            Classes = ClassBLL.GetAllClass();
            GetPupils();
        }

        private void GetPupils()
        {
            Pupils = new ObservableCollection<Tuple<Pupil, string, string, Class>>();

            ObservableCollection<Tuple<Pupil, string, string>> aux = PupilBLL.GetAllPupil();
            foreach (Tuple<Pupil, string, string> t in aux)
            {
                Pupils.Add(new Tuple<Pupil, string, string, Class>(t.Item1, t.Item2,
                    t.Item3, ClassBLL.GetClassAtIndex(t.Item1.ClassID)));
            }
        }

        private ObservableCollection<Class> classes;
        public ObservableCollection<Class> Classes
        {
            get
            {
                return classes;
            }
            set
            {
                classes = value;
                NotifyPropertyChanged("Classes");
            }
        }

        private ObservableCollection<Tuple<Pupil, string, string, Class>> pupils;
        public ObservableCollection<Tuple<Pupil, string, string, Class>> Pupils
        {
            get
            {
                return pupils;
            }
            set
            {
                pupils = value;
                NotifyPropertyChanged("Pupils");
            }
        }

        private string firstName;
        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
                NotifyPropertyChanged("FirstName");
            }
        }

        private string lastName;
        public string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
                NotifyPropertyChanged("LastName");
            }
        }

        private string username;
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
                NotifyPropertyChanged("Username");
            }
        }

        private string password;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
                NotifyPropertyChanged("Password");
            }
        }

        private string phoneNumber;
        public string PhoneNumber
        {
            get
            {
                return phoneNumber;
            }
            set
            {
                phoneNumber = value;
                NotifyPropertyChanged("PhoneNumber");
            }
        }

        private string email;
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
                NotifyPropertyChanged("Email");
            }
        }

        private Tuple<Pupil, string, string, Class> selectedPupil;
        public Tuple<Pupil, string, string, Class> SelectedPupil
        {
            get
            {
                return selectedPupil;
            }
            set
            {
                selectedPupil = value;
                NotifyPropertyChanged("SelectedPupil");
            }
        }


        private ICommand addCommand;
        public ICommand AddCommand
        {
            get
            {
                addCommand = new RelayCommand<Class>(o =>
                {
                    if (o == null || FirstName == "" || LastName == "" || PhoneNumber == "")
                    {
                        MessageBox.Show("Campuri necompletate!", "Error", MessageBoxButton.OK);
                        return;
                    }
                    if (!PhoneNumber.All(char.IsDigit) || PhoneNumber.Length > 10)
                    {
                        MessageBox.Show("Numar de telefon invalid!", "Error", MessageBoxButton.OK);
                        return;
                    }
                    PupilBLL.AddPupil(new Tuple<Pupil, string, string>(
                        new Pupil()
                        {
                            ClassID = o.ClassID,
                            Email = Email,
                            FirstName = FirstName,
                            LastName = LastName,
                            PhoneNumber = PhoneNumber
                        },
                        Username,
                        Password));
                    GetPupils();
                });
                return addCommand;
            }
        }

        private ICommand modifyCommand;
        public ICommand ModifyCommand
        {
            get
            {
                modifyCommand = new RelayCommand<Class>(o =>
                {
                    if (SelectedPupil == null)
                    {
                        MessageBox.Show("Niciun elev selectat!", "Error", MessageBoxButton.OK);
                        return;
                    }
                    if (o == null || FirstName == "" || LastName == "" || PhoneNumber == "")
                    {
                        MessageBox.Show("Campuri necompletate!", "Error", MessageBoxButton.OK);
                        return;
                    }
                    if (!PhoneNumber.All(char.IsDigit) || PhoneNumber.Length > 10)
                    {
                        MessageBox.Show("Numar de telefon invalid!", "Error", MessageBoxButton.OK);
                        return;
                    }
                    PupilBLL.ModifyPupil(new Tuple<Pupil, string, string>(
                        new Pupil()
                        {
                            PupilID = selectedPupil.Item1.PupilID,
                            ClassID = o.ClassID,
                            Email = Email,
                            FirstName = FirstName,
                            LastName = LastName,
                            PhoneNumber = PhoneNumber
                        },
                        Username,
                        Password));
                    GetPupils();
                });
                return modifyCommand;
            }
        }

        private ICommand deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                deleteCommand = new RelayCommand<object>(o =>
                {
                    if (SelectedPupil == null)
                    {
                        MessageBox.Show("Niciun elev selectat!", "Error", MessageBoxButton.OK);
                        return;
                    }
                    PupilBLL.DeletePupil(SelectedPupil.Item1);
                    GetPupils();
                });
                return deleteCommand;
            }
        }

        private ICommand selectCommand;
        public ICommand SelectCommand
        {
            get
            {
                selectCommand = new RelayCommand<AdminPupilW>(w =>
                {
                    Tuple<Pupil, string, string, Class> o = w.infoGrid.SelectedItem as Tuple<Pupil, string, string, Class>;
                    FirstName = o == null ? "" : o.Item1.FirstName;
                    LastName = o == null ? "" : o.Item1.LastName;
                    Username = o == null ? "" : o.Item2;
                    Password = o == null ? "" : o.Item3;
                    PhoneNumber = o == null ? "" : o.Item1.PhoneNumber;
                    Email = o == null ? "" : o.Item1.Email;
                    SelectedPupil = o;
                    if (o != null)
                        foreach (Class c in classes)
                        {
                            if (c.ClassID == o.Item4.ClassID)
                            {
                                w.classCB.SelectedValue = c;
                                break;
                            }
                        }
                });
                return selectCommand;
            }
        }
    }
}
