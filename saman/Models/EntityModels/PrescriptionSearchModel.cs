using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace saman.Models.EntityModels
{
    public class PrescriptionSearchModel
    {

        [Display(Name = "تاریخ نسخه از")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "فرمت تاریخ نامعتبر است")]
        public string PrescFromDate { get; set; }

        [Display(Name = "تا تاریخ")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "فرمت تاریخ نامعتبر است")]
        public string PrescToDate { get; set; }
    
        [Display(Name = "تاریخ ارسال از")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "طول رشته تاریخ نامعتبر است")]
        public string SentFromDate { get; set; }

        [Display(Name = "تا تاریخ")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "طول رشته تاریخ نامعتبر است")]
        public string SentToDate { get; set; }
   
    }
}
