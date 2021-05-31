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
    class ClassDAL
    {
        static public ObservableCollection<Class> GetAllClass()
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetAllClass", con);
                ObservableCollection<Class> result = new ObservableCollection<Class>();
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    result.Add(new Class()
                    {
                        ClassID = reader["id_class"] as int?,
                        Group = reader["group"].ToString(),
                        Specialization = reader["specialization"].ToString(),
                        ProfessorID = reader["homeroom_teacher"] as int?,
                        Year = reader["year"] as int?,
                    });
                }
                reader.Close();
                return result;
            }
        }

        static public void ModifyClass(Class c)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifyClass", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@id_class", c.ClassID));
                cmd.Parameters.Add(new SqlParameter("@homeroom_teacher", c.ProfessorID));
                cmd.Parameters.Add(new SqlParameter("@group", c.Group));
                cmd.Parameters.Add(new SqlParameter("@year", c.Year));
                cmd.Parameters.Add(new SqlParameter("@specialization", c.Specialization));

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        static public Class GetClassAtIndex(int? id)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetClassAtIndex", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@id_class", id));

                Class c;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    c = new Class()
                    {
                        ClassID = reader["id_class"] as int?,
                        Group = reader["group"].ToString(),
                        Specialization = reader["specialization"].ToString(),
                        ProfessorID = reader["homeroom_teacher"] as int?,
                        Year = reader["year"] as int?,
                    };
                    reader.Close();
                    return c;
                }
                reader.Close();
                return new Class();
            }
        }
    }
}
