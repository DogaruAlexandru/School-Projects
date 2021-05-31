using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema3.MVVM.ViewModel;

namespace Tema3.MVVM.Model.EntityLayer
{
    class SubjectPupil : BaseNotification
    {
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

        private bool? calculatedMean;
        public bool? CalculatedMean
        {
            get
            {
                return calculatedMean;
            }
            set
            {
                calculatedMean = value;
                NotifyPropertyChanged("CalculatedMean");

            }
        }

    }
}
