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
    class ClassBLL
    {
        static public ObservableCollection<Class> GetAllClass()
        {
            return ClassDAL.GetAllClass();
        }

        static public void ModifyClass(Class c)
        {
            ClassDAL.ModifyClass(c);
        }

        static public Class GetClassAtIndex(int? id)
        {
            return ClassDAL.GetClassAtIndex(id);
        }
    }
}
