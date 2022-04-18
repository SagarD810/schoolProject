using DssSchoolManagement.Asp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DssSchoolManagement.Asp.Services
{
    public class StudentsService
    {
        public static SqlConnection ConnectToDb()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DBConnect"].ConnectionString;
            var sqlconn = new System.Data.SqlClient.SqlConnection(connectionString);
            sqlconn.Open();
            return sqlconn;
        }
        public int AddStudent(StudentsModel students)
        {
            int IsAdded = 0;
            try
            {

                System.Data.SqlClient.SqlConnection myConn = ConnectToDb();
                if (null != myConn)
                {

                    SqlCommand cmd = new SqlCommand("[usp_AddStudent]", myConn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter NameParameter = cmd.Parameters.Add("@StudentName", SqlDbType.VarChar, 50);
                    NameParameter.Direction = ParameterDirection.Input;
                    NameParameter.Value = students.StudentName;

                    SqlParameter AgeParameter = cmd.Parameters.Add("@StudentAge", SqlDbType.BigInt);
                    AgeParameter.Direction = ParameterDirection.Input;
                    AgeParameter.Value = students.StudentAge;

                    SqlParameter LocationParameter = cmd.Parameters.Add("@StudentLocation", SqlDbType.VarChar, 30);
                    LocationParameter.Direction = ParameterDirection.Input;
                    LocationParameter.Value = students.StudentLocation;       

                    SqlParameter EmailParameter = cmd.Parameters.Add("@StudentEmail", SqlDbType.VarChar, 30);
                    EmailParameter.Direction = ParameterDirection.Input;
                    EmailParameter.Value = students.StudentEmail;

                    SqlParameter PhoneNumberParameter = cmd.Parameters.Add("@StudentPhoneNumber", SqlDbType.VarChar, 50);
                    PhoneNumberParameter.Direction = ParameterDirection.Input;
                    PhoneNumberParameter.Value = students.StudentPhoneNumber;

                  





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



        public int UpdateStudent(StudentsModel Student)
        {
            int IsUpdated = 0;
            try
            {

                System.Data.SqlClient.SqlConnection myConn = ConnectToDb();
                if (null != myConn)
                {

                    SqlCommand cmd = new SqlCommand("[usp_UpdateStudent]", myConn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter IdParameter = cmd.Parameters.Add("@StudentId", SqlDbType.Int);
                    IdParameter.Direction = ParameterDirection.Input;
                    IdParameter.Value = Student.StudentId;

                    SqlParameter NameParameter = cmd.Parameters.Add("@StudentName", SqlDbType.VarChar, 50);
                    NameParameter.Direction = ParameterDirection.Input;
                    NameParameter.Value = Student.StudentName;

                    SqlParameter AgeParameter = cmd.Parameters.Add("@StudentAge", SqlDbType.Int);
                    AgeParameter.Direction = ParameterDirection.Input;
                    AgeParameter.Value = Student.StudentAge;

                    SqlParameter LocationParameter = cmd.Parameters.Add("@StudentLocation", SqlDbType.VarChar, 50);
                    LocationParameter.Direction = ParameterDirection.Input;
                    LocationParameter.Value = Student.StudentLocation;

                    SqlParameter EmailParameter = cmd.Parameters.Add("@StudentEmail", SqlDbType.VarChar, 50);
                    EmailParameter.Direction = ParameterDirection.Input;
                    EmailParameter.Value = Student.StudentEmail;

                    SqlParameter PhoneNumberParameter = cmd.Parameters.Add("@StudentPhoneNumber", SqlDbType.VarChar, 50);
                    PhoneNumberParameter.Direction = ParameterDirection.Input;
                    PhoneNumberParameter.Value = Student.StudentPhoneNumber;

                    
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


        public List<StudentsModel> GetStudent()
        {
            List<StudentsModel> Students = new List<StudentsModel>();

            try
            {

                System.Data.SqlClient.SqlConnection myConn = ConnectToDb();
                if (null != myConn)
                {

                    SqlCommand cmd = new SqlCommand("[usp_GetStudent]", myConn);
                    cmd.CommandType = CommandType.StoredProcedure;




                    SqlDataReader myData = cmd.ExecuteReader();
                    while (myData.Read())
                    {
                        StudentsModel Student = new StudentsModel();
                        Student.StudentId = (myData["StudentId"] == DBNull.Value) ? 0 : (int)myData["StudentId"];
                        Student.StudentName = (myData["StudentName"] == DBNull.Value) ? "" : (string)myData["StudentName"];
                        Student.StudentAge = (myData["StudentAge"] == DBNull.Value) ? 0 : (int)myData["StudentAge"];
                        Student.StudentLocation = (myData["StudentLocation"] == DBNull.Value) ? "" : (string)myData["StudentLocation"];
                        Student.StudentEmail = (myData["StudentEmail"] == DBNull.Value) ? "" : (string)myData["StudentEmail"];
                        Student.StudentPhoneNumber = (myData["StudentPhoneNumber"] == DBNull.Value) ? "" : (string)myData["StudentPhoneNumber"];
                        


                        Students.Add(Student);
                    }

                    myData.Close();
                    myConn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Students;
        }



        public int DeleteStudent(int StudentId)
        {
            int IsDeleteStudent = 0;
            try
            {

                System.Data.SqlClient.SqlConnection myConn = ConnectToDb();
                if (null != myConn)
                {

                    SqlCommand cmd = new SqlCommand("[usp_DeleteStudent]", myConn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter NameParameter = cmd.Parameters.Add("@StudentId", SqlDbType.Int);
                    NameParameter.Direction = ParameterDirection.Input;
                    NameParameter.Value = StudentId;



                    SqlDataReader myData = cmd.ExecuteReader();
                    while (myData.Read())
                    {
                        IsDeleteStudent = (myData["result"] == DBNull.Value) ? 0 : (int)myData["result"];

                    }

                    myData.Close();
                    myConn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return IsDeleteStudent;
        }
    }
}