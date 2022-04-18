using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DssSchoolManagement.Asp.Models;

namespace DssSchoolManagement.Asp.Services
{
    public class TeachersService
    {
        public static SqlConnection ConnectToDb()
        {    
            var connectionString = ConfigurationManager.ConnectionStrings["DBConnect"];  // "data source =.\\SQLEXPRESS; Initial Catalog = DssSchoolManagement; Integrated Security = true"; // ConfigurationManager.ConnectionStrings["DBConnect"].ToString();
            var sqlconn = new System.Data.SqlClient.SqlConnection(connectionString.ToString());
            sqlconn.Open();
            return sqlconn;
        }
        public int AddNumbers(int a, int b)
        {
            return a + b;
        }

        public int AddTeacher(TeachersModel Teacher)
        {
            int IsAdded = 0;
            try
            {

                System.Data.SqlClient.SqlConnection myConn = ConnectToDb();
                if (null != myConn)
                {

                    SqlCommand cmd = new SqlCommand("[usp_AddTeacher]", myConn);
                    cmd.CommandType = CommandType.StoredProcedure;

                     
                    SqlParameter NameParameter = cmd.Parameters.Add("@TeacherName", SqlDbType.VarChar, 50);
                    NameParameter.Direction = ParameterDirection.Input;
                    NameParameter.Value = Teacher.TeacherName;

                    SqlParameter AgeParameter = cmd.Parameters.Add("@TeacherAge", SqlDbType.Int);
                    AgeParameter.Direction = ParameterDirection.Input;
                    AgeParameter.Value = Teacher.TeacherAge;

                    SqlParameter SubjectParameter = cmd.Parameters.Add("@TeacherSubject", SqlDbType.VarChar, 50);
                    SubjectParameter.Direction = ParameterDirection.Input;
                    SubjectParameter.Value = Teacher.TeacherSubject;

                    SqlParameter ExperianceParameter = cmd.Parameters.Add("@TeacherExperiance", SqlDbType.Int);
                    ExperianceParameter.Direction = ParameterDirection.Input;
                    ExperianceParameter.Value = Teacher.TeacherExperience;

                    SqlParameter JoiningParameter = cmd.Parameters.Add("@TeacherJoiningDate", SqlDbType.Date);
                    JoiningParameter.Direction = ParameterDirection.Input;
                    JoiningParameter.Value = Teacher.TeacherJoiningdate;

                    SqlParameter EmailParameter = cmd.Parameters.Add("@TeacherEmail", SqlDbType.VarChar, 50);
                    EmailParameter.Direction = ParameterDirection.Input;
                    EmailParameter.Value = Teacher.TeacherEmail;

                    SqlParameter PhoneNumberParameter = cmd.Parameters.Add("@TeacherPhoneNumber", SqlDbType.VarChar, 50);
                    PhoneNumberParameter.Direction = ParameterDirection.Input;
                    PhoneNumberParameter.Value = Teacher.TeacherPhoneNumber;

                    SqlParameter LocationParameter = cmd.Parameters.Add("@TeacherLocation", SqlDbType.VarChar, 50);
                    LocationParameter.Direction = ParameterDirection.Input;
                    LocationParameter.Value = Teacher.TeacherLocation;


                  
                    SqlDataReader myData = cmd.ExecuteReader();
                    while (myData.Read())
                    {
                        IsAdded = (myData["result"] == DBNull.Value) ? 0 : (int)myData["result"];

                    }

                    myData.Close();
                    myConn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return IsAdded;
        }



        public int UpdateTeacher(TeachersModel Teacher)
        {
            int IsUpdated = 0;
            try
            {

                System.Data.SqlClient.SqlConnection myConn = ConnectToDb();
                if (null != myConn)
                {
                    /*
                     * @TeacherName VARCHAR(50), 	@TeacherAge INT, 	@TeacherSubject VARCHAR(50),	@TeacherExperiance INT,
	@TeacherJoiningDate DATETIME,	@TeacherEmail VARCHAR(50),	@TeacherPhoneNumber VARCHAR(50), 	@TeacherLocation VARCHAR(30)
                     * */
                    SqlCommand cmd = new SqlCommand("[usp_UpdateTeacher]", myConn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter IdParameter = cmd.Parameters.Add("@TeacherId", SqlDbType.Int);
                    IdParameter.Direction = ParameterDirection.Input;
                    IdParameter.Value = Teacher.TeacherId;
                    SqlParameter NameParameter = cmd.Parameters.Add("@TeacherName", SqlDbType.VarChar, 50);
                    NameParameter.Direction = ParameterDirection.Input;
                    NameParameter.Value = Teacher.TeacherName;

                    SqlParameter AgeParameter = cmd.Parameters.Add("@TeacherAge", SqlDbType.Int);
                    AgeParameter.Direction = ParameterDirection.Input;
                    AgeParameter.Value = Teacher.TeacherAge;

                    SqlParameter SubjectParameter = cmd.Parameters.Add("@TeacherSubject", SqlDbType.VarChar, 50);
                    SubjectParameter.Direction = ParameterDirection.Input;
                    SubjectParameter.Value = Teacher.TeacherSubject;

                    SqlParameter ExperianceParameter = cmd.Parameters.Add("@TeacherExperiance", SqlDbType.Int);
                    ExperianceParameter.Direction = ParameterDirection.Input;
                    ExperianceParameter.Value = Teacher.TeacherExperience;

                    SqlParameter JoiningParameter = cmd.Parameters.Add("@TeacherJoiningDate", SqlDbType.Int);
                    ExperianceParameter.Direction = ParameterDirection.Input;
                    ExperianceParameter.Value = Teacher.TeacherJoiningdate;

                    SqlParameter EmailParameter = cmd.Parameters.Add("@TeacherEmail", SqlDbType.VarChar, 50);
                    EmailParameter.Direction = ParameterDirection.Input;
                    EmailParameter.Value = Teacher.TeacherEmail;

                    SqlParameter PhoneNumberParameter = cmd.Parameters.Add("@TeacherPhoneNumber", SqlDbType.VarChar, 50);
                    PhoneNumberParameter.Direction = ParameterDirection.Input;
                    PhoneNumberParameter.Value = Teacher.TeacherPhoneNumber;

                    SqlParameter LocationParameter = cmd.Parameters.Add("@TeacherLocation", SqlDbType.VarChar, 50);
                    LocationParameter.Direction = ParameterDirection.Input;
                    LocationParameter.Value = Teacher.TeacherLocation;



                    SqlDataReader myData = cmd.ExecuteReader();
                    while (myData.Read())
                    {
                        IsUpdated = (myData["result"] == DBNull.Value) ? 0 : (int)myData["result"];

                    }

                    myData.Close();
                    myConn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return IsUpdated;
        }


        public List<TeachersModel> GetTeacher()
        {
            List<TeachersModel> Teachers = new List<TeachersModel>();

            try
            {

                System.Data.SqlClient.SqlConnection myConn = ConnectToDb();
                if (null != myConn)
                {

                    SqlCommand cmd = new SqlCommand("[usp_GetTeacher]", myConn);
                    cmd.CommandType = CommandType.StoredProcedure;




                    SqlDataReader myData = cmd.ExecuteReader();
                    while (myData.Read())
                    {
                        TeachersModel Teacher = new TeachersModel();
                        /* here my data is a variable that is assigned to sql data reader which gets the data from db.
                         * so here in teachers class for a variable like teacherid we are writing a logic that if(or)? mydata of teacherid 
                         * value is null in db is 0 else (or) convert teacher id in mydata to int */
                        Teacher.TeacherId = (myData["TeacherId"] == DBNull.Value) ? 0 : (int)myData["TeacherId"]; 
                        Teacher.TeacherName = (myData["TeacherName"] == DBNull.Value) ? "" : (string)myData["TeacherName"];
                        Teacher.TeacherAge = (myData["TeacherAge"] == DBNull.Value) ? 0 : (int)myData["TeacherAge"];
                        Teacher.TeacherSubject = (myData["TeacherSubject"] == DBNull.Value) ? "" : (string)myData["TeacherSubject"];
                        Teacher.TeacherExperience = (myData["TeacherExperiance"] == DBNull.Value) ? 0 : (int)myData["TeacherExperiance"];
                        Teacher.TeacherJoiningdate = (myData["TeacherJoiningDate"] == DBNull.Value) ?DateTime.Now: (DateTime)myData["TeacherJoiningDate"];
                        Teacher.TeacherEmail = (myData["TeacherEmail"] == DBNull.Value) ? "" : (string)myData["TeacherEmail"];
                        Teacher.TeacherPhoneNumber = (myData["TeacherPhoneNumber"] == DBNull.Value) ? "" : (string)myData["TeacherPhoneNumber"];
                        Teacher.TeacherLocation = (myData["TeacherLocation"] == DBNull.Value) ? "" : (string)myData["TeacherLocation"];


                        Teachers.Add(Teacher);
                    }

                    myData.Close();
                    myConn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Teachers;
        }



        public int DeleteTeacher(int TeacherId)
        {
            int IsDeleteTeacher = 0;
            try
            {

                System.Data.SqlClient.SqlConnection myConn = ConnectToDb();
                if (null != myConn)
                {

                    SqlCommand cmd = new SqlCommand("[usp_DeleteTeacher]", myConn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter nameParameter = cmd.Parameters.Add("@TeacherId", SqlDbType.Int);
                    nameParameter.Direction = ParameterDirection.Input;
                    nameParameter.Value = TeacherId;



                    SqlDataReader myData = cmd.ExecuteReader();
                    while (myData.Read())
                    {
                        IsDeleteTeacher = (myData["result"] == DBNull.Value) ? 0 : (int)myData["result"];

                    }

                    myData.Close();
                    myConn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return IsDeleteTeacher;
        }
    }
}