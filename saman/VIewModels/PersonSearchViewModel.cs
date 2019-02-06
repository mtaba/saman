using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using saman.Models.DomainModels;

namespace saman.VIewModels
{
    public class PersonSearchViewModel
    {
        
        public IEnumerable<Person> Persons { get; set; }

        public Person Person { get; set; }
        
        public IEnumerable<Company> Companies { get; set; }
        public IEnumerable<Company> SubCompanies { get; set; }

        public IEnumerable<RetirementType> RetirmentTypes { get; set; }





    }
}