using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DssSchoolManagement.Asp
{
    public class Utility
    {
        public class CustomResponse
        {
            public CustomResponseStatus Status;
            public Object Response;
            public string Message;
        }

        public enum CustomResponseStatus
        {
            Successful,
            UnSuccessful,
            Exception
        }

        public static class CustomConstants
        {
            public static string Logout_Failed = "Logout_Failed";
            public static string Logout_SUCCESS = "successfully Logged out";

            public static string NO_DATA_FOUND = "No data found";
            public static string DATA_GET_SUCCESS = "Data Fetched successfully!";

            public static string REG_USER_SUCCESS = "User Registered successfully!";
            public static string REG_USER_FAIL = "SubUser Adding Failed";
            public static string USER_LOGIN_SUCCESS = "User successfully LoggedIn!";
            public static string USER_LOGIN_FAIL = "User Login failed";
            public static string ADD_TP_SUCCESS = "Trading Partner added successfully!";
            public static string ADD_TP_EXISTS = "Trading Partner already exists";
            public static string ADD_TP_FAIL = "Couldn't add Trading Partner";
            public static string UPDATE_TP_SUCCESS = "Trading Partner Updated successfully!";
            public static string UPDATE_TP_FAIL = "Trading Partner update failed";
            public static string UPDATE_TP_NOTEXISTS = "Trading Partner doesn't exist";
            public static string DELETE_TP_SUCCESS = "Trading Partner deleted successfully!";
            public static string DELETE_TP_FAIL = "Couldn't delete Trading Partner";


        }

    }
}