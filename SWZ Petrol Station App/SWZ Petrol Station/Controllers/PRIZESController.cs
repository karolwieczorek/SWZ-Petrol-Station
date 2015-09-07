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
    public class PRIZESController : Controller
    {
        private DB_9D7C73_karolwieczorek9Entities1 db = new DB_9D7C73_karolwieczorek9Entities1();

        // GET: PRIZES
        public ActionResult Index()
        {
            return View(db.PRIZES.ToList());
        }

        // GET: PRIZES/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRIZES pRIZES = db.PRIZES.Find(id);
            if (pRIZES == null)
            {
                return HttpNotFound();
            }
            return View(pRIZES);
        }

        // GET: PRIZES/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PRIZES/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRI_PKid,PRI_NAME,PRI_NUMBER_OF_POINTS")] PRIZES pRIZES)
        {
            if (ModelState.IsValid)
            {
                db.PRIZES.Add(pRIZES);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pRIZES);
        }

        // GET: PRIZES/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRIZES pRIZES = db.PRIZES.Find(id);
            if (pRIZES == null)
            {
                return HttpNotFound();
            }
            return View(pRIZES);
        }

        // POST: PRIZES/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRI_PKid,PRI_NAME,PRI_NUMBER_OF_POINTS")] PRIZES pRIZES)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRIZES).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pRIZES);
        }

        // GET: PRIZES/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRIZES pRIZES = db.PRIZES.Find(id);
            if (pRIZES == null)
            {
                return HttpNotFound();
            }
            return View(pRIZES);
        }

        // POST: PRIZES/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRIZES pRIZES = db.PRIZES.Find(id);
            db.PRIZES.Remove(pRIZES);
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
