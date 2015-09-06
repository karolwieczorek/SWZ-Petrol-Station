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
    public class PRICELISTsController : Controller
    {
        private DB_9D7C73_karolwieczorek9Entities1 db = new DB_9D7C73_karolwieczorek9Entities1();

        // GET: PRICELISTs
        public ActionResult Index()
        {
            var pRICELIST = db.PRICELIST.Include(p => p.SERVICE);
            return View(pRICELIST.ToList());
        }

        // GET: PRICELISTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRICELIST pRICELIST = db.PRICELIST.Find(id);
            if (pRICELIST == null)
            {
                return HttpNotFound();
            }
            return View(pRICELIST);
        }

        // GET: PRICELISTs/Create
        public ActionResult Create()
        {
            ViewBag.SER_PKid = new SelectList(db.SERVICE, "SER_PKid", "SER_NAME");
            return View();
        }

        // POST: PRICELISTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PRL_PKid,PRL_UNIT,PRL_PRICE,PRL_LOYALTY_POINTS_AMOUNT,SER_PKid")] PRICELIST pRICELIST)
        {
            if (ModelState.IsValid)
            {
                db.PRICELIST.Add(pRICELIST);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SER_PKid = new SelectList(db.SERVICE, "SER_PKid", "SER_NAME", pRICELIST.SER_PKid);
            return View(pRICELIST);
        }

        // GET: PRICELISTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRICELIST pRICELIST = db.PRICELIST.Find(id);
            if (pRICELIST == null)
            {
                return HttpNotFound();
            }
            ViewBag.SER_PKid = new SelectList(db.SERVICE, "SER_PKid", "SER_NAME", pRICELIST.SER_PKid);
            return View(pRICELIST);
        }

        // POST: PRICELISTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PRL_PKid,PRL_UNIT,PRL_PRICE,PRL_LOYALTY_POINTS_AMOUNT,SER_PKid")] PRICELIST pRICELIST)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRICELIST).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SER_PKid = new SelectList(db.SERVICE, "SER_PKid", "SER_NAME", pRICELIST.SER_PKid);
            return View(pRICELIST);
        }

        // GET: PRICELISTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRICELIST pRICELIST = db.PRICELIST.Find(id);
            if (pRICELIST == null)
            {
                return HttpNotFound();
            }
            return View(pRICELIST);
        }

        // POST: PRICELISTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRICELIST pRICELIST = db.PRICELIST.Find(id);
            db.PRICELIST.Remove(pRICELIST);
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
