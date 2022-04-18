using DssSchoolManagement.Asp.Models;
using DssSchoolManagement.Asp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DssSchoolManagement.Asp.Controllers
{
    public class TeachersController : ApiController
    {

        readonly Utility.CustomResponse _result = new Utility.CustomResponse();
        TeachersService _TeachersService = new TeachersService();

        public int AddNumbers(int a, int b)
        {
            return a + b;
        }
        public class Car
        {
            public string Name { get; set; }

            public string GetCarName()
            {
                return "Volvo";
            }
        }


        [HttpPost]
        public Utility.CustomResponse AddTeacher(TeachersModel Teacher)
        {
            try
            {
                Car obj = new Car();
                string CarName = obj.GetCarName();

                int Response = _TeachersService.AddTeacher(Teacher);
                if (Response > 0)
                {
                    _result.Status = Utility.CustomResponseStatus.Successful;
                    _result.Response = Response;
                    _result.Message = "Teacher Added Successfully!!!";
                }
                else if (Response == -1)
                {
                    _result.Status = Utility.CustomResponseStatus.UnSuccessful;
                    _result.Response = Response;
                    _result.Message = "Teacher Already Exists";
                }
                else
                {
                    _result.Status = Utility.CustomResponseStatus.UnSuccessful;
                    _result.Response = Response;
                    _result.Message = "Teacher Adding Failed";
                }
            }
            catch (Exception ex)
            {
                _result.Status = Utility.CustomResponseStatus.Exception;
                _result.Message = ex.Message;
            }
            return _result;
        }




        [HttpPut]
        public Utility.CustomResponse UpdateTeacher(TeachersModel Teacher)
        {
            try
            {
                int Response = _TeachersService.UpdateTeacher(Teacher);
                if (Response > 0)
                {
                    _result.Status = Utility.CustomResponseStatus.Successful;
                    _result.Response = Response;
                    _result.Message = "Teacher Upadted Successfully!!!";
                }
                else if (Response == -1)
                {
                    _result.Status = Utility.CustomResponseStatus.UnSuccessful;
                    _result.Response = Response;
                    _result.Message = "Teacher Dosent exists!!!";
                }
                else
                {
                    _result.Status = Utility.CustomResponseStatus.UnSuccessful;
                    _result.Response = 1;
                    _result.Message = "Teacher Updation Failed";
                }
            }
            catch (Exception ex)
            {
                _result.Status = Utility.CustomResponseStatus.Exception;
                _result.Message = ex.Message;
            }
            return _result;
        }



        [HttpGet]
        public Utility.CustomResponse GetTeacher()
        {
            try
            {
                List<TeachersModel> Response = _TeachersService.GetTeacher();
                if (Response.Count > 0)
                {
                    _result.Status = Utility.CustomResponseStatus.Successful;
                    _result.Response = Response;
                    _result.Message = "Teacher Get Successfully!!!";
                }
                else
                {
                    _result.Status = Utility.CustomResponseStatus.UnSuccessful;
                    _result.Response = null;
                    _result.Message = "Teacher Get Failed!!!!";
                }
            }
            catch (Exception ex)
            {
                _result.Status = Utility.CustomResponseStatus.Exception;
                _result.Message = ex.Message;
            }
            return _result;
        }




        [HttpDelete]
        public Utility.CustomResponse DeleteTeacher(int TeacherId)
        {
            try
            {
                int Response = _TeachersService.DeleteTeacher(TeacherId);
                if (Response > 0)
                {
                    _result.Status = Utility.CustomResponseStatus.Successful;
                    _result.Response = 0;
                    _result.Message = "Teacher Deleted Successfully!!!";
                }
                else
                {
                    _result.Status = Utility.CustomResponseStatus.UnSuccessful;
                    _result.Response = 1;
                    _result.Message = "Teacher Deletion Failed!!!!";
                }
            }
            catch (Exception ex)
            {
                _result.Status = Utility.CustomResponseStatus.Exception;
                _result.Message = ex.Message;
            }
            return _result;
        }
    }
}
