using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace saman.Models.EntityModels
{
    public class JobMetaData
    {
        [ScaffoldColumn(false)]
        [Bindable(false)]
        public int Id { get; set; }

        [Required(ErrorMessage ="عنوان شغل را وارد نمایید",AllowEmptyStrings =false)]
        [DisplayName("عنوان شغل")]
        [Display(Name = "عنوان شغل")]
        public string Position { get; set; }


        [Required(ErrorMessage = "تاریخ شروع را وارد نمایید", AllowEmptyStrings = false)]
        [DisplayName("تاریخ شروع")]
        [Display(Name = "تاریخ شروع")]
        public string StartDate { get; set; }


        [Required(ErrorMessage = "عنوان شغل را وارد نمایید", AllowEmptyStrings = false)]
        [DisplayName("تاریخ پایان")]
        [Display(Name = "تاریخ پایان")]
        public string EndDate { get; set; }

        
        [DisplayName("توضیحات")]
        [Display(Name = "توضیحات")]
        public string Description { get; set; }

        [ScaffoldColumn(false)]
        public string PersonId { get; set; }

       
        [DisplayName("نام شرکت")]
        [Display(Name = "نام شرکت")]
        public int CompaniId { get; set; }
    }
}

namespace saman.Models.DomainModels
{

    [MetadataType(typeof(saman.Models.EntityModels.JobMetaData))]
    public partial class Job
    {
    }


}