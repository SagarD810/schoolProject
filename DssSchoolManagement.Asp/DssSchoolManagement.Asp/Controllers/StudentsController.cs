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
    public class StudentsController : ApiController
    {
        readonly Utility.CustomResponse _result = new Utility.CustomResponse();
        StudentsService _StudentsService = new StudentsService();

        [HttpPost]
        public Utility.CustomResponse AddStudent(StudentsModel Student)
        {
            try
            {
                int Response = _StudentsService.AddStudent(Student);
                if (Response > 0)
                {
                    _result.Status = Utility.CustomResponseStatus.Successful;
                    _result.Response = Response;
                    _result.Message = "Student Added Successfully!!!";
                }
                else if (Response == -1)
                {
                    _result.Status = Utility.CustomResponseStatus.UnSuccessful;
                    _result.Response = Response;
                    _result.Message = "Student Already Exists";
                }
                else
                {
                    _result.Status = Utility.CustomResponseStatus.UnSuccessful;
                    _result.Response = Response;
                    _result.Message = "Student Adding Failed";
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
        public Utility.CustomResponse UpdateStudent(StudentsModel Student)
        {
            try
            {
                int Response = _StudentsService.UpdateStudent(Student);
                if (Response > 0)
                {
                    _result.Status = Utility.CustomResponseStatus.Successful;
                    _result.Response = Response;
                    _result.Message = "Student Upadted Successfully!!!";
                }
                else if (Response == -1)
                {
                    _result.Status = Utility.CustomResponseStatus.UnSuccessful;
                    _result.Response = Response;
                    _result.Message = "Student Dosent exists!!!";
                }
                else
                {
                    _result.Status = Utility.CustomResponseStatus.UnSuccessful;
                    _result.Response = 1;
                    _result.Message = "Student Updation Failed";
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
        public Utility.CustomResponse GetStudent()
        {
            try
            {
                List<StudentsModel> Response = _StudentsService.GetStudent();
                if (Response.Count > 0)
                {
                    _result.Status = Utility.CustomResponseStatus.Successful;
                    _result.Response = Response;
                    _result.Message = "Student Get Successfully!!!";
                }
                else
                {
                    _result.Status = Utility.CustomResponseStatus.UnSuccessful;
                    _result.Response = null;
                    _result.Message = "Student Get Failed!!!!";
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
        public Utility.CustomResponse DeleteStudent(int StudentId)
        {
            try
            {
                int Response = _StudentsService.DeleteStudent(StudentId);
                if (Response > 0)
                {
                    _result.Status = Utility.CustomResponseStatus.Successful;
                    _result.Response = 0;
                    _result.Message = "Student Deleted Successfully!!!";
                }
                else
                {
                    _result.Status = Utility.CustomResponseStatus.UnSuccessful;
                    _result.Response = 1;
                    _result.Message = "Student Deletion Failed!!!!";
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
