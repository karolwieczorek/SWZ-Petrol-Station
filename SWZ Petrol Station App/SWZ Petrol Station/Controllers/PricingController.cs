using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SWZ_Petrol_Station.Controllers
{
    public class PricingController : Controller
    {

        // GET: Pricing
        public ActionResult Index() {
            return View();
        }

        // GET: Pricing
        public ActionResult Pricing()
        {
            ViewBag.Message = "Your pricing description page.";
            
            return View();
        }
    }
}