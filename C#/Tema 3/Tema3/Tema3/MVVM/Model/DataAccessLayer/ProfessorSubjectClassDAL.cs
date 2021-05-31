using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tema3.MVVM.Model.EntityLayer;

namespace Tema3.MVVM.Model.DataAccessLayer
{
    static class ProfessorSubjectClassDAL
    {
        static public void ModifyProfessorSubjectClass(ProfessorSubjectClass psc)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifyProfessorSubjectClass", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@teaching_materials", psc.Teaching_materials));
                cmd.Parameters.Add(new SqlParameter("@id_professor", psc.ProfessorID));
                cmd.Parameters.Add(new SqlParameter("@id_subject", psc.SubjectID));
                cmd.Parameters.Add(new SqlParameter("@final_exam", psc.FinalExam));
                cmd.Parameters.Add(new SqlParameter("@id_class", psc.ClassID));

                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
