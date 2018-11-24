using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls; //For SortBy method
using saman.Models.DomainModels;

namespace saman
{
    public class PrescriptionResultSearch
    {

        public List<Prescription> GetResult(string search, string sortOrder, int start, int length, List<Prescription> dtResult, List<string> columnFilters)
        {
            return FilterResult(search, dtResult, columnFilters).SortBy(sortOrder).Skip(start).Take(length).ToList();
        }

        public int Count(string search, List<Prescription> dtResult, List<string> columnFilters)
        {
            return FilterResult(search, dtResult, columnFilters).Count();
        }

        private IQueryable<Prescription> FilterResult(string search, List<Prescription> dtResult, List<string> columnFilters)
        {
            IQueryable<Prescription> results = dtResult.AsQueryable();

            results = results.Where(p => (search == null
               || (p.PersonId != null && p.PersonId.Contains(search.ToLower())))
              //  || p.Price.ToString() != null && p.Price.Equals(search.ToLower())
               // || p.Payable.ToString() != null && p.Payable.Equals(search.ToLower())
//                || p.Person.Name != null && p.Person.Name.Contains(search.ToLower())))

                && (columnFilters[0] == null || (p.PersonId != null && p.PersonId.Contains(columnFilters[0].ToLower())))
           //     && (columnFilters[1] == null || (p.Price.ToString() != null && p.Price.Equals(columnFilters[1].ToLower())))
           //     && (columnFilters[2] == null || (p.Payable.ToString() != null && p.Payable.Equals(columnFilters[2].ToLower())))
           //     && (columnFilters[3] == null || (p.Person.Name != null && p.Person.Name.ToLower().Contains(columnFilters[3].ToLower())))
      );


            return results;
        }
    }
}
