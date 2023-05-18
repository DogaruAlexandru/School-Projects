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
    static class ProfessorDAL
    {
        static public Professor GetProfessor(string username, string password)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetProfessor", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramUsername = new SqlParameter("@username", username);
                cmd.Parameters.Add(paramUsername);
                SqlParameter paramPassword = new SqlParameter("@password", password);
                cmd.Parameters.Add(paramPassword);

                Professor professor;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    professor = new Professor()
                    {
                        ProfessorID = reader["id_professor"] as int?,
                        FirstName = reader["first_name"].ToString(),
                        LastName = reader["last_name"].ToString(),
                        PhoneNumber = reader["phone_number"].ToString(),
                        Email = reader["email"].ToString()
                    };
                    reader.Close();
                    return professor;
                }
                reader.Close();
                return new Professor();
            }
        }

        static public Tuple<Professor, Class> GethomeroomTeacher(string username, string password)
        {
            Professor professor = GetProfessor(username, password);
            if (professor.ProfessorID != null)
            {
                using (SqlConnection con = DALHelper.Connection)
                {
                    SqlCommand cmd = new SqlCommand("[GetProfessorClass]", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter paramID = new SqlParameter("@id_professor", professor.ProfessorID);
                    cmd.Parameters.Add(paramID);

                    Class @class;
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        @class = new Class()
                        {
                            ClassID = reader["id_class"] as int?,
                            Group = reader["group"].ToString(),
                            Specialization = reader["specialization"].ToString(),
                            Year = reader["year"] as int?,
                            ProfessorID = reader["homeroom_teacher"] as int?,
                        };
                        reader.Close();
                        return new Tuple<Professor, Class>(professor, @class);
                    }
                    reader.Close();
                }
            }
            return new Tuple<Professor, Class>(professor, new Class());
        }
    }
}
