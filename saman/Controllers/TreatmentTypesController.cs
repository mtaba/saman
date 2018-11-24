using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using saman.Models.DomainModels;
using saman.VIewModels;

namespace saman.Controllers
{
    public class TreatmentTypesController : Controller
    {
        private SamanEntities db = new SamanEntities();

        // GET: TreatmentTypes
        public ActionResult Index()
        {
            var model = new VIewModels.TreatmentViewModel();
            model.Treatments = db.TreatmentTypes.ToList();

            return View(model);
            
        }

        // POST: TreatmentTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AjaxOnly]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TreatmentViewModel treatmentType)
        {
            if (ModelState.IsValid)
            {
                db.TreatmentTypes.Add(treatmentType.Treatment);
                db.SaveChanges();
                return PartialView("_Treatmentlist", db.TreatmentTypes.ToList());
                // return RedirectToAction("Index");
            }

            return View(treatmentType);
        }

        // GET: TreatmentTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TreatmentType treatmentType = db.TreatmentTypes.Find(id);
            if (treatmentType == null)
            {
                return HttpNotFound();
            }
            return View(treatmentType);
        }

        // POST: TreatmentTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Value")] TreatmentType treatmentType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(treatmentType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(treatmentType);
        }

     

        // POST: TreatmentTypes/Delete/5
        [HttpGet, ActionName("Delete")]
      
        public ActionResult DeleteConfirmed(int id)
        {
            TreatmentType treatmentType = db.TreatmentTypes.Find(id);
            db.TreatmentTypes.Remove(treatmentType);
            db.SaveChanges();
            return RedirectToAction("Index");
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
