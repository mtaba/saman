using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using saman.Models.DomainModels;
using saman.Models.Repositories;
using saman.VIewModels;
using Newtonsoft.Json;

namespace saman.Controllers
{
    [Authorize]
    public class ChequesController : Controller
    {

        ChequeRepository blCheque = new ChequeRepository();
        SamanEntities db = new SamanEntities();

        [HttpPost]
        public ActionResult Index(MembershipFeeViewModel model)
        {
            MembershipRepository blMembership = new MembershipRepository();
            var payment = blMembership.Where(p => (p.StartDate == model.MembershipPayment.StartDate) && (p.EndDate == model.MembershipPayment.EndDate) && (p.PersonId == model.Person.CodeMelli)).Select(c => c.Id).AsQueryable().SingleOrDefault();
            int Id;
            if (payment == 0)  // means payment not exits
            {
                if (blMembership.Add(model))
                {
                    Id = Convert.ToInt32(blMembership.TempData["paymentId"]);
                    var cheques = blCheque.Select().Where(c => c.PaymentId == Id).ToList();

                    BankRepository blBank = new BankRepository();
                    ChequeViewModel ChequeModel = new ChequeViewModel();

                    var Banks = blBank.Select().ToList();

                    ChequeModel.Banks = Banks;
                    ChequeModel.Cheques = cheques;
                    TempData["paymentId"] = Id;
                    TempData.Keep();
                    return View(ChequeModel);

                    //     return RedirectToAction("Index", "Cheques", new { Id });
                }
                else
                {
                    ViewBag.AddPayResult = false;
                    return View();
                }
            }
            else  //if payment exist from before
            {
                Id = payment;
                // return RedirectToAction("Index", "Cheques", new { Id });
                var cheques = blCheque.Select().Where(c => c.PaymentId == Id).ToList();
                BankRepository blBank = new BankRepository();
                ChequeViewModel ChequeModel = new ChequeViewModel();

                var Banks = blBank.Select().ToList();

                ChequeModel.Banks = Banks;
                ChequeModel.Cheques = cheques;
                TempData["paymentId"] = Id;
                TempData.Keep();
                return View(ChequeModel);
            }   //#else
        }

        // GET: Cheques/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cheque cheque = db.Cheques.Find(id);
            if (cheque == null)
            {
                return HttpNotFound();
            }
            return View(cheque);
        }

        // GET: Cheques/Create
        [HttpGet]
        public ActionResult Create(int Id)
        {
            BankRepository blBank = new BankRepository();
            var Banks = blBank.Select().ToList();
           
         // Id = Convert.ToInt32(TempData["paymentId"]);
            var cheques = blCheque.Select().Where(c => c.PaymentId == Id).ToList();

            ChequeViewModel ChequeModel = new ChequeViewModel();
            ChequeModel.Banks = Banks;
            ChequeModel.Cheques = cheques;
            TempData["paymentId"] = Id;
            TempData.Keep();

            return View(ChequeModel);
        }

        // POST: Cheques/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ChequeViewModel ChModel)
        {
            if (ModelState.IsValid)
            {
                int  paymentId= Convert.ToInt32(TempData["paymentId"]);
                ChModel.Cheque.PaymentId = paymentId;
                if (blCheque.Add(ChModel.Cheque))
                {
                    var cheques = blCheque.Select().Where(c => c.PaymentId == ChModel.Cheque.PaymentId);
                    TempData.Keep();
                    return PartialView("_Cheques",cheques);
                }
                else
                {

                }
                return RedirectToAction("Create");
            }
            return View("Create");
        }

        // GET: Cheques/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cheque cheque = blCheque.Find(id);
            if (cheque == null)
            {
                return HttpNotFound();
            }
            ViewBag.BankId = new SelectList(db.Banks, "Id", "Name", cheque.BankId);
            return View(cheque);
        }

        // POST: Cheques/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PaymentId,ChequeId,Price,Description,Date,BankId,Reason,AccountNumber,Status")] Cheque cheque)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cheque).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();

                    MembershipRepository blMembership = new MembershipRepository();
                    MembershipFeeViewModel MembershipModel = new MembershipFeeViewModel();
                    BankRepository blBank = new BankRepository();
                    ChequeViewModel chequeModel = new ChequeViewModel();
                    
                    chequeModel.Cheques = blCheque.Select().Where(c => c.PaymentId == cheque.PaymentId).ToList();
                    chequeModel.Banks = blBank.Select().ToList();
                    TempData["paymentId"] = Convert.ToInt32(cheque.PaymentId);
                    TempData.Keep();
                    int Id = Convert.ToInt32(cheque.PaymentId); ;
                    return RedirectToAction( "Create", "Cheques", new { Id });
                                    
                 
                }
                catch
                {
                }
            }
            ViewBag.BankId = new SelectList(db.Banks, "Id", "Name", cheque.BankId);          
            return View(cheque);

        }


        [HttpGet]
        public ActionResult Delete(int Id)
        {
            int PaymentId = Convert.ToInt32(TempData["paymentId"]);
            if (Id == 0)
            {
                string html = "";
                ViewBag.NotValidCheque = "عملیات حذف چک معتبر نیست";
                return Json(new
                {
                    Success = false,
                    html = ""
                });
            }

            Cheque cheque = blCheque.Find(Id.ToString());

            if (cheque == null)
            {
                return Json(new
                {
                    Success = false,
                    html = ""
                });
            }
            else
            {   //if it can be deleted
                blCheque.Delete(cheque);
                ChequeViewModel model = new ChequeViewModel();
                BankRepository blBank = new BankRepository();

                model.Cheques = blCheque.Select().Where(c => c.PaymentId == PaymentId).AsQueryable().ToList(); ;
                model.Banks = blBank.Select().ToList();
                TempData.Keep();
             


                 return PartialView("Index", model);
            
            }  // end else
        }

        [HttpPost]
        public ActionResult Delete(string Id)
        {
            TempData.Keep();
            int PaymentId = Convert.ToInt32(TempData["paymentId"]);
            if (Id == null)
            {

                string html = "";
                ViewBag.NotValidCheque = "عملیات حذف چک معتبر نیست";
                return Json (new
                {
                    Success = false,
                    html = "" 
                });
            }

            Cheque cheque = blCheque.Find(Id);

            if (cheque == null)
            {
                return Json(new
                {
                    Success = false,
                    html = ""
                });
            }
            else
            {   //if it can be deleted
                blCheque.Delete(cheque);
                var model = blCheque.Select().Where(c => c.PaymentId == PaymentId);
                string html = JsonConvert.SerializeObject(model, Formatting.None,
                  new JsonSerializerSettings()
                  {
                      ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            

                  });
             
                return Json(new
                {
                    Success = true,
                    Html = html
                }); 
            }  // end else
        } // end Delete()


        [HttpGet]
        public ActionResult Search()
        {
            ChequeViewModel Cheque = new ChequeViewModel();
             
            return View(Cheque);
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult Search(ChequeViewModel model)
        {
             return PartialView("_Cheques", blCheque.SearchCheques(model.SearchModel));           
        }


        [HttpGet]
        public ActionResult Report()
        {
            ChequeViewModel Cheque = new ChequeViewModel();

            return View(Cheque);
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult Report(ChequeViewModel model)
        {
             return PartialView("_Cheques", blCheque.SearchCheques(model.SearchModel));           
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
