using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace saman.Models.Repositories
{
    public class BankRepository : IDisposable
    {
        private saman.Models.DomainModels.SamanEntities db = null;

        public BankRepository()
        {
            db = new DomainModels.SamanEntities();
        }

        public bool Add(saman.Models.DomainModels.Bank entity, bool autoSave = true)
        {
            try
            {
                db.Banks.Add(entity);

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

        public bool Update(saman.Models.DomainModels.Bank entity, bool autoSave = true)
        {
            try
            {
                db.Banks.Attach(entity);
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

        public saman.Models.DomainModels.Bank Find(int id)
        {
            try
            {
                return db.Banks.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<saman.Models.DomainModels.Bank> Where(System.Linq.Expressions.Expression<Func<saman.Models.DomainModels.Bank, bool>> predicate)
        {
            try
            {
                return db.Banks.Where(predicate);
            }
            catch
            {
                return null;
            }
        }


        public IQueryable<saman.Models.DomainModels.Bank> Select()
        {
            try
            {
                return db.Banks.AsQueryable();
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<TResult> Select<TResult>(System.Linq.Expressions.Expression<Func<saman.Models.DomainModels.Bank, TResult>> selector)
        {
            try
            {
                return db.Banks.Select(selector);
            }
            catch
            {
                return null;
            }
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

        ~BankRepository()
        {
            Dispose(false);
        }


    }
}