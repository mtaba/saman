using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace saman.Models.EntityModels
{
    public class TreatmentTypeMetaData
    {
        
        public int Id { get; set; }

        [ScaffoldColumn(false)]
        [Bindable(false)]

        [Required(ErrorMessage = "نام نوع درمان را وارد نمایید", AllowEmptyStrings = false)]
        [DisplayName("نوع درمان")]
        [Display(Name = "نوع درمان")]
        [StringLength(50, ErrorMessage = "نام نوع درمان حداکثر می تواند 50 کاراکتر باشد")]
        public string Value { get; set; }
    }
}

namespace saman.Models.DomainModels
{

    [MetadataType(typeof(EntityModels.TreatmentTypeMetaData))]
    public partial class TreatmentType
    {
    }


}
