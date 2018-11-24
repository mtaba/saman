using saman.Models.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace saman.VIewModels
{
    public class DependentViewModel
    {
        public Dependent  Dependent { get; set; }
        public IEnumerable<Dependent> Dependents { get; set; }

    }
}