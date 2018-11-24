using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace saman.Models.EntityModels
{
    public class RetirementTypeMetaData
    {

        [ScaffoldColumn(false)]
        [Bindable(false)]

        public int Id { get; set; }

        [Required(ErrorMessage = "نوع بازنشستگی را وارد نمایید", AllowEmptyStrings = false)]
        [DisplayName("نوع بازنشستگی")]
        [Display(Name = "نوع بازنشستگی")]
        [StringLength(50, ErrorMessage = "نوع بازنشستگی باید حداکثر 50 کاراکتر باشد")]
        public string Value { get; set; }
        
    }
}


namespace saman.Models.DomainModels
{
    [MetadataType(typeof(EntityModels.RetirementTypeMetaData))]
    public partial class RetirementType
    {
    }
}
