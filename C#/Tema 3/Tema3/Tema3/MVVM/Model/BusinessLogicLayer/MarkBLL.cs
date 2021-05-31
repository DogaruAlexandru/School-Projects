using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema3.MVVM.Model.EntityLayer;

namespace Tema3.MVVM.Model.BusinessLogicLayer
{
    static class MarkBLL
    {
        static public void AddMark(Mark mark)
        {
            MarkDAL.AddMark(mark);
        }

        static public void DeleteMark(Mark mark)
        {
            MarkDAL.DeleteMark(mark);
        }

        static public ObservableCollection<Mark> GetPupilMarksAtSubject(int? pupilID, int? subjectID)
        {
            return MarkDAL.GetPupilMarksAtSubject(pupilID, subjectID);
        }
    }
}
