using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace saman.Models.EntityModels
{
    public class PaymentSearchModel
    {

        
        [Display(Name = "تاریخ از")]
        [DisplayName("تاریخ از")]
        [StringLength(10,MinimumLength =10,ErrorMessage ="فرمت تاریخ را درست وارد نمایید")]
        public string FromDate { get; set; }
      
        [Display(Name = "تاریخ تا")]
        [DisplayName("تاریخ تا")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "فرمت تاریخ را درست وارد نمایید")]
        public string ToDate { get; set; }

        [Display(Name = "نوع پرداخت")]
        [DisplayName("نوع پرداخت")]
        public int Reason { get; set; }

        [Display(Name = "کد پرسنلی")]
        [DisplayName("کد پرسنلی")]
        public string PersonalCode { get; set; }

        [Display(Name = "کد ملی")]
        [DisplayName("کد ملی")]
        public string PersonId { get; set; }

        [Display(Name = "نام")]
        [DisplayName("نام")]
        public string Name { get; set; }

        [Display(Name = "نام خانوادگی")]
        [DisplayName("نام خانوادگی")]
        public string Family { get; set; }
    }
}