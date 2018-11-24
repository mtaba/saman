using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace saman.Models.Repositories
{
    public class MadrakRepository : IDisposable
    {
        private saman.Models.DomainModels.SamanEntities db = null;

        public MadrakRepository()
        {
            db = new DomainModels.SamanEntities();
        }


        public bool Add(saman.Models.DomainModels.Mardrak entity, bool autoSave = true)
        {
            try
            {
                db.Mardraks.Add(entity);
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


        public bool Update(saman.Models.DomainModels.Mardrak entity, bool autoSave = true)
        {
            try
            {
                db.Mardraks.Attach(entity);
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

        public saman.Models.DomainModels.Mardrak Find(int id)
        {
            try
            {
                return db.Mardraks.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<saman.Models.DomainModels.Mardrak> Where(System.Linq.Expressions.Expression<Func<saman.Models.DomainModels.Mardrak, bool>> predicate)
        {
            try
            {
                return db.Mardraks.Where(predicate);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<saman.Models.DomainModels.Mardrak> Select()
        {
            try
            {
                return db.Mardraks.AsQueryable();
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<TResult> Select<TResult>(System.Linq.Expressions.Expression<Func<saman.Models.DomainModels.Mardrak, TResult>> selector)
        {
            try
            {
                return db.Mardraks.Select(selector);
            }
            catch
            {
                return null;
            }
        }

        /*    public int GetLastIdentity()
            {
                try
                {
                    if (db.Persons.Any())
                        return db.Persons.OrderByDescending(p => p.).First().Id;
                    else
                        return 0;
                }
                catch
                {
                    return -1;
                }
            }
            */
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

        ~MadrakRepository()
        {
            Dispose(false);
        }
    }
}