using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema3.MVVM.Model.DataAccessLayer;
using Tema3.MVVM.Model.EntityLayer;

namespace Tema3.MVVM.Model.BusinessLogicLayer
{
    static class MarkDAL
    {
        static public ObservableCollection<PupilMark> GetPupilMarks(int? id)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetPupilMarks", con);
                ObservableCollection<PupilMark> result = new ObservableCollection<PupilMark>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramID = new SqlParameter("@id_pupil", id);
                cmd.Parameters.Add(paramID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new PupilMark()
                        {
                            SubjectName = reader["subject_name"].ToString(),
                            Year = reader["year"] as int?,
                            Semester = reader["semester"] as int?,
                            DateTime = reader["date"] as DateTime?,
                            FinalExam = reader["final_exam"] as bool?,
                            HasFinalExam = reader["has_final_exam"] as bool?,
                            MarkScore = reader["mark_score"] as decimal?
                        }
                    );
                }
                reader.Close();
                return result;
            }
        }

        static public void AddMark(Mark mark)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InsertMark", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@date", mark.DateTime));
                cmd.Parameters.Add(new SqlParameter("@final_exam", mark.FinalExam));
                cmd.Parameters.Add(new SqlParameter("@mark_score", mark.MarkScore));
                cmd.Parameters.Add(new SqlParameter("@id_pupil", mark.PupilID));
                cmd.Parameters.Add(new SqlParameter("@id_subject", mark.SubjectID));

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        static public void DeleteMark(Mark mark)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeleteMark", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id_mark", mark.MarkID));
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        static public ObservableCollection<Mark> GetPupilMarksAtSubject(
            int? pupilID, int? subjectID)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetPupilMarksAtSubject", con);
                ObservableCollection<Mark> result = new ObservableCollection<Mark>();
                if (pupilID == null || subjectID == null)
                    return result;
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@id_pupil", pupilID));
                cmd.Parameters.Add(new SqlParameter("@id_subject", subjectID));

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                        new Mark()
                        {
                            FinalExam = reader["final_exam"] as bool?,
                            MarkID = reader["id_mark"] as int?,
                            MarkScore =reader["mark_score"] as decimal?,
                            PupilID = reader["id_pupil"] as int?,
                            DateTime = reader["date"] as DateTime?,
                            SubjectID = reader["id_subject"] as int?
                        });
                }
                reader.Close();
                return result;
            }
        }
    }
}
