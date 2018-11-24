using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace saman.Models.EntityModels
{
    public class PersonMadrakMetaData
    {
        [ScaffoldColumn(false)]
        [Bindable(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "تاریخ اخذ مدرک را وارد نمایید", AllowEmptyStrings = false)]
        [DisplayName("تاریخ اخذ")]
        [Display(Name = "تاریخ اخذ")]
        public string Date { get; set; }




    }
}

namespace saman.Models.DomainModels
{

    [MetadataType(typeof(saman.Models.EntityModels.PersonMadrakMetaData))]
    public partial class Person_Madraks
    {
    }


}