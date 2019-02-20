using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using saman.Models.DomainModels;

namespace saman.VIewModels
{
    public class PersonViewModel
    {
        public Person Person { get; set; }

        public Company Company { get; set; }

        public IEnumerable<Company> Companies { get; set; }



    }
}