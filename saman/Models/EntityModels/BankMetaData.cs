using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace saman.Models.EntityModels
{
    public class BankMetaData
    {
        [ScaffoldColumn(false)]
        [Bindable(false)]
        [DisplayName("نام بانک")]
        [Display(Name = "نام بانک")]
        public int Id { get; set; }


        [Required(ErrorMessage = "نام بانک را وارد نمایید", AllowEmptyStrings = false)]
        [DisplayName("نام بانک")]
        [Display(Name = "نام بانک")]
        [StringLength(150, ErrorMessage = "نام بانک حداکثر می تواند 150 کاراکتر باشد")]
        public string Name { get; set; }
    }
}



namespace saman.Models.DomainModels
{

    [MetadataType(typeof(saman.Models.EntityModels.BankMetaData))]
    public partial class Bank
    {
    }

    
}
