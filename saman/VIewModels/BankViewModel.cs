using saman.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace saman.VIewModels
{
    public class BankViewModel
    {
        public IEnumerable<Bank> Banks { get; set; }
        public Bank Bank { get; set; }
    }
}