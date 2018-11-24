using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace saman.Models.EntityModels
{
    public class ChequeSearchModel
    {
        [DisplayName("شماره چک")]
        [Display(Name = "شماره چک")]
        public string ChequeId { get; set; }

        [DisplayName("از تاریخ")]
        [Display(Name = "از تاریخ")]
        public string FromDate { get; set; }


        [DisplayName("تا تاریخ")]
        [Display(Name = "تا تاریخ")]
        public string ToDate { get; set; }

        public int? PaymentId { get; set; }

        [DisplayName("شماره حساب")]
        [Display(Name = "شماره حساب")]
        public string AccountNumber { get; set; }

        [DisplayName("کد پرسنلی")]
        [Display(Name = "کد پرسنلی")]
        public string PersonalCode { get; set; }

        [DisplayName("کد ملی")]
        [Display(Name = "کد ملی")]
        public string PersonId { get; set; }

      
    }
}