using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace saman.Models.Repositories
{
    public class ChequeRepository : IDisposable
    {

        private DomainModels.SamanEntities db = null;

        public ChequeRepository()
        {
            db = new DomainModels.SamanEntities();
        }

        public bool Add(Models.DomainModels.Cheque entity, bool autoSave = true)
        {

            try
            {
                db.Cheques.Add(entity);

                if (autoSave)
                    return Convert.ToBoolean(db.SaveChanges());
                else
                    return false;
            }
            catch
            {

                return false;
            }
        }

        public bool Update(saman.Models.DomainModels.Cheque entity, bool autoSave = true)
        {
            try
            {
                db.Cheques.Attach(entity);
                db.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                if (autoSave)
                    return Convert.ToBoolean(db.SaveChanges());
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(saman.Models.DomainModels.Cheque entity, bool autoSave = true)
        {
            try
            {
                db.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                if (autoSave)
                    return Convert.ToBoolean(db.SaveChanges());
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(string id, bool autoSave = true)
        {
            try
            {
                var entity = db.Cheques.Find(id);
                db.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                if (autoSave)
                    return Convert.ToBoolean(db.SaveChanges());
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public saman.Models.DomainModels.Cheque Find(string id)
        {
            try
            {
                return db.Cheques.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<saman.Models.DomainModels.Cheque> Where(System.Linq.Expressions.Expression<Func<saman.Models.DomainModels.Cheque, bool>> predicate)
        {
            try
            {
                return db.Cheques.Where(predicate);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<saman.Models.DomainModels.Cheque> Select()
        {
            try
            {
                return db.Cheques.AsQueryable();
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<TResult> Select<TResult>(System.Linq.Expressions.Expression<Func<saman.Models.DomainModels.Cheque, TResult>> selector)
        {
            try
            {
                return db.Cheques.Select(selector);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<DomainModels.Cheque> SearchCheques(EntityModels.ChequeSearchModel SearchModel)
        {
            var result = db.Cheques.AsQueryable();
            if (SearchModel != null)
            {
                if (!string.IsNullOrWhiteSpace(SearchModel.ChequeId))
                    result = result.Where(x => x.ChequeId.Contains(SearchModel.ChequeId));
                if (!string.IsNullOrWhiteSpace(SearchModel.AccountNumber))
                    result = result.Where(x => x.AccountNumber.Contains(SearchModel.AccountNumber));

                if (string.IsNullOrWhiteSpace(SearchModel.ToDate) && !string.IsNullOrWhiteSpace(SearchModel.FromDate))
                    result = result.Where(x => x.Date.Equals(SearchModel.FromDate));

                if (!string.IsNullOrWhiteSpace(SearchModel.ToDate) && !string.IsNullOrWhiteSpace(SearchModel.FromDate))
                {
                    result = result.Where(x => x.Date.CompareTo(SearchModel.FromDate) >= 0); 
                    result = result.Where(x => x.Date.CompareTo(SearchModel.ToDate) <= 0);   
                }

                if (!string.IsNullOrWhiteSpace(SearchModel.PersonalCode))
                {
                    result = result.Where(x => x.Payment.Person.PesonalCode.Contains(SearchModel.PersonalCode));

                }

                if (!string.IsNullOrWhiteSpace(SearchModel.PersonId))
                {
                    result = result.Where(x => x.Payment.PersonId.Contains(SearchModel.PersonId));
              
                }

            }

            return result;

        }
        public int Save()
        {
            try
            {
                return db.SaveChanges();
            }
            catch
            {
                return -1;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.db != null)
                {
                    this.db.Dispose();
                    this.db = null;
                }
            }
        }

        ~ChequeRepository()
        {
            Dispose(false);
        }
    }
}