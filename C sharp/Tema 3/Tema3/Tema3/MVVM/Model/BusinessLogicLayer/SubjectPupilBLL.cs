using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema3.MVVM.Model.DataAccessLayer;
using Tema3.MVVM.Model.EntityLayer;

namespace Tema3.MVVM.Model.BusinessLogicLayer
{
    static class SubjectPupilBLL
    {
        static public bool? GetCalculatedMean(int? pupilID, int? subjectID)
        {
            return SubjectPupilDAL.GetCalculatedMean(pupilID, subjectID);
        }

        static public void AddSubjectPupil(SubjectPupil subjectPupil)
        {
            SubjectPupilDAL.AddSubjectPupil(subjectPupil);
        }

        static public void ModifySubjectPupil(SubjectPupil subjectPupil)
        {
            SubjectPupilDAL.ModifySubjectPupil(subjectPupil);
        }
    }
}
