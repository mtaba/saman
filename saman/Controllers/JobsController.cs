using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using saman.Models.DomainModels;
using Newtonsoft.Json;

namespace saman.Controllers
{
    [Authorize]
    public class JobsController : Controller
    {
        private SamanEntities db = new SamanEntities();

        public ActionResult PersonList()
        {
            return View(db.Persons.Where(p => p.Nesbat == null).ToList());
        }

        // GET: Jobs
        public ActionResult Index(string id)
        {
            if (id != null)
            {
             
                VIewModels.JobViewModel model = new VIewModels.JobViewModel();
                model.Companies = db.Companies.ToList();
                model.Jobs = db.Jobs.Where(j => j.PersonId == id).ToList();
             
                TempData["PersonId"] = id;
                return View(model);
            }
            else
            {
                return RedirectToAction("PersonList");
            }
        }

        // GET: Jobs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // GET: Jobs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Job job)
        {
            TempData.Keep();
            string id = TempData["PersonId"].ToString();
            if (ModelState.IsValid)
            {
                try {
                    job.PersonId = id;
                    db.Jobs.Add(job);
                    db.SaveChanges();
                    return PartialView("_JobsList",db.Jobs.Where(j=>j.PersonId==id).ToList().OrderByDescending(e=>e.Id));
                }
                catch
                {
                    ViewBag.message = "خطا در برقرای ارتباط با پایکاه داده";
                    return RedirectToAction("Index","Jobs", new { id = id });
                }
            }
            else
            {
                ViewBag.message = "مقادیر ورودی معتبر نیست";
                return RedirectToAction("Index", "Jobs", new { id = id });
            }

           
        }

        // GET: Jobs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("PersonList");
            }
            Job job = db.Jobs.Find(id);
           

            if (job == null)
            {
                return RedirectToAction("PersonList");
            }
            saman.VIewModels.JobViewModel model = new VIewModels.JobViewModel();
            model.Job = job;
            model.Companies = db.Companies.ToList();
            TempData["PersonId"] = job.PersonId;
            TempData["JobId"] = job.Id;
            return View(model);
        }

        // POST: Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Position,StartDate,EndDate,Description,PersonId,CompaniId")] Job job)
        {
            if (ModelState.IsValid)
            {
            
                job.PersonId = (TempData["PersonId"]).ToString();
                job.Id= (int)TempData["JobId"];
                try
                {
                    db.Entry(job).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index", "Jobs", new { id = job.PersonId });
                }
                catch
                {

                }
            }
            return View(job);
        }

        // GET: Jobs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = db.Jobs.Find(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }



        
        // POST: Jobs/Delete/5
        [HttpGet, ActionName("Delete")]
     //   [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Job job = db.Jobs.Find(id);
            try
            {
                db.Jobs.Remove(job);
                db.SaveChanges();
                return RedirectToAction("Index", "Jobs", new { id = job.PersonId });
            }
            catch
            {
                return View("Error");
            }
            
        }


      

       
    }
}
