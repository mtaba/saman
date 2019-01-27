using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace saman.Models.EntityModels
{
    public class ChequeMetaData
    {
    
        [Required(ErrorMessage = "شماره چک را وارد نمایید", AllowEmptyStrings =false)]
        [DisplayName("شماره چک")]
        [Display(Name = "شماره چک")]
        [StringLength(50, ErrorMessage ="طول شماره چک حداکثر می تواند 50 کاراکتر باشد")]
        public string ChequeId { get; set; }

        [Required(ErrorMessage = "مبلغ چک را وارد نمایید", AllowEmptyStrings = false)]
        [DisplayName("مبلغ چک")]
        [Display(Name = "مبلغ چک")]
        
        public int Price { get; set; }

        [ScaffoldColumn(false)]
        public string Description { get; set; }


        [Required(ErrorMessage = "تاریخ چک را وارد نمایید", AllowEmptyStrings = false)]
        [DisplayName("تاریخ چک")]
        [Display(Name = "تاریخ چک")]
        [StringLength(10,ErrorMessage ="فرمت ورودی تاریخ اشتباه است", MinimumLength =10)]
        public System.DateTime Date { get; set; }


        [Required(ErrorMessage = "نام بانک را انتخاب نمایید")]
        [DisplayName("نام بانک")]
        [Display(Name = "نام بانک")]
        public int BankId { get; set; }

        [Required(ErrorMessage = "شماره حساب را وارد نمایید", AllowEmptyStrings = false)]
        [DisplayName("شماره حساب")]
        [Display(Name = "شماره حساب")]
       
        public string AccountNumber { get; set; }

        [DisplayName("وضعیت")]
        [Display(Name = "وضعیت")]
        public byte Status { get; set; }
    }
}

namespace saman.Models.DomainModels
{
    [MetadataType(typeof(saman.Models.EntityModels.ChequeMetaData))]
    public partial class Cheque
    {
    }
}