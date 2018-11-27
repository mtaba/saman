using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace saman.Models.EntityModels
{
    public class PrescriptionMetaData
    {
        [ScaffoldColumn(false)]
        [Bindable(false)]
        public string Id { get; set; }

        [Display(Name = "تاریخ نسخه")]
        [Required(AllowEmptyStrings =false, ErrorMessage = "تاریخ را وارد نمایید")]
        [StringLength(10,MinimumLength =10,ErrorMessage ="فرمت تاریخ نامعتبر است")]
        public string Date { get; set; }

        [Display(Name = "مبلغ نسخه")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "مبلغ را وارد نمایید")]
        [Range(0, int.MaxValue, ErrorMessage = "لطفا یک عدد معتبر وارد کنید بزرگتر از 0")]
        public long Price { get; set; }

        [Display(Name = "مبلغ قابل پرداخت")]
        [Range(0, int.MaxValue, ErrorMessage = "لطفا یک عدد معتبر وارد کنید بزرگتر از 0")]
        public long Payable { get; set; }

        [Display(Name = "تاریخ ارسال")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "تاریخ را وارد نمایید")]
        [StringLength(10,MinimumLength =10, ErrorMessage = "طول رشته تاریخ نامعتبر است")]
        public string SentDate { get; set; }

        [Display(Name = "شماره دوره")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "دوره را وارد نمایید")]
        [Range(1, 48, ErrorMessage = "شماره دوره بین 1 تا 48 است")]
        public Nullable<short> Period { get; set; }

        [DisplayName("نوع درمان")]
        [Display(Name = "نوع درمان")]
        public int TreatmentTypeId { get; set; }


     
     

    }
}
namespace saman.Models.DomainModels
{
    [MetadataType(typeof(saman.Models.EntityModels.PrescriptionMetaData))]
    public partial class Prescription { }
}