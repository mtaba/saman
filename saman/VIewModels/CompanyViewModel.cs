using saman.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace saman.VIewModels
{
    public class CompanyViewModel
    {
        public IEnumerable<Company> Companies { get; set; }
        public Company Company { get; set; }
        public Company Parent { get; set; }
          
    }
}