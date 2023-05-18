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
    static class PupilDAL
    {
        static public Pupil GetPupil(string username, string password)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetPupil", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramUsername = new SqlParameter("@username", username);
                cmd.Parameters.Add(paramUsername);
                SqlParameter paramPassword = new SqlParameter("@password", password);
                cmd.Parameters.Add(paramPassword);

                Pupil pupil;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    pupil = new Pupil()
                    {
                        PupilID = reader["id_pupil"] as int?,
                        FirstName = reader["first_name"].ToString(),
                        LastName = reader["last_name"].ToString(),
                        PhoneNumber = reader["phone_number"].ToString(),
                        Email = reader["email"].ToString(),
                        ClassID = reader["id_class"] as int?
                    };
                    reader.Close();
                    return pupil;
                }
                reader.Close();
                return new Pupil();
            }
        }

        static public ObservableCollection<Pupil> GetPupilsAtSubject(int? id)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetPupilsAtSubject", con);
                ObservableCollection<Pupil> result = new ObservableCollection<Pupil>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramID = new SqlParameter("@id_subject", id);
                cmd.Parameters.Add(paramID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                            new Pupil()
                            {
                                ClassID = reader["id_class"] as int?,
                                PupilID = reader["id_pupil"] as int?,
                                Email = reader["email"].ToString(),
                                FirstName = reader["first_name"].ToString(),
                                LastName = reader["last_name"].ToString(),
                                PhoneNumber = reader["phone_number"].ToString()
                            }
                        );
                }
                reader.Close();
                return result;
            }
        }

        static public ObservableCollection<Pupil> GetPupilInClass(int? id)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetPupilInClass", con);
                ObservableCollection<Pupil> result = new ObservableCollection<Pupil>();
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@id_class", id));

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(
                            new Pupil()
                            {
                                ClassID = reader["id_class"] as int?,
                                PupilID = reader["id_pupil"] as int?,
                                Email = reader["email"].ToString(),
                                FirstName = reader["first_name"].ToString(),
                                LastName = reader["last_name"].ToString(),
                                PhoneNumber = reader["phone_number"].ToString()
                            }
                        );
                }
                reader.Close();
                return result;
            }
        }

        static public Pupil GetPupilAtIndex(int? id)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetPupilAtIndex", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@id_pupil", id));

                Pupil pupil;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    pupil = new Pupil()
                    {
                        PupilID = reader["id_pupil"] as int?,
                        FirstName = reader["first_name"].ToString(),
                        LastName = reader["last_name"].ToString(),
                        PhoneNumber = reader["phone_number"].ToString(),
                        Email = reader["email"].ToString(),
                        ClassID = reader["id_class"] as int?
                    };
                    reader.Close();
                    return pupil;
                }
                reader.Close();
                return new Pupil();
            }
        }

        static public ObservableCollection<Tuple<Pupil, string, string>> GetAllPupil()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetAllPupil", con);
                ObservableCollection<Tuple<Pupil, string, string>> result =
                    new ObservableCollection<Tuple<Pupil, string, string>>();
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new Tuple<Pupil, string, string>(
                            new Pupil()
                            {
                                ClassID = reader["id_class"] as int?,
                                PupilID = reader["id_pupil"] as int?,
                                Email = reader["email"].ToString(),
                                FirstName = reader["first_name"].ToString(),
                                LastName = reader["last_name"].ToString(),
                                PhoneNumber = reader["phone_number"].ToString()
                            },
                            reader["username"].ToString(),
                            reader["password"].ToString()
                            )
                        );
                }
                reader.Close();
                return result;
            }
        }

        static public void ModifyPupil(Tuple<Pupil, string, string> t)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifyPupil", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@id_pupil", t.Item1.PupilID));
                cmd.Parameters.Add(new SqlParameter("@first_name", t.Item1.FirstName));
                cmd.Parameters.Add(new SqlParameter("@last_name", t.Item1.LastName));
                cmd.Parameters.Add(new SqlParameter("@phone_number", t.Item1.PhoneNumber));
                cmd.Parameters.Add(new SqlParameter("@email", t.Item1.Email));
                cmd.Parameters.Add(new SqlParameter("@id_class", t.Item1.ClassID));
                cmd.Parameters.Add(new SqlParameter("@username", t.Item2));
                cmd.Parameters.Add(new SqlParameter("@password", t.Item3));

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        static public void DeletePupil(Pupil pupil)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("DeletePupil", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id_pupil", pupil.PupilID));
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        static public void AddPupil(Tuple<Pupil, string, string> t)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InsertPupil", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@first_name", t.Item1.FirstName));
                cmd.Parameters.Add(new SqlParameter("@last_name", t.Item1.LastName));
                cmd.Parameters.Add(new SqlParameter("@phone_number", t.Item1.PhoneNumber));
                cmd.Parameters.Add(new SqlParameter("@email", t.Item1.Email == null ? "" : t.Item1.Email));
                cmd.Parameters.Add(new SqlParameter("@id_class", t.Item1.ClassID));
                cmd.Parameters.Add(new SqlParameter("@username", t.Item2));
                cmd.Parameters.Add(new SqlParameter("@password", t.Item3));

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
