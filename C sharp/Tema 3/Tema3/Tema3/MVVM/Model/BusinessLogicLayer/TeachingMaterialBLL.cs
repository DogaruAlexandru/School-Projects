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
    static class TeachingMaterialBLL
    {
        static public ObservableCollection<Tuple<Subject, ProfessorSubjectClass>> GetTeacherTeachingMaterials(int? id)
        {
            return TeachingMaterialDAL.GetTeacherTeachingMaterials(id);
        }
    }
}
