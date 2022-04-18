using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DssSchoolManagement.Asp.Models
{
    public class TeachersModel
    {
        public int TeacherId { get; set; }

        public string TeacherName { get; set; }

        public int TeacherAge { get; set; }

        public string TeacherSubject { get; set; }

        public int TeacherExperience { get; set; }

        public DateTime TeacherJoiningdate { get; set; }
       
        public string TeacherEmail { get; set; }

        public string TeacherPhoneNumber { get; set; }

        public string TeacherLocation { get; set; }
        
     
    }
}