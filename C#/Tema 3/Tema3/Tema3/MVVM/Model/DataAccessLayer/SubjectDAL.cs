using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema3.MVVM.Model.EntityLayer;

namespace Tema3.MVVM.Model.DataAccessLayer
{
    static class SubjectDAL
    {
        static public ObservableCollection<Subject> GetSubjectsAtProfessor(int? id)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetSubjectsAtProfessor", con);
                ObservableCollection<Subject> result = new ObservableCollection<Subject>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramID = new SqlParameter("@id_professor", id);
                cmd.Parameters.Add(paramID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                            new Subject()
                            {
                                SubjectID = reader["id_subject"] as int?,
                                SubjectName = reader["subject_name"].ToString(),
                                Year = reader["year"] as int?,
                                Semester = reader["semester"] as int?,
                            }
                        );
                }
                reader.Close();
                return result;
            }
        }

        static public ObservableCollection<Tuple<bool?, Subject>> GetSubjectsAndFinalExamAtProfessor(int? id)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetSubjectsAndFinalExamAtProfessor", con);
                ObservableCollection<Tuple<bool?, Subject>> result = new ObservableCollection<Tuple<bool?, Subject>>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramID = new SqlParameter("@id_professor", id);
                cmd.Parameters.Add(paramID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new Tuple<bool?, Subject>(
                        reader["final_exam"] as bool?,
                        new Subject()
                        {
                            SubjectID = reader["id_subject"] as int?,
                            SubjectName = reader["subject_name"].ToString(),
                            Year = reader["year"] as int?,
                            Semester = reader["semester"] as int?,
                        }));
                }
                reader.Close();
                return result;
            }
        }

        static public ObservableCollection<Tuple<bool?, Subject>> GetSubjectsOfClass(int? id)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetSubjectsOfClass", con);
                ObservableCollection<Tuple<bool?, Subject>> result =
                    new ObservableCollection<Tuple<bool?, Subject>>();
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@id_class", id));

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new Tuple<bool?, Subject>(
                        reader["final_exam"] as bool?,
                        new Subject()
                        {
                            SubjectID = reader["id_subject"] as int?,
                            SubjectName = reader["subject_name"].ToString(),
                            Year = reader["year"] as int?,
                            Semester = reader["semester"] as int?,
                        }));
                }
                reader.Close();
                return result;
            }
        }

    }
}
