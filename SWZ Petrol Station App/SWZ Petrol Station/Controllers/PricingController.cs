using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWZ_Petrol_Station.Controllers
{
    public class PricingController : Controller
    {
        DB_9D7C73_karolwieczorek9Entities1 db = new DB_9D7C73_karolwieczorek9Entities1();

        // GET: Pricing
        public ActionResult Index() {
            return View();
        }

        // GET: Pricing
        public ActionResult Pricing()
        {
            ViewBag.Message = "Your pricing description page.";
            ViewData["choise"] = db.PRICELIST.FirstOrDefault();
            return View(db.PRICELIST.FirstOrDefault());
        }
    }
}