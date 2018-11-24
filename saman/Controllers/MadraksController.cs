using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using saman.Models.DomainModels;
using System.Data.Entity;
using System.Net;
using saman.VIewModels;

namespace saman.Controllers
{
    [Authorize]
    public class MadraksController : Controller
    {
        private SamanEntities db = new SamanEntities();
        // GET: Madraks
        // GET: Jobs
        public ActionResult Index(string id)
        {
            if (id != null)
            {

                VIewModels.PersonMadrakViewModel model = new VIewModels.PersonMadrakViewModel();
                model.Madraks = db.Mardraks.ToList();
                model.PersonMadraks = db.Person_Madraks.Where(pm => pm.PersonId == id).ToList();
             

                TempData["PersonId"] = id;
                return View(model);
            }
            else
            {
                return RedirectToAction("PersonList");
            }
        }

        public ActionResult PersonList()
        {
            return View(db.Persons.Where(p => p.Nesbat == null).ToList());
        }

        [HttpPost]
        [AjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PersonMadrakViewModel entity )
        {
            TempData.Keep();
            string id = TempData["PersonId"].ToString();
            if (ModelState.IsValid)
            {
                try
                {
                    entity.PersonMadrak.PersonId = id;
                         
                    db.Person_Madraks.Add(entity.PersonMadrak);

                    db.SaveChanges();

                  //  db.Entry(entity).State = EntityState.Detached;
                    var model = db.Person_Madraks.Where(j => j.PersonId == id).ToList().OrderByDescending(e => e.Id);

                    return PartialView("_MadrakList",model );
                }
                catch
                {
                    ViewBag.message = "خطا در برقرای ارتباط با پایکاه داده";
                    return RedirectToAction("Index", "Madraks", new { id = id });
                }
            }
            else
            {
                ViewBag.message = "مقادیر ورودی معتبر نیست";
                return RedirectToAction("Index", "Madraks", new { id = id });
            }

        }



        // GET: Jobs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("PersonList");
            }
            Person_Madraks entity = db.Person_Madraks.Find(id);


            if (entity == null)
            {
                return RedirectToAction("PersonList");
            }
            PersonMadrakViewModel model = new PersonMadrakViewModel();
            model.PersonMadrak = entity;
            model.Madraks = db.Mardraks.ToList();
            TempData["PersonId"] = entity.PersonId;
            TempData["entityId"] = entity.Id;
            return View(model);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PersonMadrakViewModel entity)
        {
            if (ModelState.IsValid)
            {

                entity.PersonMadrak.PersonId = (TempData["PersonId"]).ToString();
                entity.PersonMadrak.Id = (int)TempData["entityId"];
                
                try
                {
                    db.Entry(entity.PersonMadrak).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Madraks", new { id = entity.PersonMadrak.PersonId });
                }
                catch
                {

                }
            }
            return View(entity);
        }

        // GET: Jobs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person_Madraks entity = db.Person_Madraks.Find(id);

            if (entity == null)
            {
                return HttpNotFound();
            }
            return View(entity);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Job job = db.Jobs.Find(id);
            db.Jobs.Remove(job);
            db.SaveChanges();
            return RedirectToAction("Index");
        }





    }
}