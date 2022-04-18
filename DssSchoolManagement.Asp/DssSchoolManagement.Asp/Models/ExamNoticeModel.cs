using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DssSchoolManagement.Asp.Models
{
    public class ExamNoticeModel
    {
       
        public int ExamId { get; set; }

        public string SubjectName { get; set; }

        public DateTime ExamDate { get; set; }

        public string ExamDay { get; set; }

        public int TotalMarks { get; set; }

    }
}