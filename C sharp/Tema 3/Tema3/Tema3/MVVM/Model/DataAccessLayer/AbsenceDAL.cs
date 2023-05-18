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
    static class AbsenceDAL
    {
        static public ObservableCollection<PupilAbsence> GetPupilAbsences(int? id)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetPupilAbsences", con);
                ObservableCollection<PupilAbsence> result = new ObservableCollection<PupilAbsence>();
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramID = new SqlParameter("@id_pupil", id);
                cmd.Parameters.Add(paramID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    bool? motivable = reader["motivable"] as bool?;
                    bool? motivated = reader["motivated"] as bool?;
                    PupilAbsence.State state;
                    if (motivable == false)
                        state = PupilAbsence.State.Unmotivable;
                    else if (motivated == true)
                        state = PupilAbsence.State.Motivated;
                    else
                        state = PupilAbsence.State.Unmotivated;

                    result.Add(
                            new PupilAbsence()
                            {
                                SubjectName = reader["subject_name"].ToString(),
                                Year = reader["year"] as int?,
                                Semester = reader["semester"] as int?,
                                DateTime = reader["date"] as DateTime?,
                                MarkState = state
                            }
                        );
                }
                reader.Close();
                return result;
            }
        }

        static public void AddAbsence(Absence absence)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("InsertAbsence", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter d = new SqlParameter("@date", absence.DateTime);
                SqlParameter p = new SqlParameter("@id_pupil", absence.PupilID);
                SqlParameter s = new SqlParameter("@id_subject", absence.SubjectID);
                bool? motivable, motivated;
                switch (absence.MarkState)
                {
                    case Absence.State.Unmotivable:
                        motivable = false;
                        motivated = false;
                        break;
                    case Absence.State.Motivated:
                        motivable = true;
                        motivated = true;
                        break;
                    case Absence.State.Unmotivated:
                        motivable = true;
                        motivated = false;
                        break;
                    default:
                        motivable = null;
                        motivated = null;
                        break;
                }
                SqlParameter mb = new SqlParameter("@motivable", motivable);
                SqlParameter mt = new SqlParameter("@motivated", motivated);

                cmd.Parameters.Add(d);
                cmd.Parameters.Add(p);
                cmd.Parameters.Add(s);
                cmd.Parameters.Add(mb);
                cmd.Parameters.Add(mt);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        static public void ModifyAbsence(Absence absence)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("ModifyAbsence", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlParameter a = new SqlParameter("@id_absence", absence.AbsenceID);
                SqlParameter d = new SqlParameter("@date", absence.DateTime);
                SqlParameter p = new SqlParameter("@id_pupil", absence.PupilID);
                SqlParameter s = new SqlParameter("@id_subject", absence.SubjectID);
                bool? motivable, motivated;
                switch (absence.MarkState)
                {
                    case Absence.State.Unmotivable:
                        motivable = false;
                        motivated = false;
                        break;
                    case Absence.State.Motivated:
                        motivable = true;
                        motivated = true;
                        break;
                    case Absence.State.Unmotivated:
                        motivable = true;
                        motivated = false;
                        break;
                    default:
                        motivable = null;
                        motivated = null;
                        break;
                }
                SqlParameter mb = new SqlParameter("@motivable", motivable);
                SqlParameter mt = new SqlParameter("@motivated", motivated);

                cmd.Parameters.Add(a);
                cmd.Parameters.Add(d);
                cmd.Parameters.Add(p);
                cmd.Parameters.Add(s);
                cmd.Parameters.Add(mb);
                cmd.Parameters.Add(mt);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        static public ObservableCollection<Absence> GetPupilAbsencesAtSubject(
            int? pupilID, int? subjectID)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetPupilAbsencesAtSubject", con);
                ObservableCollection<Absence> result = new ObservableCollection<Absence>();
                if (pupilID == null || subjectID == null)
                    return result;
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter p = new SqlParameter("@id_pupil", pupilID);
                SqlParameter s = new SqlParameter("@id_subject", subjectID);
                cmd.Parameters.Add(p);
                cmd.Parameters.Add(s);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    bool? motivable = reader["motivable"] as bool?;
                    bool? motivated = reader["motivated"] as bool?;
                    Absence.State state;
                    if (motivable == false)
                        state = Absence.State.Unmotivable;
                    else if (motivated == true)
                        state = Absence.State.Motivated;
                    else
                        state = Absence.State.Unmotivated;

                    result.Add(
                        new Absence()
                        {
                            MarkState = state,
                            AbsenceID = reader["id_absence"] as int?,
                            PupilID = reader["id_pupil"] as int?,
                            DateTime = reader["date"] as DateTime?,
                            SubjectID= reader["id_subject"] as int?
                        });
                }
                reader.Close();
                return result;
            }
        }

        static public ObservableCollection<Absence> GetPupilAllAbsences(int? id)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetPupilAllAbsences", con);
                ObservableCollection<Absence> result = new ObservableCollection<Absence>();
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@id_pupil", id));
                
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    bool? motivable = reader["motivable"] as bool?;
                    bool? motivated = reader["motivated"] as bool?;
                    Absence.State state;
                    if (motivable == false)
                        state = Absence.State.Unmotivable;
                    else if (motivated == true)
                        state = Absence.State.Motivated;
                    else
                        state = Absence.State.Unmotivated;

                    result.Add(
                            new Absence()
                            {
                                AbsenceID = reader["id_absence"] as int?,
                                PupilID = reader["id_pupil"] as int?,
                                SubjectID = reader["id_subject"] as int?,
                                DateTime = reader["date"] as DateTime?,
                                MarkState = state
                            }
                        );
                }
                reader.Close();
                return result;
            }
        }

        static public Absence GetAbsenceAtIndex(int? id)
        {
            using (SqlConnection con = DALHelper.Connection)
            {
                SqlCommand cmd = new SqlCommand("GetAbsenceAtIndex", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@id_absence", id));

                Absence a;
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    bool? motivable = reader["motivable"] as bool?;
                    bool? motivated = reader["motivated"] as bool?;
                    Absence.State state;
                    if (motivable == false)
                        state = Absence.State.Unmotivable;
                    else if (motivated == true)
                        state = Absence.State.Motivated;
                    else
                        state = Absence.State.Unmotivated;

                    a = new Absence()
                    {
                        PupilID = reader["id_pupil"] as int?,
                        AbsenceID = reader["id_absence"] as int?,
                        DateTime = reader["date"] as DateTime?,
                        SubjectID = reader["id_subject"] as int?,
                        MarkState = state
                    };
                    reader.Close();
                    return a;
                }
                reader.Close();
                return new Absence();
            }
        }
    }
}
