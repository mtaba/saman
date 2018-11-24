using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace saman.Models.EntityModels
{
    public class DependentMetaData
    {

        [Required(ErrorMessage = "کد ملی را وارد نمایید", AllowEmptyStrings = false)]
        [DisplayName("کد ملی")]
        [Display(Name = "کد ملی")]
        [StringLength(10, ErrorMessage = "کد ملی حداکثر 10 کاراکتر می تواند باشد")]
        public string NationalCode { get; set; }

        [Required(ErrorMessage = "نام را واردنمایید", AllowEmptyStrings = false)]
        [DisplayName("نام")]
        [Display(Name = "نام")]
        [StringLength(100, ErrorMessage = "نام باید حداکثر 100 کاراکتر باشد")]
        public string Name { get; set; }

        [Required(ErrorMessage = "نام خانوادگی را واردنمایید", AllowEmptyStrings = false)]
        [DisplayName("نام خانوادگی")]
        [Display(Name = "نام خانوادگی")]
        [StringLength(150, ErrorMessage = "نام خانوادگی باید حداکثر 150 کاراکتر باشد")]
        public string Family { get; set; }

        [Required(ErrorMessage = "نسبت را انتخاب نمایید", AllowEmptyStrings = false)]
        [DisplayName("نسبت")]
        [Display(Name = "نسبت")]
        public byte Dependency { get; set; }

        [ScaffoldColumn(false)]
        public string PersonId { get; set; }

        [Required(ErrorMessage = "نام پدر را واردنمایید", AllowEmptyStrings = false)]
        [DisplayName("نام پدر")]
        [Display(Name = "نام پدر")]
        [StringLength(150, ErrorMessage = "نام پدر باید حداکثر 150 کاراکتر باشد")]
        public string FatherName { get; set; }

        [Required(ErrorMessage = "تاریخ تولد را وارد نمایید", AllowEmptyStrings = false)]
        [DisplayName("تاریخ تولد")]
        [Display(Name = "تاریخ تولد")]
        [StringLength(10, ErrorMessage = "تاریخ تولد 10 کاراکتر می باشد")]
        public string BirthDate { get; set; }

        [Required(ErrorMessage = "شماره شناسنامه را وارد نمایید")]
        [DisplayName("شماره شناسنامه")]
        [Display(Name="شماره شناسنامه")]
        public string CId { get; set; }

        [DisplayName("محل تولد")]
        [Display(Name = "محل تولد")]
        public string BirthPlace { get; set; }

        [DisplayName("محل صدور")]
        [Display(Name = "محل صدور")]
        public string Issued { get; set; }

    }
}

namespace saman.Models.DomainModels
{

    [MetadataType(typeof(EntityModels.DependentMetaData))]
    public partial class Dependent
    {
    }


}
