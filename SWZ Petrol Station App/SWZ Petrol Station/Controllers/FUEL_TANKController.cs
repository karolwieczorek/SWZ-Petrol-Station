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
    public class FUEL_TANKController : Controller
    {
        private DB_9D7C73_karolwieczorek9Entities1 db = new DB_9D7C73_karolwieczorek9Entities1();

        // GET: FUEL_TANK/Details/5
        public ActionResult TankMonitoring(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            FUEL_TANK fUEL_TANK = new FUEL_TANK();
            //fUEL_TANK.FUE_PKid

            fUEL_TANK.FUE_NUMBER = id;

            return View(fUEL_TANK);
        }

        // POST: FUEL_TANK/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TankMonitoring([Bind(Include = "FUE_PKid")] FUEL_TANK fUEL_TANK, int amount, int pressure, int temperature, int id)
        {
            fUEL_TANK.FUE_DATE = DateTime.Now;
            fUEL_TANK.FUE_AMOUNT = amount;
            fUEL_TANK.FUE__PRESSURE = pressure;
            fUEL_TANK.FUE_NUMBER = id;
            fUEL_TANK.FUE_TEMPERATURE = temperature;

            if (ModelState.IsValid)
            {
                db.FUEL_TANK.Add(fUEL_TANK);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fUEL_TANK);
        }

        // GET: FUEL_TANK
        public ActionResult Index()
        {
            return View(db.FUEL_TANK.ToList());
        }

        // GET: FUEL_TANK/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FUEL_TANK fUEL_TANK = db.FUEL_TANK.Find(id);
            if (fUEL_TANK == null)
            {
                return HttpNotFound();
            }
            return View(fUEL_TANK);
        }

        // GET: FUEL_TANK/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FUEL_TANK/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FUE_PKid,FUE_NUMBER,FUE_DATE,FUE__PRESSURE,FUE_TEMPERATURE,FUE_AMOUNT")] FUEL_TANK fUEL_TANK)
        {
            if (ModelState.IsValid)
            {
                db.FUEL_TANK.Add(fUEL_TANK);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fUEL_TANK);
        }

        // GET: FUEL_TANK/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FUEL_TANK fUEL_TANK = db.FUEL_TANK.Find(id);
            if (fUEL_TANK == null)
            {
                return HttpNotFound();
            }
            return View(fUEL_TANK);
        }

        // POST: FUEL_TANK/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FUE_PKid,FUE_NUMBER,FUE_DATE,FUE__PRESSURE,FUE_TEMPERATURE,FUE_AMOUNT")] FUEL_TANK fUEL_TANK)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fUEL_TANK).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fUEL_TANK);
        }

        // GET: FUEL_TANK/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FUEL_TANK fUEL_TANK = db.FUEL_TANK.Find(id);
            if (fUEL_TANK == null)
            {
                return HttpNotFound();
            }
            return View(fUEL_TANK);
        }

        // POST: FUEL_TANK/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FUEL_TANK fUEL_TANK = db.FUEL_TANK.Find(id);
            db.FUEL_TANK.Remove(fUEL_TANK);
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
