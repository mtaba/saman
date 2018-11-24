using saman.Models.DomainModels;
using saman.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace saman.VIewModels
{
    public class ChequeViewModel
    {
        public IEnumerable<Cheque> Cheques { get; set; }
        public Cheque Cheque { get; set; }
        public IEnumerable<Bank> Banks { get; set; }
        public Bank Bank { get; set; }
        public Payment Payment { get; set; }
        public ChequeSearchModel SearchModel { get; set; }
    }
}