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
    public class AdminsController : ApiController
    {
        readonly Utility.CustomResponse _result = new Utility.CustomResponse();
        AdminsService _AdminsService = new AdminsService();

        [HttpPost]
        public Utility.CustomResponse AddAdmin(AdminsModel Admin)
        {
            try
            {
                int Response = _AdminsService.AddAdmin(Admin);
                if (Response > 0)
                {
                    _result.Status = Utility.CustomResponseStatus.Successful;
                    _result.Response = Response;
                    _result.Message = "Admin Added Successfully!!!";
                }
                else if (Response == -1)
                {
                    _result.Status = Utility.CustomResponseStatus.UnSuccessful;
                    _result.Response = Response;
                    _result.Message = "Admin Already Exists";
                }
                else
                {
                    _result.Status = Utility.CustomResponseStatus.UnSuccessful;
                    _result.Response = Response;
                    _result.Message = "Admin Adding Failed";
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
        public Utility.CustomResponse Admin(AdminsModel Admin)
        {
            try
            {
                int Response = _AdminsService.UpdateAdmin(Admin);
                if (Response > 0)
                {
                    _result.Status = Utility.CustomResponseStatus.Successful;
                    _result.Response = Response;
                    _result.Message = "Admin Upadted Successfully!!!";
                }
                else if (Response == -1)
                {
                    _result.Status = Utility.CustomResponseStatus.UnSuccessful;
                    _result.Response = Response;
                    _result.Message = "Admin Dosent exists!!!";
                }
                else
                {
                    _result.Status = Utility.CustomResponseStatus.UnSuccessful;
                    _result.Response = 1;
                    _result.Message = "Admin Updation Failed";
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
        public Utility.CustomResponse GetAdmin()
        {
            try
            {
                List<AdminsModel> Response = _AdminsService.GetAdmin();
                if (Response.Count > 0)
                {
                    _result.Status = Utility.CustomResponseStatus.Successful;
                    _result.Response = Response;
                    _result.Message = "Admin Get Successfully!!!";
                }
                else
                {
                    _result.Status = Utility.CustomResponseStatus.UnSuccessful;
                    _result.Response = null;
                    _result.Message = "Admin Get Failed!!!!";
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
        public Utility.CustomResponse DeleteAdmin(int AdminId)
        {
            try
            {
                int Response = _AdminsService.DeleteAdmin(AdminId);
                if (Response > 0)
                {
                    _result.Status = Utility.CustomResponseStatus.Successful;
                    _result.Response = 0;
                    _result.Message = "Admin Deleted Successfully!!!";
                }
                else
                {
                    _result.Status = Utility.CustomResponseStatus.UnSuccessful;
                    _result.Response = 1;
                    _result.Message = "Admin Deletion Failed!!!!";
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
