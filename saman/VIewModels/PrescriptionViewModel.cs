using saman.Models.DomainModels;
using saman.Models.EntityModels;
using System.Collections.Generic;

namespace saman.VIewModels
{
    public class PrescriptionViewModel
    {
        public Prescription Prescription { get; set; }
        public IEnumerable<Prescription> Prescriptions { get; set; }
        public IEnumerable<TreatmentType> Treatments { get; set; }
        public TreatmentType Treatment { get; set; }
        public Person Person { get; set; }
        public PrescriptionSearchModel SearchModel { get; set; }
    }
}