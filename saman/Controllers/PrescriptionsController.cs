using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using saman.Models.DomainModels;
using saman.Models.Repositories;
using Newtonsoft.Json;
using System.Data.Entity.Infrastructure;
using saman.VIewModels;
using System;
using System.Collections.Generic;

namespace saman.Controllers
{
    public class PersonModel
    {
        public string Name { get; set; }
        public string LName { get; set; }
        public string PesonalCode { get; set; }
        public string CodeMelli { get; set; }

    }

    [Authorize]
    public class PrescriptionsController : Controller
    {
        private SamanEntities db = new SamanEntities();



        // GET: Prescriptions
        public ActionResult Index(string Id)
        {
            var model = new VIewModels.PrescriptionViewModel();

            var prescriptions = db.Prescriptions.Include(p => p.Person).Include(t => t.TreatmentType).Where(p => p.PersonId == Id);
            model.Prescriptions = prescriptions.ToList();

            //model.Treatments = db.TreatmentTypes.ToList();
            return View(model);
        }

        // GET: Prescriptions/Details/5
        public ActionResult Details(int id)
        {
            if (id == 0)
            {
                return View("Search");

            }
            int Id = id;
            Prescription prescription = db.Prescriptions.Find(Id);
            if (prescription == null)
            {
                return View("Search");
            }
            return View(prescription);
        }

        // GET: Prescriptions/Create
        public ActionResult Create()
        {
            PrescriptionViewModel model = new PrescriptionViewModel();
            model.Treatments = db.TreatmentTypes.AsQueryable().ToList();
            model.Prescriptions = db.Prescriptions.AsQueryable().ToList().OrderByDescending(p => p.Id).Take(5);
            return View(model);
        }

        // POST: Prescriptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PrescriptionViewModel model)
        {
            if (model.Person.CodeMelli == null)
            {
                return View("Create");
            }
            model.Prescription.PersonId = model.Person.CodeMelli;
            if (ModelState.IsValid)
            {


                db.Prescriptions.Add(model.Prescription);
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateException e)
                {
                    string a = e.Message;
                }
                db.Dispose();

                db = new SamanEntities();


                var prescList = db.Prescriptions.AsQueryable().ToList().OrderByDescending(p => p.Id).Take(10);

                //  db.Prescriptions.AsQueryable().ToList().OrderByDescending(p => p.Id).Take(5);


                return View("_Prescriptions", prescList);

            }
            else
            {
                string a = ModelState.GetErrors();
            }

            return View();
        }


        // GET: Prescriptions/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == 0)
            {
                return View("Search");

            }
            int Id = id;
            Prescription prescription = db.Prescriptions.Find(Id);
            if (prescription == null)
            {
                return View("Search");
            }
            ViewBag.PersonId = new SelectList(db.Persons, "CodeMelli", "Name", prescription.PersonId);
            ViewBag.TreatmentType = new SelectList(db.TreatmentTypes, "Id", "Value", prescription.TreatmentType);
            return View(prescription);
        }

        // POST: Prescriptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,Price,Payable,SentDate,Period,TreatmentType,PersonId")] Prescription prescription)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prescription).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateException e)
                {
                    var a = e.InnerException;

                }
                return RedirectToAction("Search");
            }
            ViewBag.PersonId = new SelectList(db.Persons, "CodeMelli", "Name", prescription.PersonId);
            ViewBag.TreatmentType = new SelectList(db.TreatmentTypes, "Id", "Value", prescription.TreatmentType);
            return View(prescription);
        }

        // GET: Prescriptions/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prescription prescription = db.Prescriptions.Find(id);
            if (prescription == null)
            {
                return HttpNotFound();
            }
            return View(prescription);
        }

        // POST: Prescriptions/Delete/5
        [HttpPost]

        public ActionResult DeleteConfirmed(int id)
        {
            Prescription prescription = db.Prescriptions.Find(id);
            db.Prescriptions.Remove(prescription);
            db.SaveChanges();
            //  return PartialView("_Prescriptions");
            /*  return Json(new
              {
                  Success = true

              }); */
            return RedirectToAction("Search");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        [HttpPost]
        [AjaxOnly]
        public ActionResult GetPerson(string PersonalCode)
        {
            PersonRepository blPerson = new PersonRepository();

            var model = new Person();

            model = blPerson.Where(p => p.PesonalCode == PersonalCode).Single();

            var newModel = new PersonModel();
            newModel.CodeMelli = model.CodeMelli.Trim();
            newModel.PesonalCode = model.PesonalCode.Trim();
            newModel.Name = model.Name.Trim();
            newModel.LName = model.LName.Trim();

            try
            {
                string html = JsonConvert.SerializeObject(newModel, Formatting.None,
                      new JsonSerializerSettings()
                      {
                          ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                      });

                return Json(new
                {
                    Success = true,
                    Html = html
                });

            }
            catch (JsonException e)
            {
                var a = e.Message;

                return Json(new
                {
                    Success = false,
                    Html = ""
                });
            }
        }  // #GetPerson

        [HttpGet]
        public ActionResult Search()
        {
            var model = new PrescriptionViewModel();
            var prescList = db.Prescriptions.AsQueryable().ToList().OrderBy(p => p.Id).Take(10);
            model.Prescriptions = prescList;
            model.Treatments = db.TreatmentTypes.AsQueryable();

            return View(model);

        }

        [HttpPost]
        [AjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult Search(PrescriptionViewModel model)
        {
            return null;
            //var result = db.Prescriptions.AsQueryable();
            //if (model != null)
            //{
            //    if (!string.IsNullOrWhiteSpace(model.Prescription.PersonId))
            //        result = result.Where(x => x.PersonId.Contains(model.Prescription.PersonId));
            //    if (!string.IsNullOrWhiteSpace(model.Prescription.Person.Name))
            //        result = result.Where(x => x.Person.Name.Contains(model.Person.Name));

            //    if (!string.IsNullOrWhiteSpace(model.Prescription.Person.LName))
            //        result = result.Where(x => x.Person.LName.Contains(model.Person.LName));
            //    if (!string.IsNullOrWhiteSpace(model.Prescription.Person.FatherName))
            //        result = result.Where(x => x.Person.LName.Contains(model.Prescription.Person.FatherName));

            //    if (!string.IsNullOrWhiteSpace(model.SearchModel.PrescFromDate) && !string.IsNullOrWhiteSpace(model.SearchModel.PrescToDate))
            //    {
            //        result = result.Where(x => x.Date.CompareTo(model.SearchModel.PrescFromDate) >= 0);
            //        result = result.Where(x => x.Date.CompareTo(model.SearchModel.PrescToDate) <= 0);
            //    }

            //    if (!string.IsNullOrWhiteSpace(model.SearchModel.SentFromDate) && !string.IsNullOrWhiteSpace(model.SearchModel.SentToDate))
            //    {
            //        result = result.Where(x => x.SentDate.CompareTo(model.SearchModel.SentFromDate) >= 0);
            //        result = result.Where(x => x.SentDate.CompareTo(model.SearchModel.SentToDate) <= 0);
            //    }

            //    if (model.Prescription.Payable != 0)
            //    {
            //        result = result.Where(x => x.Payable.ToString().Contains(model.Prescription.Payable.ToString()));
            //    }

            //    if (model.Prescription.Price != 0)
            //    {
            //        result = result.Where(x => x.Price.ToString().Contains(model.Prescription.Price.ToString()));
            //    }


            //    return PartialView("_Prescriptions", result);
            //}
            //else
            //{
            //    return View();
            //}
        }

    }
}




