using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema3.MVVM.Model.DataAccessLayer;
using Tema3.MVVM.Model.EntityLayer;

namespace Tema3.MVVM.Model.BusinessLogicLayer
{
    static class ProfessorSubjectClassBLL
    {
        static public void ModifyProfessorSubjectClass(ProfessorSubjectClass psc)
        {
            ProfessorSubjectClassDAL.ModifyProfessorSubjectClass(psc);
        }
    }
}
