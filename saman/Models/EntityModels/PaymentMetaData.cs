using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace saman.Models.EntityModels
{
    public class PaymentMetaData
    {
        

        [Required(ErrorMessage ="تاریخ شروع را وارد نمایید")]
        [Display(Name ="تاریخ شروع")]
        [DisplayName("تاریخ شروع")]
        [StringLength(10, MinimumLength = 10)]
        public string StartDate { get; set; }

        [Required(ErrorMessage = "تاریخ خاتمه را وارد نمایید")]
        [Display(Name = "تاریخ خاتمه")]
        [DisplayName("تاریخ خاتمه")]
        [StringLength(10, MinimumLength = 10)]
        public string EndDate { get; set; }

        [Required(ErrorMessage = "نوع پرداخت")]
        [Display(Name = "نوع پرداخت")]
        [DisplayName("نوع پرداخت")]
       
        public int Reason { get; set; }




    }
}

namespace saman.Models.DomainModels
{
    [MetadataType(typeof(EntityModels.PaymentMetaData))]
    public partial class Payment
    {
    }
}
