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
    public class TRANSACTIONSController : Controller
    {
        private DB_9D7C73_karolwieczorek9Entities1 db = new DB_9D7C73_karolwieczorek9Entities1();

        #region custom
        // GET: TRANSACTIONS/Create
        public ActionResult Buy(int? id) {
            Session["PricelistID"] = id;
            return View();
        }

        // POST: TRANSACTIONS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Buy([Bind(Include = "TRA_AMOUNT")] TRANSACTIONS tRANSACTIONS) {
            tRANSACTIONS.TRA_DATE = System.DateTime.Now;
            tRANSACTIONS.TRA_NAME = "Name";
            tRANSACTIONS.TRA_ALL = "ALL";
            int prizeId = (int)Session["PricelistID"];
            tRANSACTIONS.CLI_PKid = (int)Session["LogedUserID"];
            tRANSACTIONS.PRL_PKid = prizeId; Session["PricelistID"] = null;
            //int id = db.TRANSACTIONS.Max(t => tRANSACTIONS.TRA_PKid);
            int id = (int)Session["LogedUserID"];
            CLIENTS client = db.CLIENTS.Where(a => a.CLI_PKid.Equals(id)).FirstOrDefault();
            int poinstMultiplayer = db.PRICELIST.Where(p => p.PRL_PKid.Equals(prizeId)).FirstOrDefault().PRL_LOYALTY_POINTS_AMOUNT;
            client.CLI_POINTS += tRANSACTIONS.TRA_AMOUNT * poinstMultiplayer;
            
            if (ModelState.IsValid) {
                db.TRANSACTIONS.Add(tRANSACTIONS);
                db.Entry(client).State = EntityState.Modified;
                try {
                    db.SaveChanges();
                } catch (Exception exception) {

                }

                return RedirectToAction("History", new { id = (int)Session["LogedUserID"] });
            }

            ViewBag.CLI_PKid = new SelectList(db.CLIENTS, "CLI_PKid", "CLI_LOGIN", tRANSACTIONS.CLI_PKid);
            ViewBag.PRL_PKid = new SelectList(db.PRICELIST, "PRL_PKid", "PRL_UNIT", tRANSACTIONS.PRL_PKid);
            return View(tRANSACTIONS);
        }

        public ActionResult History(int id) {
            var tRANSACTIONS = db.TRANSACTIONS.Where(t => t.CLI_PKid == id).Include(t => t.CLIENTS).Include(t => t.PRICELIST);
            return View(tRANSACTIONS.ToList());
        }

        #endregion
        #region basic
        // GET: TRANSACTIONS
        public ActionResult Index()
        {
            var tRANSACTIONS = db.TRANSACTIONS.Include(t => t.CLIENTS).Include(t => t.PRICELIST);
            return View(tRANSACTIONS.ToList());
        }

        // GET: TRANSACTIONS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRANSACTIONS tRANSACTIONS = db.TRANSACTIONS.Find(id);
            if (tRANSACTIONS == null)
            {
                return HttpNotFound();
            }
            return View(tRANSACTIONS);
        }

        // GET: TRANSACTIONS/Create
        public ActionResult Create()
        {
            ViewBag.CLI_PKid = new SelectList(db.CLIENTS, "CLI_PKid", "CLI_LOGIN");
            ViewBag.PRL_PKid = new SelectList(db.PRICELIST, "PRL_PKid", "PRL_UNIT");
            return View();
        }

        // POST: TRANSACTIONS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TRA_PKid,TRA_NAME,TRA_DATE,TRA_INVOICED,TRA_AMOUNT,TRA_ALL,PRL_PKid,CLI_PKid")] TRANSACTIONS tRANSACTIONS)
        {
            if (ModelState.IsValid)
            {
                db.TRANSACTIONS.Add(tRANSACTIONS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CLI_PKid = new SelectList(db.CLIENTS, "CLI_PKid", "CLI_LOGIN", tRANSACTIONS.CLI_PKid);
            ViewBag.PRL_PKid = new SelectList(db.PRICELIST, "PRL_PKid", "PRL_UNIT", tRANSACTIONS.PRL_PKid);
            return View(tRANSACTIONS);
        }

        // GET: TRANSACTIONS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRANSACTIONS tRANSACTIONS = db.TRANSACTIONS.Find(id);
            if (tRANSACTIONS == null)
            {
                return HttpNotFound();
            }
            ViewBag.CLI_PKid = new SelectList(db.CLIENTS, "CLI_PKid", "CLI_LOGIN", tRANSACTIONS.CLI_PKid);
            ViewBag.PRL_PKid = new SelectList(db.PRICELIST, "PRL_PKid", "PRL_UNIT", tRANSACTIONS.PRL_PKid);
            return View(tRANSACTIONS);
        }

        // POST: TRANSACTIONS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TRA_PKid,TRA_NAME,TRA_DATE,TRA_INVOICED,TRA_AMOUNT,TRA_ALL,PRL_PKid,CLI_PKid")] TRANSACTIONS tRANSACTIONS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tRANSACTIONS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CLI_PKid = new SelectList(db.CLIENTS, "CLI_PKid", "CLI_LOGIN", tRANSACTIONS.CLI_PKid);
            ViewBag.PRL_PKid = new SelectList(db.PRICELIST, "PRL_PKid", "PRL_UNIT", tRANSACTIONS.PRL_PKid);
            return View(tRANSACTIONS);
        }

        // GET: TRANSACTIONS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TRANSACTIONS tRANSACTIONS = db.TRANSACTIONS.Find(id);
            if (tRANSACTIONS == null)
            {
                return HttpNotFound();
            }
            return View(tRANSACTIONS);
        }

        // POST: TRANSACTIONS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TRANSACTIONS tRANSACTIONS = db.TRANSACTIONS.Find(id);
            db.TRANSACTIONS.Remove(tRANSACTIONS);
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
        #endregion
}
