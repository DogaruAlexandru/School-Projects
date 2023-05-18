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
    static class AbsenceBLL
    {
        static public void AddAbsence(Absence absence)
        {
            AbsenceDAL.AddAbsence(absence);
        }

        static public void ModifyAbsence(Absence absence)
        {
            AbsenceDAL.ModifyAbsence(absence);
        }

        static public ObservableCollection<Absence> GetPupilAbsencesAtSubject(int? pupilID, int? subjectID)
        {
            return AbsenceDAL.GetPupilAbsencesAtSubject(pupilID, subjectID);
        }

        static public ObservableCollection<Absence> GetPupilAllAbsences(int? id)
        {
            return AbsenceDAL.GetPupilAllAbsences(id);
        }

        static public Absence GetAbsenceAtIndex(int? id)
        {
            return AbsenceDAL.GetAbsenceAtIndex(id);
        }
    }
}
