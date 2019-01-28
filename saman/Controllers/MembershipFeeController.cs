using System;
using System.Linq;
using System.Web.Mvc;
using saman.VIewModels;
using saman.Models.Repositories;
using Newtonsoft.Json;


namespace saman.Controllers
{
    [Authorize]
    public class MembershipFeeController : Controller
    {
        ChequeRepository blCheque = new ChequeRepository();
         
        public ActionResult Index()
        {
           var model = new MembershipFeeViewModel();
            return View( model);
        }

        
        public ActionResult Create()
        {
           return View();
        }

        public class JsonData
        {
            public string Script { get; set; }
            public string Html { get; set; }
            public bool Success { get; set; }
        }

        MembershipRepository blMembership = new MembershipRepository();
        [HttpPost]
       
        public ActionResult Create(saman.VIewModels.MembershipFeeViewModel model)
        {
            var payment = blMembership.Where(p=>(p.StartDate == model.MembershipPayment.StartDate) && (p.EndDate == model.MembershipPayment.EndDate) && (p.PersonId==model.Person.CodeMelli) && (p.Reason==model.MembershipPayment.Reason )).Select(c=>c.Id).AsQueryable().SingleOrDefault();
            int Id;
            if ( payment== 0)  // means payment not exits
            {
                if (blMembership.Add(model))
                {
                     Id = Convert.ToInt32(blMembership.TempData["paymentId"]);
                     return RedirectToAction("Create", "Cheques",new { Id });
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
                return RedirectToAction("Create", "Cheques",new {Id });
            }   //#else
            }     
         
        [HttpPost]
        [AjaxOnly]
        public ActionResult GetPerson(string NationalCode, string Name, string LName)
        {
            PersonRepository blPerson = new PersonRepository();
            // baraye inke list toolani nashavad faghat 5 record
            var model = blPerson.Where(p=>p.CodeMelli.Contains(NationalCode) && (p.Name.Contains(Name)) && (p.LName.Contains(LName))).Take(5).ToList();

            string html = JsonConvert.SerializeObject(model, Formatting.None,
                  new JsonSerializerSettings()
                  {
                      ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                  });
            return Json(new
            {
                Success = true,
                Html = html
            }
        );
            //  return PartialView("_Persons", model)
        }
       
        public ActionResult DeleteCheque(string Id)
        {
            if (Id == null)
            {
                return View();
            }
            else  // if id!=null
            {
                string[] values = Id.Split('@');
                string chequeId = values[0];
                int paymentId = Convert.ToInt32(values[1]);

                if (blCheque.Delete(chequeId))
                {
                    var cheques = blCheque.Select().Where(c => c.PaymentId == paymentId).ToList();

                    string html = JsonConvert.SerializeObject(cheques, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                    return Json(
                        new { Success = true, Html = html }
                        );
                    //  return PartialView("_Cheques", cheques);

                    //  return  RedirectToAction("Create", paymentId);
                }    //# if
                else
                {
                    return View();
                }
            } //#end else
        }

        [HttpGet]
        public ActionResult Search()
        {
            MembershipFeeViewModel model =new MembershipFeeViewModel();
            return View(model);
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult Search(MembershipFeeViewModel model)
        {
            return PartialView("_Payments", blMembership.Search(model.SearchModel));
        }

        [HttpGet]
        public ActionResult Report()
        {
            MembershipFeeViewModel model = new MembershipFeeViewModel();
            return View(model);
        }

        [HttpGet]
        public ActionResult InsuranceReport()
        {
            MembershipFeeViewModel model = new MembershipFeeViewModel();
            return View(model);
        }

        [HttpPost]
        [AjaxOnly]
        public ActionResult Report(MembershipFeeViewModel model)
        {

          //  model.SearchModel.Reason = 0; // حق عضویت
            return PartialView("_Payments", blMembership.Report(model.SearchModel));
        }
    }
}