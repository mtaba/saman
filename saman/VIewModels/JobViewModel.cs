using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using saman.Models.DomainModels;

namespace saman.VIewModels
{
    public class JobViewModel
    {
        public Job Job { get; set; }
        public IEnumerable<Job> Jobs { get; set; }
        public IEnumerable<Company> Companies { get; set; }
        public Company Company { get; set; }
    }
}