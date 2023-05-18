using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema3.MVVM.Model.DataAccessLayer;
using Tema3.MVVM.Model.EntityLayer;

namespace Tema3.MVVM.ViewModel
{
    class AbsencesPupilVM : BaseNotification
    {
        public AbsencesPupilVM()
        {
            pupilID = PupilVM.Pupil.PupilID;
            Absences = AbsenceDAL.GetPupilAbsences(pupilID);
        }

        private ObservableCollection<PupilAbsence> absences;
        public ObservableCollection<PupilAbsence> Absences
        {
            get
            {
                return absences;
            }
            set
            {
                absences = value;
                NotifyPropertyChanged("Absence");
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
    }
}
