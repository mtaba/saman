using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace saman.Models.EntityModels
{
    public class MardrakMetaData
    {
        
        public int Id { get; set; }

        [DisplayName("مدرک")]
        [Display(Name = "مدرک")]
        public string MadrakText { get; set; }
    }
}

namespace saman.Models.DomainModels
{
    [MetadataType(typeof(EntityModels.MardrakMetaData))]
    public partial class Mardrak
    {
    }
}
