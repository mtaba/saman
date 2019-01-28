using saman.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace saman.Models.EntityModels
{
    internal class PersonMetaData
    {
        [Required(ErrorMessage = "نام را واردنمایید", AllowEmptyStrings = false)]
        [DisplayName("نام")]
        [Display(Name = "نام")]
        [StringLength(50, ErrorMessage = "نام باید حداکثر 50 کاراکتر باشد")]
        public string Name { get; set; }

        [Required(ErrorMessage = "نام خانوادگی را واردنمایید", AllowEmptyStrings = false)]
        [DisplayName("نام خانوادگی")]
        [Display(Name = "نام خانوادگی")]
        [StringLength(50, ErrorMessage = "نام خانوادگی باید حداکثر 50 کاراکتر باشد")]
        public string LName { get; set; }

        [Required(ErrorMessage = "شماره شناسنامه را واردنمایید", AllowEmptyStrings = false)]
        [DisplayName("شماره شناسنامه")]
        [Display(Name = "شماره شناسنامه")]
        [StringLength(10, ErrorMessage = "شماره شناسنامه باید حداکثر 10 کاراکتر باشد")]
        public string IdentityNo { get; set; }


        [Required(ErrorMessage = "محل صدور شناسنامه را وارد نمایید", AllowEmptyStrings = false)]
        [DisplayName("محل صدور")]
        [Display(Name = "محل صدور")]
        public string SodurPlace { get; set; }

        
      
        [DisplayName("شماره تلفن")]
        [Display(Name = "شماره تلفن")]
        public string Tel { get; set; }


        [Required(ErrorMessage = "نام خانوادگی را واردنمایید", AllowEmptyStrings = false)]
        [DisplayName("نام پدر")]
        [Display(Name = "نام پدر")]
        [StringLength(50, ErrorMessage = "نام پدر باید حداکثر 50 کاراکتر باشد")]
        public string FatherName { get; set; }

        [Required(ErrorMessage = "کد ملی را واردنمایید", AllowEmptyStrings = false)]
        [DisplayName("کد ملی")]
        [Display(Name = "کد ملی")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "کد ملی خود را بدرستی وارد کنید")]
        [CodeMelli("لطفا کد ملی را بدرستی وارد کنید")]
        [Remote("checkDoubleNationalCode", "Admin", HttpMethod = "POST", ErrorMessage = "این کد ملی قبلا ثبت شده است")]
        public string CodeMelli { get; set; }


        [Display(Name ="روز تولد")]
        [Required(ErrorMessage = "روز تولد را وارد نمایید", AllowEmptyStrings = false)]
        [StringLength(2)]
        public string BirthDay { get; set; }

        [Display(Name = "ماه تولد")]
        [Required(ErrorMessage = "ماه تولد را وارد نمایید", AllowEmptyStrings = false)]
        [StringLength(2)]
        public string BirthMonth { get; set; }

        [Display(Name = "سال تولد")]
        [Required(ErrorMessage = "سال تولد را وارد نمایید", AllowEmptyStrings = false)]
        [StringLength(4)]
        public string BirthYear { get; set; }

        [Display(Name = "تاریخ فوت")]
       
        public string DeathDate { get; set; }

        [DisplayName("جنیست")]
        public string Jens { get; set; }

        [DisplayName("نسبت")]
        public string Nesbat { get; set; }

        [DisplayName("کد ملی بازنشسته اصلی")]
        public string ParentId { get; set; }

        [DisplayName("شماره شبا")]
        [Display(Name = "شماره شبا")]
        public string ShebaAcc { get; set; }

        [DisplayName("ایثارگر")]
        [Display(Name = "ایثارگر")]
        public string Isargar { get; set; }

        [StringLength(10, ErrorMessage = "طول کد پرسنلی حداکثر 10 می تواند باشد")]
        [Display(Name = "کد پرسنلی")]
        public string PesonalCode { get; set; }

        [DisplayName("نوع بازنشستگی")]
        [Display(Name = "نوع بازنشستگی")]
        public string RetirementType { get; set; }


    }

}

namespace  saman.Models.DomainModels
{
    [MetadataType(typeof(saman.Models.EntityModels.PersonMetaData))]
    public partial class Person
    {
    }
}
