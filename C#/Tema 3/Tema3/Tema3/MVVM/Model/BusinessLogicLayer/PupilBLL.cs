using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema3.MVVM.Model.DataAccessLayer;
using Tema3.MVVM.Model.EntityLayer;

namespace Tema3.MVVM.Model.BusinessLogicLayer
{
    static class PupilBLL
    {
        static public Pupil GetPupil(string u, string p)
        {
            return PupilDAL.GetPupil(u, p);
        }

        static public ObservableCollection<Pupil> GetPupilsAtSubject(int? id)
        {
            return PupilDAL.GetPupilsAtSubject(id);
        }

        static public ObservableCollection<Pupil> GetPupilInClass(int? id)
        {
            return PupilDAL.GetPupilInClass(id);
        }

        static public Pupil GetPupilAtIndex(int? id)
        {
            return PupilDAL.GetPupilAtIndex(id);
        }

        static public ObservableCollection<Tuple<Pupil, string, string>> GetAllPupil()
        {
            return PupilDAL.GetAllPupil();
        }

        static public void ModifyPupil(Tuple<Pupil, string, string> t)
        {
            PupilDAL.ModifyPupil(t);
        }

        static public void DeletePupil(Pupil pupil)
        {
            PupilDAL.DeletePupil(pupil);
        }

        static public void AddPupil(Tuple<Pupil, string, string> t)
        {
            PupilDAL.AddPupil(t);
        }
    }
}
