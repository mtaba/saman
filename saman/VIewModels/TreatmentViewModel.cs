using System.Collections.Generic;
using saman.Models.DomainModels;

namespace saman.VIewModels
{
    public class TreatmentViewModel
    {
        public TreatmentType Treatment { get; set; }
        public IEnumerable<TreatmentType> Treatments { get; set; }

    }
}