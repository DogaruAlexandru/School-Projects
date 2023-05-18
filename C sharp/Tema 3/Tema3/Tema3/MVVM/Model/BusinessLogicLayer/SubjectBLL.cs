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
    static class SubjectBLL
    {
        static public ObservableCollection<Subject> GetSubjectsAtProfessor(int? id)
        {
            return SubjectDAL.GetSubjectsAtProfessor(id);
        }

        static public ObservableCollection<Tuple<bool?, Subject>> GetSubjectsAndFinalExamAtProfessor(int? id)
        {
            return SubjectDAL.GetSubjectsAndFinalExamAtProfessor(id);
        }

        static public ObservableCollection<Tuple<bool?, Subject>> GetSubjectsOfClass(int? id)
        {
            return SubjectDAL.GetSubjectsOfClass(id);
        }
    }
}
