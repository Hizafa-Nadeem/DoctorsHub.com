using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

namespace db_connectivity.Models
{
    public class CRUD
    {
        public static string connectionString = "data source=localhost; Initial Catalog=doctorshub;Integrated Security=true";


        public static int Login(String uid, String password, String doc)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("checklogindetails", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@inputid", SqlDbType.NVarChar, 50).Value = uid;
                cmd.Parameters.Add("@inputpass", SqlDbType.NVarChar, 50).Value = password;
                if (doc == "doctor")
                {
                    cmd.Parameters.Add("@inputtype", SqlDbType.NVarChar, 50).Value = 1;
                }
                else if (doc == "patient")
                {
                    cmd.Parameters.Add("@inputtype", SqlDbType.NVarChar, 50).Value = 0;
                }
                else
                {
                    cmd.Parameters.Add("@inputtype", SqlDbType.NVarChar, 50).Value = 2;
                }

                cmd.Parameters.Add("@flag", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@flag"].Value);



            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }
       /* public static int AddAvailibility(int uid, String date, String time)*/
        public static int AddAvailibility(String uid, String date, String time)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("AddAvailibility", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@DocID", SqlDbType.NVarChar, 50).Value = uid;
                cmd.Parameters.Add("@Date5", SqlDbType.NVarChar, 50).Value = date;
                cmd.Parameters.Add("@Time5", SqlDbType.NVarChar, 50).Value = time;

                cmd.Parameters.Add("@flag", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@flag"].Value);
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }
        public static int DropAvailibility(String uid,String id)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("cancelavalibility6", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@docid", SqlDbType.NVarChar, 50).Value = uid;
                cmd.Parameters.Add("@availid", SqlDbType.NVarChar, 50).Value = id;

                cmd.Parameters.Add("@flag", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@flag"].Value);
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }
        public static int EPass(String uid,String doc, String pass, String pass2,String rpass)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("editpassword1", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.NVarChar, 50).Value = uid;

                cmd.Parameters.Add("@oldpass", SqlDbType.NVarChar, 50).Value = pass;
                if (doc == "doctor")
                {
                    cmd.Parameters.Add("@isdoc", SqlDbType.NVarChar, 50).Value = 1;
                }
                else
                {
                    cmd.Parameters.Add("@isdoc", SqlDbType.NVarChar, 50).Value = 0;
                }
                cmd.Parameters.Add("@pass2", SqlDbType.NVarChar, 50).Value = pass2;
                cmd.Parameters.Add("@pass", SqlDbType.NVarChar, 50).Value = rpass;
                cmd.Parameters.Add("@flag", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@flag"].Value);
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }
        public static int ECon(String uid, String contact, String doc)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("editContact", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.NVarChar, 50).Value = uid;
                
                cmd.Parameters.Add("@contact", SqlDbType.NVarChar, 50).Value = contact;
                if (doc == "doctor")
                {
                    cmd.Parameters.Add("@isdoc", SqlDbType.NVarChar, 50).Value = 1;
                }
                else
                {
                    cmd.Parameters.Add("@isdoc", SqlDbType.NVarChar, 50).Value = 0;
                }

                cmd.Parameters.Add("@flag", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@flag"].Value);
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }
        public static int EEmail(String uid, String email, String doc)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("editEmail", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.NVarChar, 50).Value = uid;

                cmd.Parameters.Add("@email", SqlDbType.NVarChar, 50).Value = email;
                if (doc == "doctor")
                {
                    cmd.Parameters.Add("@isdoc", SqlDbType.NVarChar, 50).Value = 1;
                }
                else
                {
                    cmd.Parameters.Add("@isdoc", SqlDbType.NVarChar, 50).Value = 0;
                }

                cmd.Parameters.Add("@flag", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@flag"].Value);
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }
        public static int DelRemin(String uid, String rid)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("deletereminderrr", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@pid", SqlDbType.NVarChar, 50).Value = uid;

                cmd.Parameters.Add("@rid", SqlDbType.NVarChar, 50).Value = rid;
                
                cmd.Parameters.Add("@flag", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@flag"].Value);
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }
        public static int ERes(String uid, String res, String doc)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("editResidence", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.NVarChar, 50).Value = uid;

                cmd.Parameters.Add("@res", SqlDbType.NVarChar, 50).Value = res;
                if (doc == "doctor")
                {
                    cmd.Parameters.Add("@isdoc", SqlDbType.NVarChar, 50).Value = 1;
                }
                else if (doc == "patient")
                {
                    cmd.Parameters.Add("@isdoc", SqlDbType.NVarChar, 50).Value = 0;
                }

                cmd.Parameters.Add("@flag", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@flag"].Value);
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }
        public static int AddSpeciality(String uid, String speciality)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("AddSpeciality", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@ID", SqlDbType.NVarChar, 50).Value = uid;
                cmd.Parameters.Add("@Qualif", SqlDbType.NVarChar, 50).Value = speciality;

                cmd.Parameters.Add("@flag", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@flag"].Value);
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }
      
        public static int Signup(String uname, String password, String repeatpassword, String email, String dob, String contact, String address, String gender, String doc)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("SignUp2", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = uname;
                cmd.Parameters.Add("@rPassword", SqlDbType.NVarChar, 50).Value = repeatpassword;
                cmd.Parameters.Add("@Contact", SqlDbType.NVarChar, 50).Value = contact;
                cmd.Parameters.Add("@Residence", SqlDbType.NVarChar, 50).Value = address;
                if (gender == "male")
                {
                    cmd.Parameters.Add("@Gender", SqlDbType.NVarChar, 50).Value = 'M';
                }
                else if (gender == "female")
                {
                    cmd.Parameters.Add("@Gender", SqlDbType.NVarChar, 50).Value = 'F';
                }
                
                cmd.Parameters.Add("@DOB", SqlDbType.NVarChar, 50).Value = dob;
                cmd.Parameters.Add("@Email", SqlDbType.NVarChar, 50).Value = email;
                cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 50).Value = password;
                if (doc == "doctor")
                {
                    cmd.Parameters.Add("@isdoc", SqlDbType.NVarChar, 50).Value = 1;
                }
                else if (doc=="patient")
                {
                    cmd.Parameters.Add("@isdoc", SqlDbType.NVarChar, 50).Value = 0;
                }

                cmd.Parameters.Add("@flag", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@flag"].Value);



            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }
        /*public static List<patient> patProfile(int uid)*/
        public static List<patient> patProfile(String uid)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("getPatient", con);
                //int t = uid;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.NVarChar, 50).Value = uid;
                cmd.Parameters.Add("@flag", SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataReader rdr = cmd.ExecuteReader();

                List<patient> list = new List<patient>();
                while (rdr.Read())
                {
                    patient user = new patient();

                    user.uid = rdr["PatientID"].ToString();
                    user.name = rdr["Name"].ToString();
                    user.gender = rdr["Gender"].ToString();
                    user.dob = rdr["DOB"].ToString();
                    user.contact = rdr["Contact"].ToString();
                    user.email = rdr["Email"].ToString();
                    user.residence = rdr["Residence"].ToString();
                    
                    // user.qualification = rdr["Qualification"].ToString();
                    list.Add(user);
                }
                rdr.Close();
                con.Close();

                return list;


            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;
            }
        }
        /*public static List<patappoin> patAppoin(int uid)*/
        public static List<patappoin> patAppoin(String uid)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("DisplayAppointmentss", con);
                //int t = uid;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@inputPatID", SqlDbType.NVarChar, 50).Value = uid;
                cmd.Parameters.Add("@flag", SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataReader rdr = cmd.ExecuteReader();

                List<patappoin> list = new List<patappoin>();
                int result = Convert.ToInt32(cmd.Parameters["@flag"].Value);
                if (result != 2)
                {
                    while (rdr.Read())
                    {
                        patappoin user = new patappoin();

                        user.apid = rdr["AppointmentID"].ToString();
                        user.date = rdr["Date"].ToString();
                        user.time = rdr["Time"].ToString();
                        user.did = rdr["DoctorID"].ToString();

                        // user.qualification = rdr["Qualification"].ToString();
                        list.Add(user);
                    }
                }
                rdr.Close();
                con.Close();

                return list;


            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;
            }
        }
        public static List<reminder> MyRemin(String uid)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("displayreminderdata", con); 
                //int t = uid;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@pid", SqlDbType.NVarChar, 50).Value = uid;
                cmd.Parameters.Add("@flag", SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataReader rdr = cmd.ExecuteReader();

                List<reminder> list = new List<reminder>();
                int result = Convert.ToInt32(cmd.Parameters["@flag"].Value);
                if (result != 2)
                {
                    while (rdr.Read())
                    {
                        reminder user = new reminder();

                        user.rid = rdr["reminderid"].ToString();
                        user.date = rdr["date"].ToString();
                        user.time = rdr["time"].ToString();
                        user.desc = rdr["description"].ToString();

                        // user.qualification = rdr["Qualification"].ToString();
                        list.Add(user);
                    }
                }
                rdr.Close();
                con.Close();

                return list;


            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;
            }
        }
       /* public static List<doctor> docProfile(int uid)*/
        public static List<doctor> docProfile(String uid)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("DoctorsProfile", con);
                
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@doctorid", SqlDbType.NVarChar, 50).Value =uid;
                cmd.Parameters.Add("@flag", SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataReader rdr = cmd.ExecuteReader();

                List<doctor> list = new List<doctor>();
                while (rdr.Read())
                {
                    doctor user = new doctor();

                    user.uid = rdr["DoctorID"].ToString();
                    user.name = rdr["Name"].ToString();
                    user.gender = rdr["Gender"].ToString();
                    user.dob = rdr["DOB"].ToString();
                    user.contact = rdr["Contact"].ToString();
                    user.email = rdr["Email"].ToString();
                    user.residence = rdr["Residence"].ToString();
                    user.rating = rdr["Rating"].ToString();
                   // user.qualification = rdr["Qualification"].ToString();
                    list.Add(user);
                }
                rdr.Close();
                con.Close();

                return list;


            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;
            }
        }
        /*public static List<string> Speciality(int uid)*/
        public static List<string> Speciality(String uid)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("allspeciality", con);
                //int t = uid;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@doctorid", SqlDbType.NVarChar, 50).Value = uid;
                cmd.Parameters.Add("@flag", SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataReader rdr = cmd.ExecuteReader();

                List<string> list = new List<string>();
                while (rdr.Read())
                {
                    string user;

                    user= rdr["Qualification"].ToString();
                    // user.qualification = rdr["Qualification"].ToString();
                    list.Add(user);
                }
                rdr.Close();
                con.Close();

                return list;
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;
            }
        }
        /*public static List<docappoin> DocAppoin(int uid)*/
        public static List<docappoin> DocAppoin(String uid)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("allappointmenttt", con);
               /*int t = uid;*/
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@doctorid", SqlDbType.NVarChar, 50).Value = uid;
                cmd.Parameters.Add("@flag", SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataReader rdr = cmd.ExecuteReader();

                List<docappoin> list = new List<docappoin>();
                while (rdr.Read())
                {
                    docappoin user=new docappoin();

                    user.apid = rdr["AppointmentID"].ToString();
                    user.pid = rdr["PatientID"].ToString();
                   /* user.avid = rdr["AvailibilityID"].ToString();*/
                    // user.qualification = rdr["Qualification"].ToString();
                    list.Add(user);
                }
                rdr.Close();
                con.Close();

                return list;
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;
            }
        }
        /*public static List<docavail> DocAvail(int uid)*/
        public static List<docavail> DocAvail(String uid)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("allavailibilityA", con);
               /* int t = uid;*/
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@doctorid", SqlDbType.NVarChar, 50).Value = uid;
                cmd.Parameters.Add("@flag", SqlDbType.Int).Direction = ParameterDirection.Output;
                SqlDataReader rdr = cmd.ExecuteReader();

                List<docavail> list = new List<docavail>();
                while (rdr.Read())
                {
                    docavail user=new docavail();

                    user.aid = rdr["AvailibilityID"].ToString();
                    user.date = rdr["Date"].ToString();
                    user.time = rdr["Time"].ToString();
                    user.status = rdr["Status"].ToString();
                    // user.qualification = rdr["Qualification"].ToString();
                    list.Add(user);
                }
                rdr.Close();
                con.Close();

                return list;
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;
            }
        }
        public static int CheckHistory1(String pid)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("patienthistory_info", con);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@patientid", SqlDbType.NVarChar, 50).Value = pid;
                cmd.Parameters.Add("@flag", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@flag"].Value);



            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }
        
        public static int CheckHistory12(int pid)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("patienthistory_info", con);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@patientid", SqlDbType.NVarChar, 50).Value = pid;
                cmd.Parameters.Add("@flag", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@flag"].Value);



            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }
       /* public static List<PHistory> CheckHistory(int pid)*/
        public static List<PHistory> CheckHistory(String pid)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("patienthistory_info", con);
                
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@patientid", SqlDbType.NVarChar, 50).Value = pid;
                cmd.Parameters.Add("@flag", SqlDbType.Int).Direction = ParameterDirection.Output;
                //result = Convert.ToInt32(cmd.Parameters["@flag"].Value);
                SqlDataReader rdr = cmd.ExecuteReader();

                List<PHistory> list = new List<PHistory>();
                while (rdr.Read())
                {
                    PHistory user = new PHistory();

                    user.uid = rdr["PatientID"].ToString();
                    user.name = rdr["Name"].ToString();
                    user.gender = rdr["Gender"].ToString();
                    user.dob = rdr["DOB"].ToString();
                    user.contact = rdr["Contact"].ToString();
                    user.email = rdr["Email"].ToString();
                    user.residence = rdr["Residence"].ToString();
                    user.aid = rdr["AppointmentID"].ToString();
                    user.dname = rdr["name"].ToString();
                    user.description = rdr["description"].ToString();
                    // user.qualification = rdr["Qualification"].ToString();
                    list.Add(user);
                }
                rdr.Close();
                con.Close();

                return list;


            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;
            }
        }
        public static int CheckDoc1(String pid)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("DoctorsProfile", con);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@doctorid", SqlDbType.NVarChar, 50).Value = pid;
                cmd.Parameters.Add("@flag", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@flag"].Value);



            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }
        public static List<doctor> CheckDoc(String pid)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("DoctorsProfile", con);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@doctorid", SqlDbType.NVarChar, 50).Value = pid;
                cmd.Parameters.Add("@flag", SqlDbType.Int).Direction = ParameterDirection.Output;
                //result = Convert.ToInt32(cmd.Parameters["@flag"].Value);
                SqlDataReader rdr = cmd.ExecuteReader();

                List<doctor> list = new List<doctor>();
                while (rdr.Read())
                {
                    doctor user = new doctor();

                    user.uid = rdr["DoctorID"].ToString();
                    user.name = rdr["Name"].ToString();
                    user.gender = rdr["Gender"].ToString();
                    user.dob = rdr["DOB"].ToString();
                    user.contact = rdr["Contact"].ToString();
                    user.email = rdr["Email"].ToString();
                    user.residence = rdr["Residence"].ToString();
                    user.rating = rdr["Rating"].ToString();
               
                    // user.qualification = rdr["Qualification"].ToString();
                    list.Add(user);
                }
                rdr.Close();
                con.Close();

                return list;


            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;
            }
        }
        public static int CheckDocSpec1(String pid)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("Doctors_Acc_Speciality", con);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@inputspeciality", SqlDbType.NVarChar, 50).Value = pid;
                cmd.Parameters.Add("@flag", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@flag"].Value);



            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }
        public static List<doctor> CheckDocSpec(String pid)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("Doctors_Acc_Speciality", con);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@inputspeciality", SqlDbType.NVarChar, 50).Value = pid;
                cmd.Parameters.Add("@flag", SqlDbType.Int).Direction = ParameterDirection.Output;
                //result = Convert.ToInt32(cmd.Parameters["@flag"].Value);
                SqlDataReader rdr = cmd.ExecuteReader();

                List<doctor> list = new List<doctor>();
                while (rdr.Read())
                {
                    doctor user = new doctor();

                    user.uid = rdr["DoctorID"].ToString();
                    user.name = rdr["Name"].ToString();
                    user.gender = rdr["Gender"].ToString();
                    user.dob = rdr["DOB"].ToString();
                    user.contact = rdr["Contact"].ToString();
                    user.email = rdr["Email"].ToString();
                    user.residence = rdr["Residence"].ToString();
                    user.rating = rdr["Rating"].ToString();

                    // user.qualification = rdr["Qualification"].ToString();
                    list.Add(user);
                }
                rdr.Close();
                con.Close();

                return list;


            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;
            }
        }
        public static int CheckDocHigh1(String pid)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("HighestRatedDoctor", con);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@speciality", SqlDbType.NVarChar, 50).Value = pid;
                cmd.Parameters.Add("@flag", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@flag"].Value);



            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }
        public static List<doctor> CheckDocHigh(String pid)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("HighestRatedDoctor", con);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@speciality", SqlDbType.NVarChar, 50).Value = pid;
                cmd.Parameters.Add("@flag", SqlDbType.Int).Direction = ParameterDirection.Output;
                //result = Convert.ToInt32(cmd.Parameters["@flag"].Value);
                SqlDataReader rdr = cmd.ExecuteReader();

                List<doctor> list = new List<doctor>();
                while (rdr.Read())
                {
                    doctor user = new doctor();

                    user.uid = rdr["DoctorID"].ToString();
                    user.name = rdr["Name"].ToString();
                    user.gender = rdr["Gender"].ToString();
                    user.dob = rdr["DOB"].ToString();
                    user.contact = rdr["Contact"].ToString();
                    user.email = rdr["Email"].ToString();
                    user.residence = rdr["Residence"].ToString();
                    user.rating = rdr["Rating"].ToString();

                    // user.qualification = rdr["Qualification"].ToString();
                    list.Add(user);
                }
                rdr.Close();
                con.Close();

                return list;


            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;
            }
        }
        public static int Feedback(String pid,String aid,String rating,String desc)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("GiveFeedback", con);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@pat", SqlDbType.NVarChar, 50).Value = pid;
                cmd.Parameters.Add("@AppointmentID", SqlDbType.NVarChar, 50).Value = aid;
                cmd.Parameters.Add("@Comment", SqlDbType.NVarChar, 50).Value = desc;
                cmd.Parameters.Add("@Rating", SqlDbType.NVarChar, 50).Value = rating;
                cmd.Parameters.Add("@flag", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@flag"].Value);



            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }
        public static int MedRemin(String pid, String date, String time, String desc)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("addreminder", con);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@patientid", SqlDbType.NVarChar, 50).Value = pid;
                cmd.Parameters.Add("@date", SqlDbType.NVarChar, 50).Value = date;
                cmd.Parameters.Add("@time", SqlDbType.NVarChar, 50).Value = time;
                cmd.Parameters.Add("@description", SqlDbType.NVarChar, 50).Value = desc;
                cmd.Parameters.Add("@flag", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@flag"].Value);



            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }
        public static int History(String pid, String aid, String desc)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("addhistory", con);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@pat", SqlDbType.NVarChar, 50).Value = pid;
                cmd.Parameters.Add("@ID", SqlDbType.NVarChar, 50).Value = aid;
                cmd.Parameters.Add("@Descrip", SqlDbType.NVarChar, 50).Value = desc;
                cmd.Parameters.Add("@flag", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@flag"].Value);



            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }
        public static int DocAvail2(String pid)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("docAvail", con);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@docid", SqlDbType.NVarChar, 50).Value = pid;
                cmd.Parameters.Add("@flag", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@flag"].Value);



            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }
        public static List<docavail> DocAvail3(String pid)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("docAvail", con);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@docid", SqlDbType.NVarChar, 50).Value = pid;
                cmd.Parameters.Add("@flag", SqlDbType.Int).Direction = ParameterDirection.Output;
                //result = Convert.ToInt32(cmd.Parameters["@flag"].Value);
                SqlDataReader rdr = cmd.ExecuteReader();

                List<docavail> list = new List<docavail>();
                while (rdr.Read())
                {
                    docavail user = new docavail();

                    user.aid = rdr["AvailibilityID"].ToString();
                    user.date = rdr["Date"].ToString();
                    user.time = rdr["Time"].ToString();
                    user.status = rdr["Status"].ToString();
               
                    // user.qualification = rdr["Qualification"].ToString();
                    list.Add(user);
                }
                cmd = new SqlCommand("docAvail2", con);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@docid", SqlDbType.NVarChar, 50).Value = pid;
                cmd.Parameters.Add("@flag", SqlDbType.Int).Direction = ParameterDirection.Output;
                //result = Convert.ToInt32(cmd.Parameters["@flag"].Value);
                rdr.Close();
                SqlDataReader rdr2 = cmd.ExecuteReader();

                //List<docavail> list = new List<docavail>();
                while (rdr2.Read())
                {
                    docavail user = new docavail();

                    user.aid = rdr2["AvailibilityID"].ToString();
                    user.date = rdr2["Date"].ToString();
                    user.time = rdr2["Time"].ToString();
                    user.status = rdr2["Status"].ToString();

                    // user.qualification = rdr["Qualification"].ToString();
                    list.Add(user);
                }
                rdr.Close();
                con.Close();

                return list;


            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;
            }
        }
        public static int BookApp(String uid,String aid)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("bookappointment4", con);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@patient", SqlDbType.NVarChar, 50).Value = uid;
                cmd.Parameters.Add("@availibility", SqlDbType.NVarChar, 50).Value = aid;
                cmd.Parameters.Add("@flag", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@flag"].Value);



            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }
        public static int ReBookApp(String uid, String aid)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("cancel_appointment6", con);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.NVarChar, 50).Value = uid;
                cmd.Parameters.Add("@appointment", SqlDbType.NVarChar, 50).Value = aid;
                cmd.Parameters.Add("@flag12", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@flag12"].Value);



            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }
        public static int WList(String uid, String aid)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("insert_waiting_list2", con);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@patient", SqlDbType.NVarChar, 50).Value = uid;
                cmd.Parameters.Add("@availability", SqlDbType.NVarChar, 50).Value = aid;
                cmd.Parameters.Add("@flag9", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@flag9"].Value);



            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }
        public static List<message> recentmessages(String id,String isdoc)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("idmeaasge", con);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.NVarChar, 50).Value = id;
                if (isdoc == "doctor")
                {
                    cmd.Parameters.Add("@isdoc", SqlDbType.NVarChar, 50).Value = 1;
                }
                else
                {
                    cmd.Parameters.Add("@isdoc", SqlDbType.NVarChar, 50).Value = 0;
                }
                cmd.Parameters.Add("@flag", SqlDbType.Int).Direction = ParameterDirection.Output;
                //result = Convert.ToInt32(cmd.Parameters["@flag"].Value);
                SqlDataReader rdr = cmd.ExecuteReader();

                List<message> list = new List<message>();
                while (rdr.Read())
                {
                    message user = new message();
                    if (isdoc == "doctor")
                    {
                        user.id = rdr["PatientID"].ToString();
                        user.name = rdr["Name"].ToString();
                        user.comment = rdr["Comment"].ToString();
                    }
                    else
                    {
                        user.id = rdr["DoctorID"].ToString();
                        user.name = rdr["Name"].ToString();
                        user.comment = rdr["Comment"].ToString();
                    }


                    // user.qualification = rdr["Qualification"].ToString();
                    list.Add(user);
                }
                rdr.Close();
                con.Close();

                return list;


            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;
            }
        }
        public static List<message> searchchat(String pid,String did, String isdoc)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("searchchat", con);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@pid", SqlDbType.NVarChar, 50).Value = pid;
                cmd.Parameters.Add("@did", SqlDbType.NVarChar, 50).Value = did;
                if (isdoc == "doctor")
                {
                    cmd.Parameters.Add("@isdoc", SqlDbType.NVarChar, 50).Value = 1;
                }
                else
                {
                    cmd.Parameters.Add("@isdoc", SqlDbType.NVarChar, 50).Value = 0;
                }
                cmd.Parameters.Add("@flag", SqlDbType.Int).Direction = ParameterDirection.Output;
                //result = Convert.ToInt32(cmd.Parameters["@flag"].Value);
                SqlDataReader rdr = cmd.ExecuteReader();

                List<message> list = new List<message>();
                while (rdr.Read())
                {
                    message user = new message();
                    if (isdoc == "doctor")
                    {
                        user.id = rdr["PatientID"].ToString();
                        user.name = rdr["Name"].ToString();
                        user.comment = rdr["Comment"].ToString();
                    }
                    else
                    {
                        user.id = rdr["DoctorID"].ToString();
                        user.name = rdr["Name"].ToString();
                        user.comment = rdr["Comment"].ToString();
                    }


                    // user.qualification = rdr["Qualification"].ToString();
                    list.Add(user);
                }
                rdr.Close();
                con.Close();

                return list;


            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;
            }
        }
        public static int searchchat2(String pid, String did, String isdoc)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("searchchat", con);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@pid", SqlDbType.NVarChar, 50).Value = pid;
                cmd.Parameters.Add("@did", SqlDbType.NVarChar, 50).Value = did;
                if (isdoc == "doctor")
                {
                    cmd.Parameters.Add("@isdoc", SqlDbType.NVarChar, 50).Value = 1;
                }
                else
                {
                    cmd.Parameters.Add("@isdoc", SqlDbType.NVarChar, 50).Value = 0;
                }
                cmd.Parameters.Add("@flag", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@flag"].Value);



            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }
        public static List<chat> mychat(String pid, String did,String isdoc)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("mychat", con);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@pid", SqlDbType.NVarChar, 50).Value = pid;
                cmd.Parameters.Add("@did", SqlDbType.NVarChar, 50).Value = did;
                cmd.Parameters.Add("@flag", SqlDbType.Int).Direction = ParameterDirection.Output;
                //result = Convert.ToInt32(cmd.Parameters["@flag"].Value);
                SqlDataReader rdr = cmd.ExecuteReader();

                List<chat> list = new List<chat>();
                while (rdr.Read())
                {
                    chat user = new chat();

                    user.mid = rdr["messageid"].ToString();
                    user.pid = rdr["PatientID"].ToString();
                    user.did = rdr["DoctorID"].ToString();
                    user.comment = rdr["Comment"].ToString();
                    user.isdoc = rdr["isdoc"].ToString();
                    if (user.isdoc == "1" && isdoc == "doctor")
                    {
                        user.isdoc = "1";
                    }
                    else if (user.isdoc == "0" && isdoc == "patient")
                    {
                        user.isdoc = "1";
                    }
                    else
                    {
                        user.isdoc = "0";
                    }

                    // user.qualification = rdr["Qualification"].ToString();
                    //1 is me
                    list.Add(user);
                }
                rdr.Close();
                con.Close();

                return list;


            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;
            }
        }
        public static int sendchat(String pid, String did,String isdoc,String comment)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("messagesreply3", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@docid", SqlDbType.NVarChar, 50).Value = did;
                cmd.Parameters.Add("@patid", SqlDbType.NVarChar, 50).Value = pid;
                cmd.Parameters.Add("@comment", SqlDbType.NVarChar, 50).Value = comment;
                if (isdoc == "doctor")
                {
                    cmd.Parameters.Add("@isdoc", SqlDbType.NVarChar, 50).Value = 1;
                }
                else
                {
                    cmd.Parameters.Add("@isdoc", SqlDbType.NVarChar, 50).Value = 0;
                }
                cmd.Parameters.Add("@flag", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@flag"].Value);



            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }
    }
}