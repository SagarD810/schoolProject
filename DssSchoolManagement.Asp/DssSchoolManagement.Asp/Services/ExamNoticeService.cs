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
    public class ExamNoticeService
    {
        public static SqlConnection ConnectToDb()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DBConnect"];
            var sqlconn = new System.Data.SqlClient.SqlConnection(connectionString.ToString());
            sqlconn.Open();
            return sqlconn;
        }
        public int AddExam(ExamNoticeModel Exam)
        {
            int IsAdded = 0;
            try
            {

                System.Data.SqlClient.SqlConnection myConn = ConnectToDb();
                if (null != myConn)
                {

                    SqlCommand cmd = new SqlCommand("[usp_AddExam]", myConn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter NameParameter = cmd.Parameters.Add("@SubjectName", SqlDbType.VarChar, 50);
                    NameParameter.Direction = ParameterDirection.Input;
                    NameParameter.Value = Exam.SubjectName;

                    SqlParameter DateParameter = cmd.Parameters.Add("@ExamDate", SqlDbType.DateTime);
                    DateParameter.Direction = ParameterDirection.Input;
                    DateParameter.Value = Exam.ExamDate;

                    SqlParameter DayParameter = cmd.Parameters.Add("@ExamDay", SqlDbType.VarChar,30);
                    DayParameter.Direction = ParameterDirection.Input;
                    DayParameter.Value = Exam.ExamDay;

                    SqlParameter MarksParameter = cmd.Parameters.Add("@TotalMarks", SqlDbType.Int);
                    MarksParameter.Direction = ParameterDirection.Input;
                    MarksParameter.Value = Exam.TotalMarks;

                  
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



        public int UpdateExam(ExamNoticeModel Exam)
        {
            int IsUpdated = 0;
            try
            {

                System.Data.SqlClient.SqlConnection myConn = ConnectToDb();
                if (null != myConn)
                {

                    SqlCommand cmd = new SqlCommand("[usp_UpdateExam]", myConn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter IdParameter = cmd.Parameters.Add("@ExamId", SqlDbType.Int);
                    IdParameter.Direction = ParameterDirection.Input;
                    IdParameter.Value = Exam.ExamId;

                    SqlParameter NameParameter = cmd.Parameters.Add("@SubjectName", SqlDbType.VarChar, 50);
                    NameParameter.Direction = ParameterDirection.Input;
                    NameParameter.Value = Exam.SubjectName;

                    SqlParameter DateParameter = cmd.Parameters.Add("@ExamDate", SqlDbType.DateTime);
                    DateParameter.Direction = ParameterDirection.Input;
                    DateParameter.Value = Exam.ExamDate;

                    SqlParameter DayParameter = cmd.Parameters.Add("@ExamDay", SqlDbType.VarChar, 30);
                    DayParameter.Direction = ParameterDirection.Input;
                    DayParameter.Value = Exam.ExamDay;

                    SqlParameter MarksParameter = cmd.Parameters.Add("@TotalMarks", SqlDbType.Int);
                    MarksParameter.Direction = ParameterDirection.Input;
                    MarksParameter.Value = Exam.TotalMarks;



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


        public List<ExamNoticeModel> GetExam()
        {
            List<ExamNoticeModel> Exams = new List<ExamNoticeModel>();

            try
            {

                System.Data.SqlClient.SqlConnection myConn = ConnectToDb();
                if (null != myConn)
                {

                    SqlCommand cmd = new SqlCommand("[usp_GetExam]", myConn);
                    cmd.CommandType = CommandType.StoredProcedure;




                    SqlDataReader myData = cmd.ExecuteReader();
                    while (myData.Read())
                    {
                        ExamNoticeModel Exam = new ExamNoticeModel();
                        Exam.ExamId = (myData["AdminId"] == DBNull.Value) ? 0 : (int)myData["AdminId"];
                        Exam.SubjectName = (myData["SubjectName"] == DBNull.Value) ? "" : (string)myData["SubjectName"];
                        Exam.ExamDate = (myData["ExamDate"] == DBNull.Value) ? DateTime.Now : (DateTime)myData["ExamDate"];
                        Exam.ExamDay = (myData["ExamDay"] == DBNull.Value) ? "" : (string)myData["ExamDay"];
                        Exam.TotalMarks = (myData["TotalMarks"] == DBNull.Value) ? 0 : (int)myData["TotalMarks"];
                      

                        Exams.Add(Exam);
                    }

                    myData.Close();
                    myConn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Exams;
        }



        public int DeleteExam(int ExamId)
        {
            int IsDeleteExam = 0;
            try
            {

                System.Data.SqlClient.SqlConnection myConn = ConnectToDb();
                if (null != myConn)
                {

                    SqlCommand cmd = new SqlCommand("[usp_DeleteExam]", myConn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter nameParameter = cmd.Parameters.Add("@ExamId", SqlDbType.Int);
                    nameParameter.Direction = ParameterDirection.Input;
                    nameParameter.Value = ExamId;



                    SqlDataReader myData = cmd.ExecuteReader();
                    while (myData.Read())
                    {
                        IsDeleteExam = (myData["result"] == DBNull.Value) ? 0 : (int)myData["result"];

                    }

                    myData.Close();
                    myConn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return IsDeleteExam;
        }
    }
}