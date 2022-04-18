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
    public class AdminsService
    {
        public static SqlConnection ConnectToDb()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["DBConnect"].ConnectionString;
            var sqlconn = new System.Data.SqlClient.SqlConnection(connectionString);
            sqlconn.Open();
            return sqlconn;
        }
        public int AddAdmin(AdminsModel Admin)
        {
            int IsAdded = 0;
            try
            {

                System.Data.SqlClient.SqlConnection myConn = ConnectToDb();
                if (null != myConn)
                {

                    SqlCommand cmd = new SqlCommand("[usp_AddAdmin]", myConn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter NameParameter = cmd.Parameters.Add("@AdminName", SqlDbType.VarChar, 50);
                    NameParameter.Direction = ParameterDirection.Input;
                    NameParameter.Value = Admin.AdminName;

                    SqlParameter AgeParameter = cmd.Parameters.Add("@AdminAge", SqlDbType.Int);
                    AgeParameter.Direction = ParameterDirection.Input;
                    AgeParameter.Value = Admin.AdminAge;

                    SqlParameter ExperianceParameter = cmd.Parameters.Add("@AdminExperiance", SqlDbType.Int);
                    ExperianceParameter.Direction = ParameterDirection.Input;
                    ExperianceParameter.Value = Admin.AdminExperiance;

                    SqlParameter EmailParameter = cmd.Parameters.Add("@AdminEmail", SqlDbType.VarChar, 50);
                    EmailParameter.Direction = ParameterDirection.Input;
                    EmailParameter.Value = Admin.AdminEmail;

                    SqlParameter PhoneNumberParameter = cmd.Parameters.Add("@AdminPhoneNumber", SqlDbType.VarChar, 50);
                    PhoneNumberParameter.Direction = ParameterDirection.Input;
                    PhoneNumberParameter.Value = Admin.AdminPhoneNumber;

                    SqlParameter DesignationParameter = cmd.Parameters.Add("@AdminDesignation", SqlDbType.VarChar, 50);
                    DesignationParameter.Direction = ParameterDirection.Input;
                    DesignationParameter.Value = Admin.AdminDesignation;





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



        public int UpdateAdmin(AdminsModel Admin)
        {
            int IsUpdated = 0;
            try
            {

                System.Data.SqlClient.SqlConnection myConn = ConnectToDb();
                if (null != myConn)
                {

                    SqlCommand cmd = new SqlCommand("[usp_UpdateAdmin]", myConn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter IdParameter = cmd.Parameters.Add("@AdminId", SqlDbType.Int);
                    IdParameter.Direction = ParameterDirection.Input;
                    IdParameter.Value = Admin.AdminId;

                    SqlParameter NameParameter = cmd.Parameters.Add("@AdminName", SqlDbType.VarChar, 50);
                    NameParameter.Direction = ParameterDirection.Input;
                    NameParameter.Value = Admin.AdminName;

                    SqlParameter AgeParameter = cmd.Parameters.Add("@AdminAge", SqlDbType.Int);
                    AgeParameter.Direction = ParameterDirection.Input;
                    AgeParameter.Value = Admin.AdminAge;

                    SqlParameter ExperianceParameter = cmd.Parameters.Add("@AdminExperiance", SqlDbType.Int);
                    ExperianceParameter.Direction = ParameterDirection.Input;
                    ExperianceParameter.Value = Admin.AdminExperiance;

                    SqlParameter EmailParameter = cmd.Parameters.Add("@AdminEmail", SqlDbType.VarChar, 50);
                    EmailParameter.Direction = ParameterDirection.Input;
                    EmailParameter.Value = Admin.AdminEmail;

                    SqlParameter PhoneNumberParameter = cmd.Parameters.Add("@AdminPhoneNumber", SqlDbType.VarChar, 50);
                    PhoneNumberParameter.Direction = ParameterDirection.Input;
                    PhoneNumberParameter.Value = Admin.AdminPhoneNumber;

                    SqlParameter DesignationParameter = cmd.Parameters.Add("@AdminDesignation", SqlDbType.VarChar, 50);
                    DesignationParameter.Direction = ParameterDirection.Input;
                    DesignationParameter.Value = Admin.AdminDesignation;



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


        public List<AdminsModel> GetAdmin()
        {
            List<AdminsModel> Admins= new List<AdminsModel>();

            try
            {

                System.Data.SqlClient.SqlConnection myConn = ConnectToDb();
                if (null != myConn)
                {

                    SqlCommand cmd = new SqlCommand("[usp_GetAdmin]", myConn);
                    cmd.CommandType = CommandType.StoredProcedure;




                    SqlDataReader myData = cmd.ExecuteReader();
                    while (myData.Read())
                    {
                        AdminsModel Admin = new AdminsModel();
                        Admin.AdminId = (myData["AdminId"] == DBNull.Value) ? 0 : (int)myData["AdminId"];
                        Admin.AdminName = (myData["AdminName"] == DBNull.Value) ? "" : (string)myData["AdminName"];
                        Admin.AdminAge = (myData["AdminAge"] == DBNull.Value) ? 0 : (int)myData["AdminAge"];
                        Admin.AdminExperiance = (myData["AdminExperiance"] == DBNull.Value) ? 0 : (int)myData["AdminExperiance"];
                        Admin.AdminEmail = (myData["AdminEmail"] == DBNull.Value) ? "" : (string)myData["AdminEmail"];
                        Admin.AdminPhoneNumber = (myData["AdminPhoneNumber"] == DBNull.Value) ? "" : (string)myData["AdminPhoneNumber"];
                        Admin.AdminDesignation = (myData["AdminDesignation"] == DBNull.Value) ? "" : (string)myData["AdminDesignation"];


                        Admins.Add(Admin);
                    }

                    myData.Close();
                    myConn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return Admins;
        }



        public int DeleteAdmin(int AdminId)
        {
            int IsDeleteAdmin = 0;
            try
            {

                System.Data.SqlClient.SqlConnection myConn = ConnectToDb();
                if (null != myConn)
                {

                    SqlCommand cmd = new SqlCommand("[usp_DeleteTeacher]", myConn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter nameParameter = cmd.Parameters.Add("@AdminId", SqlDbType.Int);
                    nameParameter.Direction = ParameterDirection.Input;
                    nameParameter.Value = AdminId;



                    SqlDataReader myData = cmd.ExecuteReader();
                    while (myData.Read())
                    {
                        IsDeleteAdmin = (myData["result"] == DBNull.Value) ? 0 : (int)myData["result"];

                    }

                    myData.Close();
                    myConn.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return IsDeleteAdmin;
        }
    }
}