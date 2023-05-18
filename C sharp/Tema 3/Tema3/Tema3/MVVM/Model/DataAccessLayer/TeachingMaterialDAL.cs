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
    static class TeachingMaterialDAL
    {
        static public ObservableCollection<TeachingMaterial> GetClassTeachingMaterials(int? id)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetClassTeachingMaterials", con);
                ObservableCollection<TeachingMaterial> result = new ObservableCollection<TeachingMaterial>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramID = new SqlParameter("@id_class", id);
                cmd.Parameters.Add(paramID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(
                        new TeachingMaterial()
                        {
                            SubjectName = reader["subject_name"].ToString(),
                            Year = reader["year"] as int?,
                            Semester = reader["semester"] as int?,
                            MaterialPath = reader["teaching_materials"].ToString(),
                        }
                    );
                }
                reader.Close();
                return result;
            }
        }

        static public ObservableCollection<Tuple<Subject, ProfessorSubjectClass>> GetTeacherTeachingMaterials(int? id)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetTeacherTeachingMaterials", con);
                ObservableCollection<Tuple<Subject, ProfessorSubjectClass>> result =
                    new ObservableCollection<Tuple<Subject, ProfessorSubjectClass>>();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@id_professor", id));

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    result.Add(new Tuple<Subject, ProfessorSubjectClass>(
                            new Subject()
                            {
                                SubjectName = reader["subject_name"].ToString(),
                                Year = reader["year"] as int?,
                                Semester = reader["semester"] as int?,
                                SubjectID = reader["id_subject"] as int?
                            },
                            new ProfessorSubjectClass()
                            {
                                ClassID = reader["id_class"] as int?,
                                SubjectID = reader["id_subject"] as int?,
                                ProfessorID = reader["id_professor"] as int?,
                                FinalExam = reader["final_exam"] as bool?,
                                Teaching_materials = reader["teaching_materials"].ToString()
                            }
                        ));
                }
                reader.Close();
                return result;
            }
        }
    }
}
