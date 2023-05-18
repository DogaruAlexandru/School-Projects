using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema3.MVVM.ViewModel;

namespace Tema3.MVVM.Model.EntityLayer
{
    class Pupil : BaseNotification
    {
        private int? pupilID;
        public int? PupilID
        {
            get
            {
                return pupilID;
            }
            set
            {
                pupilID = value;
                NotifyPropertyChanged("PupilID");
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
    }
}
