using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DssSchoolManagement.Asp.Models;
using System.Configuration;
using System.Web.Configuration;

namespace DssSchoolManagement.Asp.Services.Tests
{
    [TestClass()]
    public class TeachersServiceTests
    {
        [TestMethod()]
        public void AddTeacherTest()
        {
            try
            { 
            
                var strcon = WebConfigurationManager.ConnectionStrings["DBConnect"];// ConfigurationManager.AppSettings["DBConnect"].ToString();
            
                var connectionString = ConfigurationManager.ConnectionStrings["DBConnect"];
               
            }
            catch (Exception ex)
            {
                Console.Write(ex);
            }
            TeachersModel Teacher = new TeachersModel()
            {
                TeacherName = "Unit Test 1",
                TeacherAge = 33,
                TeacherExperience = 3,
                TeacherEmail = "dkdkjfdj@fdkfjd.com",
                TeacherJoiningdate = DateTime.Now,
                TeacherLocation = "Hyder",
                TeacherPhoneNumber = "4343434343434" ,
                TeacherSubject ="HIndi"


            };

            TeachersService tSer = new TeachersService();
            int tid = tSer.AddTeacher(Teacher);

            Assert.Fail();
        }
    }
}