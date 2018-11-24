using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace saman.Models.EntityModels
{
    public class CompanyMetaData
    {
        [ScaffoldColumn(false)]
        [Bindable(false)]
        [Display(Name = "نام محل خدمت")]
       
        [DisplayName("نام محل خدمت")]
        public int Id { get; set; }

        [Display(Name="نام محل خدمت")]
        [Required(ErrorMessage = "نام محل خدمت را وارد کنید", AllowEmptyStrings = false)]
        [DisplayName("نام محل خدمت")]       
        [StringLength(150, ErrorMessage = "نام محل خدمت باید حداکثر 150 کاراکتر باشد")]
        public string Name { get; set; }

        public int ParentId { get; set; }
    }
}


namespace saman.Models.DomainModels
{
    [MetadataType(typeof(EntityModels.CompanyMetaData))]
    public partial class Company
    {
    }
}
