using saman.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using saman.Models.DomainModels;
using saman.VIewModels;

using Newtonsoft.Json;


namespace saman.Controllers
{
    public class Result
    {
        public string Name { get; set; }
    }
    [Authorize]
    public class AdminController : Controller
    {
        PersonRepository blPerson = new PersonRepository();
        RetirementTypeRepository blretirement = new RetirementTypeRepository();


        // GET: Admin
        public ActionResult Index()
        {


            return View();
        }

        public ActionResult Persons()
        {
            
            return View(blPerson.Select());
        }


        // GET: Admin/Create
        [HttpGet]
        public ActionResult AddPerson()
        {
            PersonViewModel model = new PersonViewModel();
            model.Companies = blCompany.Select();

            return View(model);
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult AddPerson(PersonViewModel model)
        {
            model.Person.BSKind = "31";
            if (ModelState.IsValid)
            {
                if (blPerson.Add(model))
                {

                    TempData["Addresult"] = "ok";
                    return RedirectToAction("Persons");
                }
                else
                {
                    ViewBag.TheResult = false;
                    return View();
                }
            }
            else
            {
                return View();
            }
        }


        // GET: Admin/Delete/5
        public ActionResult DeletePerson(string id)
        {

            if (blPerson.Delete(id))
            {
                return View("Persons", blPerson.Select());

            }
            else
            {
                return View(blPerson.Select());

            }

        }


        public class JsonData
        {
            public string Script { get; set; }
            public string Html { get; set; }
            public bool Success { get; set; }
        }

       

        // GET: Admin/Details/5
        public ActionResult DetailsPerson(string id)
        {
            var model = blPerson.Find(id);
            return View(model);
        }



        // GET: Admin/EditPerson/5
        public ActionResult EditPerson(string id)
        {
            var model = blPerson.Find(id);
            return View(model);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult EditPerson(Person person)
        {
            // TODO: Add update logic here
            if (blPerson.Update(person))
            {
                ViewBag.TheResult = true;
                return RedirectToAction("Persons");
            }
            else
            {
                ViewBag.TheResult = false;
                return View();
            }
        }

        [HttpPost]
        public JsonResult checkDoubleNationalCode(string CodeMelli)
        {


            var user = blPerson.Find(CodeMelli);
            if (user == null)
                return Json(true);
            else return Json(false);

        }

        // GET: 
        [HttpGet]
        public ActionResult ReportPerson()
        {
            var model = new PersonSearchViewModel();
            model.Companies = blCompany.Select();

            return View(model);
        }

        private saman.Models.DomainModels.SamanEntities db = new SamanEntities();
        [HttpPost]
        public ActionResult ReportPerson(PersonSearchViewModel searchModel)
        {

            //var result = db.Persons.Join(
            //      db.Jobs,
            //      p => p.CodeMelli,
            //      j => j.PersonId,
            //       (p, j) => new { Person = p, Job = j }
            //      ).Join(
            //    db.Companies,
            //    k=>k.Job.CompaniId,
            //    c=>c.Jobs.com
            //    )

            /*   var list = db.Companies.Join(
                   db.Jobs,
                        c => c.Id,
                        j => j.CompaniId,
                        (c, j) => new { Company = c, Job = j }
                  ).Join(
                        db.Persons.Where(p => p.RetirementType == searchModel.Person.RetirementType),
                        j => j.Job.PersonId,
                        p=>p.CodeMelli,
                        (p, j) => new { Person = p , Job = j }
                   ).Select(m=>new
                   {
                       name = p.
                   }
                   );   */

            //int param = 3;

           IEnumerable<Person> people = db.Database.SqlQuery<Person>("select * from dbo.Persons as persons" +
                        " join dbo.Jobs as jobs" +
                        " on persons.CodeMelli = jobs.PersonId" +
                        " join dbo.Companies as company" +
                        " on company.Id = jobs.CompaniId " +
                        " where (company.id = 1 and persons.RetirementType = 3)");




            return PartialView("_PersonReportList", people);
        }


        /*********************** # person ***********************/

        public ActionResult Retiremen()
        {
            return View(blretirement.Select());

        }

        [HttpGet]
        public ActionResult AddRetiremen()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddRetiremen(saman.Models.DomainModels.RetirementType entity)
        {
            if (ModelState.IsValid)
            {

                if (blretirement.Add(entity))
                {
                    TempData["Addresult"] = "ok";
                    return RedirectToAction("Retiremen");
                }
                else
                {
                    ViewBag.TheResult = false;
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult DeleteRetiremen(int id)
        {
            try
            {
                if(blretirement.Delete(id))
                {
                   return RedirectToAction("Retiremen");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult EditRetiremen(int id)
        {
            if (id == 0)
                return RedirectToAction("Retiremen");
            else
            {
                var model = blretirement.Find(id);
                if (model != null)
                    return View(model);
                else
                {
                    ViewBag.Find = "false";
                    return RedirectToAction("Retiremen");
                }
            }
              
        }


        [HttpPost]
        public ActionResult EditRetiremen(RetirementType entity)
        {
            if (ModelState.IsValid)
            {
                if (blretirement.Update(entity))
                    return RedirectToAction("Retiremen");
                else
                {
                    ViewBag.Message = "خطا در بروزرسانی";
                    return View();

                }
            }
            else
            {
                ViewBag.Message = "مقدار ورودی صحیح نیست";
                return View();
            }

        }
        /*********************** # Retirement ***********************/

        CompanyRepository blCompany = new CompanyRepository();
        public ActionResult Companies()
        {

            return View(blCompany.Select());

        }

        [HttpGet]
        public ActionResult AddCompany()
        {
            var company = new CompanyRepository();

            var model = new saman.VIewModels.CompanyViewModel();
            model.Companies = company.Select().Where(p => p.ParentId == 0).ToList();

            return View(model);
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult AddCompany(saman.VIewModels.CompanyViewModel entity)
        {
            entity.Company.ParentId = 0;
            if (ModelState.IsValid)
            {

                if (blCompany.Add(entity.Company))
                {
                    var company = new CompanyRepository();

                    var model = new saman.VIewModels.CompanyViewModel();
                    model.Companies = company.Select().Where(p => p.ParentId == 0).ToList();
                    return PartialView("Companies", model.Companies);
                }
                else
                {
                    ViewBag.TheResult = false;
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult DeleteCompany(int id)
        {
            if (id == 0)
            {
                return View();
            }
            else
            {
                
                using (SamanEntities db = new SamanEntities())
                {
                    db.Companies.RemoveRange(db.Companies.Where(c => c.ParentId == id));
                    db.SaveChanges();
                }
                    if (blCompany.Delete(id))
                    {
                        return RedirectToAction("AddCompany");
                    }
                    else
                    {
                        ViewBag.TheResult = false;
                        return View();
                    }
            }
        }

        [HttpGet]
        public ActionResult AddSubCompany(int Id)
        {
            var company = new CompanyRepository();
            TempData["parentId"] = Id;
            var model = new CompanyViewModel();
            model.Companies = company.Select().Where(p => p.ParentId == Id).ToList();
            model.Company = new Company();
            model.Company.ParentId = Id;

            return View(model);
        }


        [HttpPost]
        [AjaxOnly]
        public ActionResult AddSubCompany(saman.VIewModels.CompanyViewModel entity)
        {

            if (ModelState.IsValid)
            {

                if (blCompany.Add(entity.Company))
                {
                    var company = new CompanyRepository();

                    var model = new saman.VIewModels.CompanyViewModel();
                    model.Companies = company.Select().Where(p => p.ParentId == entity.Company.ParentId).ToList();

                    return PartialView("SubCompanies", model.Companies);
                }
                else
                {
                    ViewBag.TheResult = false;
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult DeleteSubCompany(int id)
        {
            if (id == 0)
            {
                return View();
            }
            else
            {
                int parentId =  blCompany.Find(id).ParentId;
                if (blCompany.Delete(id))
                { 
                  return  RedirectToAction("AddSubCompany","Admin",new { Id= parentId});              
                }
                else
                {
                    ViewBag.TheResult = false;
                    return View();
                }
            }
        }
        [HttpGet]
        public ActionResult EditCompany(int id)
        {
            if (id == 0)
                return RedirectToAction("AddCompany");
            else
            {
                var model = blCompany.Find(id);
                if (model != null)
                    return View(model);
                else
                {
                    ViewBag.Find = "false";
                    return RedirectToAction("AddCompany");
                }
            }

        }

        /*
        // Edit Company 
        */

        [HttpPost]
        public ActionResult EditCompany(Company entity)
        {
            if (ModelState.IsValid)
            {
                if (blCompany.Update(entity))
                    return RedirectToAction("AddCompany");
                else
                {
                    ViewBag.Message = "خطا در بروزرسانی";
                    return View();

                }
            }
            else
            {
                ViewBag.Message = "مقدار ورودی صحیح نیست";
                return View();
            }

        }

        /*
       // Edit Company 
       */


        [HttpGet]
        public ActionResult EditSubCompany(int id)
        {
            if (id == 0)
                return RedirectToAction("AddSubCompany");
            else
            {
                var model = blCompany.Find(id);
                TempData["ParentID"] = model.ParentId;
                if (model != null)
                    return View(model);
                else
                {
                    ViewBag.Find = "false";
                    return RedirectToAction("AddSubCompany");
                }
            }

        }


        [HttpPost]
        public ActionResult EditSubCompany(Company entity)
        {
            if (ModelState.IsValid)
            {
                int ParentId = Convert.ToInt32(TempData["ParentID"]);
                entity.ParentId = ParentId;
                if (blCompany.Update(entity))
                {
                 //   int parentId = blCompany.Find(entity.Id).ParentId;
                    return RedirectToAction("AddSubCompany", "Admin", new { Id = ParentId });
                  //  return RedirectToAction("AddSubCompany");
                }
                else
                {
                    ViewBag.Message = "خطا در بروزرسانی";
                    return View();

                }
            }
            else
            {
                ViewBag.Message = "مقدار ورودی صحیح نیست";
                return View();
            }

        }


        [HttpPost]
        [AjaxOnly]
        public ActionResult GetCityList(int CompanyId)
        {  
            return Json(new {
                Success = true,
                Html = JsonConvert.SerializeObject(blCompany.Select().Where(p => p.ParentId == CompanyId).ToList())
            });
        }

       

        /****************** #Company *****************/
        /***Add Person madrak***/
        
         public ActionResult AddPersonMadrak()
        {

            return View();
        }
        /**************/
       
        /****************** Bank *****************/

        BankRepository blBank = new BankRepository();
        
        public ActionResult Banks()
        {
            return View(blBank.Select());

        }

        [HttpGet]
        public ActionResult AddBank()
        {

            var model = new saman.VIewModels.BankViewModel();
            model.Banks = blBank.Select().ToList();

            return View(model);
        }


        [HttpPost]
        [AjaxOnly]
        public ActionResult AddBank(BankViewModel entity)
        {
       
            if (ModelState.IsValid)
            {

                if (blBank.Add(entity.Bank))
                {
                    var company = new CompanyRepository();

                    var model = new saman.VIewModels.BankViewModel();
                    model.Banks = blBank.Select().ToList();


                    return PartialView("_Banks", model.Banks);
                }
                else
                {
                    ViewBag.TheResult = false;
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
    
        public ActionResult EditBank(int id)
        {
            if (id == 0)
                return RedirectToAction("Banks");
            else
            {
                var model = blBank.Find(id);
                if (model != null)
                    return View(model);
                else
                {
                    ViewBag.Find = "false";
                    return RedirectToAction("Banks");
                }
            }

        }


        [HttpPost]
        public ActionResult EditBank(Bank entity)
        {
            if (ModelState.IsValid)
            {
                if (blBank.Update(entity))
                    return RedirectToAction("AddBank");
                else
                {
                    ViewBag.Message = "خطا در بروزرسانی";
                    return View();

                }
            }
            else
            {
                ViewBag.Message = "مقدار ورودی صحیح نیست";
                return View();
            }

        }

    }
}




