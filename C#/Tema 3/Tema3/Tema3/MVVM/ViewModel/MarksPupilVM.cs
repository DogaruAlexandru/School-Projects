using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema3.MVVM.Model.BusinessLogicLayer;
using Tema3.MVVM.Model.EntityLayer;

namespace Tema3.MVVM.ViewModel
{
    class MarksPupilVM : BaseNotification
    {
        public MarksPupilVM()
        {
            pupilID = PupilVM.Pupil.PupilID;
            Marks = MarkDAL.GetPupilMarks(pupilID);
        }

        private ObservableCollection<PupilMark> marks;
        public ObservableCollection<PupilMark> Marks
        {
            get
            {
                return marks;
            }
            set
            {
                marks = value;
                NotifyPropertyChanged("Marks");
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
