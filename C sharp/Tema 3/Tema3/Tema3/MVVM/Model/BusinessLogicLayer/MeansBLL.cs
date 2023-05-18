using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema3.MVVM.Model.DataAccessLayer;
using Tema3.MVVM.Model.EntityLayer;
using Tema3.MVVM.ViewModel;

namespace Tema3.MVVM.Model.BusinessLogicLayer
{
    static class MeansBLL
    {
        static public ObservableCollection<Mean> GetPupilMeans(int? id)
        {
            ObservableCollection<PupilMark> marks;
            marks = MarkDAL.GetPupilMarks(id);

            ObservableCollection<Mean> means = new ObservableCollection<Mean>();

            int index = 0;

            string subjectName;
            int? year, semester;
            bool? finalExam, hasFinalExam;
            decimal? finalExamScore;
            while (index < marks.Count)
            {
                subjectName = marks[index].SubjectName;
                year = marks[index].Year;
                semester = marks[index].Semester;
                hasFinalExam = marks[index].HasFinalExam;
                finalExamScore = null;

                decimal? sum = 0;
                int count = 0;

                while (index < marks.Count && year == marks[index].Year &&
                    semester == marks[index].Semester && subjectName == marks[index].SubjectName)
                {

                    finalExam = marks[index].FinalExam;
                    if (hasFinalExam == true && finalExam == true)
                    {
                        finalExamScore = marks[index].MarkScore;
                        ++index;
                        continue;
                    }

                    ++count;
                    sum += marks[index].MarkScore;
                    ++index;
                }

                decimal? mean;
                if (hasFinalExam == false)
                    if (count > 1)
                        mean = sum / count;
                    else
                        mean = null;
                else
                    if (count > 2 && finalExamScore != null)
                    mean = ((sum / count) * 3 + finalExamScore) / 4;
                else
                    mean = null;
                means.Add(new Mean()
                {
                    SubjectName = subjectName,
                    Year = year,
                    Semester = semester,
                    MeanMark = mean
                });
            }
            return means;
        }

        static public decimal? GetPupilMeanAtSubject(int? pupilID, int? subjectID, bool? subjectHasFinalExam)
        {
            ObservableCollection<Mark> marks = MarkBLL.GetPupilMarksAtSubject(pupilID, subjectID);

            decimal finalExamMark = 0, sum = 0;
            int count = 0;

            if (subjectHasFinalExam == false)
            {
                foreach (Mark m in marks)
                    sum += m.MarkScore ?? default;
                if (marks.Count > 1)
                    return Math.Round(sum / marks.Count, 2);
            }
            else
                foreach (Mark m in marks)
                {
                    if (m.FinalExam == true)
                        finalExamMark = m.MarkScore ?? default;
                    else
                    {
                        sum += m.MarkScore ?? default;
                        ++count;
                    }
                }
            if (count > 2 && finalExamMark != 0)
                return ((sum / count) * 3 + finalExamMark) / 4;
            return null;
        }
    }
}
