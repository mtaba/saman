using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace saman.Models.Repositories
{
    public class PersonRepository : IDisposable
    {
      //  MadrakRepository blmadrak = new MadrakRepository();
        private saman.Models.DomainModels.SamanEntities db = null;

        public PersonRepository()
        {
            db = new DomainModels.SamanEntities();
        }

        public bool Add(saman.VIewModels.PersonViewModel entity, bool autoSave = true)
        {
               try
                {
                db.Persons.Add(entity.Person);        

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

        public bool Update(saman.Models.DomainModels.Person entity, bool autoSave = true)
        {
            try
            {
                db.Persons.Attach(entity);
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

        public bool Delete(saman.Models.DomainModels.Person entity, bool autoSave = true)
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
                var entity = db.Persons.Find(id);
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

        public saman.Models.DomainModels.Person Find(string id)
        {
            try
            {
                return db.Persons.Find(id);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<saman.Models.DomainModels.Person> Where(System.Linq.Expressions.Expression<Func<saman.Models.DomainModels.Person, bool>> predicate)
        {
            try
            {
                return db.Persons.Where(predicate);
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<saman.Models.DomainModels.Person> Select()
        {
            try
            {
                return db.Persons.AsQueryable();
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<TResult> Select<TResult>(System.Linq.Expressions.Expression<Func<saman.Models.DomainModels.Person, TResult>> selector)
        {
            try
            {
                return db.Persons.Select(selector);
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

        ~PersonRepository()
        {
            Dispose(false);
        }
    }
}