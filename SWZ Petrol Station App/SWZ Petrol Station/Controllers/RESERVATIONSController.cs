using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SWZ_Petrol_Station;

namespace SWZ_Petrol_Station.Controllers
{
    public class RESERVATIONSController : Controller
    {
        private DB_9D7C73_karolwieczorek9Entities1 db = new DB_9D7C73_karolwieczorek9Entities1();

        // GET: RESERVATIONS/Create
        public ActionResult CreateAReservation()
        {
            RESERVATIONS res = new RESERVATIONS();
            res.CLI_PKid = (int)Session["LogedUserID"];
            ViewBag.CLI_PKid = new SelectList(db.CLIENTS, "CLI_PKid", "CLI_LOGIN");
            ViewBag.POS_PKid = new SelectList(db.POSITION_SERVICE, "POS_PKid", "POS_NAME");
            return View();
        }

        // POST: RESERVATIONS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAReservation([Bind(Include = "RES_PKid,RES_DATE_TERM")] RESERVATIONS rESERVATIONS)
        {
            var time = rESERVATIONS.RES_DATE_TERM;
            var list = db.RESERVATIONS.Where(r => r.RES_DATE_TERM >= time);// && r.RES_DATE_TERM.AddHours(1) < time);
            if(list.Count() == 0)
            {
                rESERVATIONS.RES_RESERVATION_DATE = DateTime.Now;
                rESERVATIONS.CLI_PKid = (int)Session["LogedUserID"];
                rESERVATIONS.POS_PKid = 1;

                if (ModelState.IsValid)
                {
                    db.RESERVATIONS.Add(rESERVATIONS);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.CLI_PKid = new SelectList(db.CLIENTS, "CLI_PKid", "CLI_LOGIN", rESERVATIONS.CLI_PKid);
            ViewBag.POS_PKid = new SelectList(db.POSITION_SERVICE, "POS_PKid", "POS_NAME", rESERVATIONS.POS_PKid);

            return View(rESERVATIONS);
        }

        // GET: RESERVATIONS
        public ActionResult Index()
        {
            var rESERVATIONS = db.RESERVATIONS.Include(r => r.CLIENTS).Include(r => r.POSITION_SERVICE);
            return View(rESERVATIONS.ToList());
        }

        // GET: RESERVATIONS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESERVATIONS rESERVATIONS = db.RESERVATIONS.Find(id);
            if (rESERVATIONS == null)
            {
                return HttpNotFound();
            }
            return View(rESERVATIONS);
        }

        // GET: RESERVATIONS/Create
        public ActionResult Create()
        {
            ViewBag.CLI_PKid = new SelectList(db.CLIENTS, "CLI_PKid", "CLI_LOGIN");
            ViewBag.POS_PKid = new SelectList(db.POSITION_SERVICE, "POS_PKid", "POS_NAME");
            return View();
        }

        // POST: RESERVATIONS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RES_PKid,RES_RESERVATION_DATE,RES_DATE_TERM,POS_PKid,CLI_PKid")] RESERVATIONS rESERVATIONS)
        {
            if (ModelState.IsValid)
            {
                db.RESERVATIONS.Add(rESERVATIONS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CLI_PKid = new SelectList(db.CLIENTS, "CLI_PKid", "CLI_LOGIN", rESERVATIONS.CLI_PKid);
            ViewBag.POS_PKid = new SelectList(db.POSITION_SERVICE, "POS_PKid", "POS_NAME", rESERVATIONS.POS_PKid);
            return View(rESERVATIONS);
        }

        // GET: RESERVATIONS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESERVATIONS rESERVATIONS = db.RESERVATIONS.Find(id);
            if (rESERVATIONS == null)
            {
                return HttpNotFound();
            }
            ViewBag.CLI_PKid = new SelectList(db.CLIENTS, "CLI_PKid", "CLI_LOGIN", rESERVATIONS.CLI_PKid);
            ViewBag.POS_PKid = new SelectList(db.POSITION_SERVICE, "POS_PKid", "POS_NAME", rESERVATIONS.POS_PKid);
            return View(rESERVATIONS);
        }

        // POST: RESERVATIONS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RES_PKid,RES_RESERVATION_DATE,RES_DATE_TERM,POS_PKid,CLI_PKid")] RESERVATIONS rESERVATIONS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rESERVATIONS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CLI_PKid = new SelectList(db.CLIENTS, "CLI_PKid", "CLI_LOGIN", rESERVATIONS.CLI_PKid);
            ViewBag.POS_PKid = new SelectList(db.POSITION_SERVICE, "POS_PKid", "POS_NAME", rESERVATIONS.POS_PKid);
            return View(rESERVATIONS);
        }

        // GET: RESERVATIONS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RESERVATIONS rESERVATIONS = db.RESERVATIONS.Find(id);
            if (rESERVATIONS == null)
            {
                return HttpNotFound();
            }
            return View(rESERVATIONS);
        }

        // POST: RESERVATIONS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RESERVATIONS rESERVATIONS = db.RESERVATIONS.Find(id);
            db.RESERVATIONS.Remove(rESERVATIONS);
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
