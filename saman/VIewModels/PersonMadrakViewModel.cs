using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using saman.Models.DomainModels;

namespace saman.VIewModels
{
    public class PersonMadrakViewModel
    {
        public Mardrak  Madrak{ get; set; }
        public IEnumerable <Mardrak> Madraks { get; set; }
        
        public Person_Madraks PersonMadrak { get; set; }
        public IEnumerable<Person_Madraks> PersonMadraks { get; set; }
    }
}