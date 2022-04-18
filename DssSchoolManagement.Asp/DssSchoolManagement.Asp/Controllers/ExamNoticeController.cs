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
    public class ExamNoticeController : ApiController
    {
        readonly Utility.CustomResponse _result = new Utility.CustomResponse();
        ExamNoticeService _ExamNoticeService = new ExamNoticeService();

        [HttpPost]
        public Utility.CustomResponse AddExam(ExamNoticeModel Exam)
        {
            try
            {
                int Response = _ExamNoticeService.AddExam(Exam);
                if (Response > 0)
                {
                    _result.Status = Utility.CustomResponseStatus.Successful;
                    _result.Response = Response;
                    _result.Message = "Exam Added Successfully!!!";
                }
                else if (Response == -1)
                {
                    _result.Status = Utility.CustomResponseStatus.UnSuccessful;
                    _result.Response = Response;
                    _result.Message = "Exam Already Exists";
                }
                else
                {
                    _result.Status = Utility.CustomResponseStatus.UnSuccessful;
                    _result.Response = Response;
                    _result.Message = "Exam Adding Failed";
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
        public Utility.CustomResponse Exam(ExamNoticeModel Exam)
        {
            try
            {
                int Response = _ExamNoticeService.UpdateExam(Exam);
                if (Response > 0)
                {
                    _result.Status = Utility.CustomResponseStatus.Successful;
                    _result.Response = Response;
                    _result.Message = "Exam Upadted Successfully!!!";
                }
                else if (Response == -1)
                {
                    _result.Status = Utility.CustomResponseStatus.UnSuccessful;
                    _result.Response = Response;
                    _result.Message = "Exam Dosent exists!!!";
                }
                else
                {
                    _result.Status = Utility.CustomResponseStatus.UnSuccessful;
                    _result.Response = 1;
                    _result.Message = "Exam Updation Failed";
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
        public Utility.CustomResponse GetExam()
        {
            try
            {
                List<ExamNoticeModel> Response = _ExamNoticeService.GetExam();
                if (Response.Count > 0)
                {
                    _result.Status = Utility.CustomResponseStatus.Successful;
                    _result.Response = Response;
                    _result.Message = "Exam Get Successfully!!!";
                }
                else
                {
                    _result.Status = Utility.CustomResponseStatus.UnSuccessful;
                    _result.Response = null;
                    _result.Message = "Exam Get Failed!!!!";
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
        public Utility.CustomResponse DeleteExam(int ExamId)
        {
            try
            {
                int Response = _ExamNoticeService.DeleteExam(ExamId);
                if (Response > 0)
                {
                    _result.Status = Utility.CustomResponseStatus.Successful;
                    _result.Response = 0;
                    _result.Message = "Exam Deleted Successfully!!!";
                }
                else
                {
                    _result.Status = Utility.CustomResponseStatus.UnSuccessful;
                    _result.Response = 1;
                    _result.Message = "Exam Deletion Failed!!!!";
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
