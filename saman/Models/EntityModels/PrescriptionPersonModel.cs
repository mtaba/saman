using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace saman.Models.EntityModels
{
    public class PrescriptionPersonModel
    {

       

        [Display(Name = "کد پرسنلی")]
        [DisplayName("کد پرسنلی")]
        public string PersonalCode { get; set; }

        [Display(Name = "کد ملی")]
        [DisplayName("کد ملی")]
        public string CodeMelli { get; set; }

        [Display(Name = "نام")]
        [DisplayName("نام")]
        public string Name { get; set; }

        [Display(Name = "نام خانوادگی")]
        [DisplayName("نام خانوادگی")]
        public string Family { get; set; }
    }
}