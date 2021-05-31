using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema3.MVVM.Model.EntityLayer;

namespace Tema3.MVVM.Model.DataAccessLayer
{
    static class SubjectPupilDAL
    {
        static public bool? GetCalculatedMean(int? pupilID, int? subjectID)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetCalculatedMean", con);
                cmd.CommandType = CommandType.StoredProcedure;
                if (pupilID == null || subjectID == null)
                    return null;

                cmd.Parameters.Add(new SqlParameter("@id_subject", subjectID));
                cmd.Parameters.Add(new SqlParameter("@id_pupil", pupilID));

                bool? result = null;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    result = reader["calculated_mean"] as bool?;
                }
                reader.Close();
                return result;
            }
        }

        static public void AddSubjectPupil(SubjectPupil subjectPupil)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InsertSubjectPupil", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@id_pupil", subjectPupil.PupilID));
                cmd.Parameters.Add(new SqlParameter("@id_subject", subjectPupil.SubjectID));
                cmd.Parameters.Add(new SqlParameter("@calculated_mean", subjectPupil.CalculatedMean));

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        static public void ModifySubjectPupil(SubjectPupil subjectPupil)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifySubjectPupil", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@id_pupil", subjectPupil.PupilID));
                cmd.Parameters.Add(new SqlParameter("@id_subject", subjectPupil.SubjectID));
                cmd.Parameters.Add(new SqlParameter("@calculated_mean", subjectPupil.CalculatedMean));

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}