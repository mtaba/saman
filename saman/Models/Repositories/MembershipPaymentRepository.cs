using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using saman.Models.EntityModels;
using System.Globalization;


namespace saman.Models.Repositories
{ 
     public class MembershipRepository : IDisposable
    {
       
        private saman.Models.DomainModels.SamanEntities db = null;

        public MembershipRepository()
        {
            db = new DomainModels.SamanEntities();
        }

        public TempDataDictionary TempData = new TempDataDictionary();

        public bool Add(saman.VIewModels.MembershipFeeViewModel entity)
        {
           
            try
            {
                entity.MembershipPayment.PersonId = entity.Person.CodeMelli;
                entity.MembershipPayment.PaymentMethod = 0;

                PersianCalendar pc = new PersianCalendar();
                int year = pc.GetYear(DateTime.Now);
                int month = pc.GetMonth(DateTime.Now);
                int day = pc.GetDayOfMonth(DateTime.Now);
                entity.MembershipPayment.PaymentDate =  year.ToString() + '/'+ month.ToString() + '/' + day.ToString(); 
              //  entity.MembershipPayment.Person = (saman.Models.DomainModels.Person)db.Persons.Find(entity.Person.CodeMelli);
          
                db.Payments.Add(entity.MembershipPayment);
                bool isSaved= Convert.ToBoolean(db.SaveChanges());
                DomainModels.Payment pay=  db.Payments.Where(p => p.PersonId == entity.Person.CodeMelli && p.StartDate == entity.MembershipPayment.StartDate && p.EndDate == entity.MembershipPayment.EndDate).AsQueryable().Single();
               
               TempData["paymentId"] = pay.Id;
             
   
               return isSaved  ;
              
            }
            catch
            {
                return false;
               
            }
        }



        public IQueryable<saman.Models.DomainModels.Payment> Where(System.Linq.Expressions.Expression<Func<saman.Models.DomainModels.Payment, bool>> predicate)
        {
            try
            {
                return db.Payments.Where(predicate);
            }
            catch
            {
                return null;
            }
        }


        public IQueryable<saman.Models.DomainModels.Payment> Select()
        {
            try
            {
                return db.Payments.AsQueryable();
            }
            catch
            {
                return null;
            }
        }

        public IQueryable<TResult> Select<TResult>(System.Linq.Expressions.Expression<Func<saman.Models.DomainModels.Payment, TResult>> selector)
        {
            try
            {
                return db.Payments.Select(selector);
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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="SearchModel"></param>
        /// <returns></returns>
        public IQueryable<DomainModels.Payment> Search(PaymentSearchModel SearchModel)
        {
            var result = db.Payments.AsQueryable();
            if (SearchModel != null)
            {
                if (!string.IsNullOrWhiteSpace(SearchModel.Name))

                    result = result.Where(x => x.Person.Name.Contains(SearchModel.Name));
                if (!string.IsNullOrWhiteSpace(SearchModel.Family))
                    result = result.Where(x => x.Person.LName.Contains(SearchModel.Family));

                if (!string.IsNullOrWhiteSpace(SearchModel.ToDate) && !string.IsNullOrWhiteSpace(SearchModel.FromDate))
                {
                    result = result.Where(x => x.StartDate.CompareTo(SearchModel.FromDate) >= 0);
                    result = result.Where(x => x.EndDate.CompareTo(SearchModel.ToDate) <= 0);
                }

                if (!string.IsNullOrWhiteSpace(SearchModel.PersonalCode))
                    result = result.Where(x => x.Person.PesonalCode.Contains(SearchModel.PersonalCode));

                if (!string.IsNullOrWhiteSpace(SearchModel.PersonId))
                    result = result.Where(x => x.PersonId.Contains(SearchModel.PersonId));
            }

            return result;
        }

        public IQueryable<DomainModels.Payment> Report(PaymentSearchModel SearchModel)
        {
            IQueryable<DomainModels.Payment> result = db.Payments.AsQueryable();
            if (SearchModel != null)
            {
                if(!string.IsNullOrEmpty(SearchModel.Reason.ToString()))
                    result = result.Where(x => x.Reason == SearchModel.Reason);

                if (!string.IsNullOrWhiteSpace(SearchModel.Name))
                    result = result.Where(x => x.Person.Name.Contains(SearchModel.Name));

                if (!string.IsNullOrWhiteSpace(SearchModel.Family))
                    result = result.Where(x => x.Person.LName.Contains(SearchModel.Family));

                if (!string.IsNullOrWhiteSpace(SearchModel.ToDate) && !string.IsNullOrWhiteSpace(SearchModel.FromDate))
                {
                    result = result.Where(x => x.StartDate.CompareTo(SearchModel.FromDate) >= 0);
                    result = result.Where(x => x.EndDate.CompareTo(SearchModel.ToDate) <= 0);
                }

                if (!string.IsNullOrWhiteSpace(SearchModel.PersonalCode))
                    result = result.Where(x => x.Person.PesonalCode.Contains(SearchModel.PersonalCode));

                if (!string.IsNullOrWhiteSpace(SearchModel.PersonId))
                    result = result.Where(x => x.PersonId.Contains(SearchModel.PersonId));
            }

            return result;
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

        ~MembershipRepository()
        {
            Dispose(false);
        }
    }
}