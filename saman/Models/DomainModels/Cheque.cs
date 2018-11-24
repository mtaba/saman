//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace saman.Models.DomainModels
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cheque
    {
        public string ChequeId { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public long Price { get; set; }
        public int BankId { get; set; }
        public int Reason { get; set; }
        public int PaymentId { get; set; }
        public string AccountNumber { get; set; }
    
        public virtual Bank Bank { get; set; }
        public virtual Payment Payment { get; set; }
    }
}
