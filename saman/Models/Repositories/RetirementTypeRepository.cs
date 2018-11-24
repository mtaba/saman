using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace saman.Models.Repositories
{
    public class RetirementTypeRepository : IDisposable
    {
       
        private saman.Models.DomainModels.SamanEntities db = null;

        public RetirementTypeRepository()
        {
            db = new DomainModels.SamanEntities();
        }

        public bool Add(saman.Models.DomainModels.RetirementType entity, bool autoSave = true)
        {

            try
            {

                

                db.RetirementTypes.Add(entity);
                


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

        public bool Update(saman.Models.DomainModels.RetirementType entity, bool autoSave = true)
        {
            try
            {
                db.RetirementTypes.Attach(entity);
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

        public bool Delete(saman.Models.DomainModels.RetirementType entity, bool autoSave = true)
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

        public bool Delete(int id, bool autoSave = true)
        {
            try
            {
                var entity = db.RetirementTypes.Find(id);
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

        public saman.Models.DomainModels.RetirementType Find(int id)
        {
            try
            {
                return db.RetirementTypes.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<saman.Models.DomainModels.RetirementType> Where(System.Linq.Expressions.Expression<Func<saman.Models.DomainModels.RetirementType, bool>> predicate)
        {
            try
            {
                return db.RetirementTypes.Where(predicate);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<saman.Models.DomainModels.RetirementType> Select()
        {
            try
            {
                return db.RetirementTypes.AsQueryable();
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<TResult> Select<TResult>(System.Linq.Expressions.Expression<Func<saman.Models.DomainModels.RetirementType, TResult>> selector)
        {
            try
            {
                return db.RetirementTypes.Select(selector);
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

        ~RetirementTypeRepository()
        {
            Dispose(false);
        }

    }
}