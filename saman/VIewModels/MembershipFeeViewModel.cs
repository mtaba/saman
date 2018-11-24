using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using saman.Models.DomainModels;


namespace saman.VIewModels
{
    public class MembershipFeeViewModel
    {
       
   
        public Person Person { get; set; }
        public IEnumerable<saman.Models.DomainModels.Person> Persons { get; set; }
        public Payment MembershipPayment { get; set; }
        public IEnumerable<Payment> Payments { get; set; }
        public Models.EntityModels.PaymentSearchModel SearchModel { get; set; }
    
    }
}