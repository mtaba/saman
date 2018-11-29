using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using saman.Models.DomainModels;
using saman.Models.EntityModels;

namespace saman.VIewModels
{
    public class MembershipFeeViewModel
    {
       
   
        public PrescriptionPersonModel Person { get; set; }
        public IEnumerable<Person> Persons { get; set; }
        public Payment MembershipPayment { get; set; }
        public IEnumerable<Payment> Payments { get; set; }
        public Models.EntityModels.PaymentSearchModel SearchModel { get; set; }
    
    }
}