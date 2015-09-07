using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SWZ_Petrol_Station;
using SWZ_Petrol_Station.Models;

namespace SWZ_Petrol_Station.Controllers
{
    public class CLIENTSController : Controller
    {
        private DB_9D7C73_karolwieczorek9Entities1 db = new DB_9D7C73_karolwieczorek9Entities1();

        #region user
        public ActionResult Login() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(CLIENTS u) {
            // this action is for handle post (login)
            if (ModelState.IsValid) // this is check validity
            {
                var v = db.CLIENTS.Where(a => a.CLI_LOGIN.Equals(u.CLI_LOGIN) && a.CLI_PASSWORD.Equals(u.CLI_PASSWORD)).FirstOrDefault();
                if (v != null) {
                    Session["LogedUserID"] = v.CLI_PKid.ToString();
                    Session["LogedUserFullname"] = v.CLI_LOGIN.ToString();
                    Session["LogedUserType"] = (AccountType)v.CLI_ACCTYPE;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(u);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff() {
            Session["LogedUserID"] = null;
            Session["LogedUserFullname"] = null;
            Session["LogedUserType"] = null;
            return RedirectToAction("Index", "Home");
        }

        // GET: CLIENTS/Register
        public ActionResult Register() {
            ViewBag.COM_PKid = new SelectList(db.COMPANY, "COM_PKid", "COM_NAME");
            ViewBag.PRS_PKid = new SelectList(db.PERSON, "PRS_PKid", "PRS_NAME");
            return View();
        }

        // POST: CLIENTS/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "CLI_PKid,CLI_LOGIN,CLI_PASSWORD")] CLIENTS cLIENTS) {
            cLIENTS.CLI_ACCTYPE = (int)AccountType.Client;
            if (ModelState.IsValid) {
                db.CLIENTS.Add(cLIENTS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COM_PKid = new SelectList(db.COMPANY, "COM_PKid", "COM_NAME", cLIENTS.COM_PKid);
            ViewBag.PRS_PKid = new SelectList(db.PERSON, "PRS_PKid", "PRS_NAME", cLIENTS.PRS_PKid);
            return View(cLIENTS);
        }
        #endregion
        #region basic

        // GET: CLIENTS
        public ActionResult Index()
        {
            var cLIENTS = db.CLIENTS.Include(c => c.COMPANY).Include(c => c.PERSON);
            return View(cLIENTS.ToList());
        }

        // GET: CLIENTS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENTS cLIENTS = db.CLIENTS.Find(id);
            if (cLIENTS == null)
            {
                return HttpNotFound();
            }
            return View(cLIENTS);
        }

        // GET: CLIENTS/Create
        public ActionResult Create()
        {
            ViewBag.COM_PKid = new SelectList(db.COMPANY, "COM_PKid", "COM_NAME");
            ViewBag.PRS_PKid = new SelectList(db.PERSON, "PRS_PKid", "PRS_NAME");
            return View();
        }

        // POST: CLIENTS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CLI_PKid,CLI_LOGIN,CLI_PASSWORD,CLI_ACCTYPE,CLI_POINTS,CLI_LASTCHANGE,COM_PKid,PRS_PKid")] CLIENTS cLIENTS)
        {
            if (ModelState.IsValid)
            {
                db.CLIENTS.Add(cLIENTS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.COM_PKid = new SelectList(db.COMPANY, "COM_PKid", "COM_NAME", cLIENTS.COM_PKid);
            ViewBag.PRS_PKid = new SelectList(db.PERSON, "PRS_PKid", "PRS_NAME", cLIENTS.PRS_PKid);
            return View(cLIENTS);
        }

        // GET: CLIENTS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENTS cLIENTS = db.CLIENTS.Find(id);
            if (cLIENTS == null)
            {
                return HttpNotFound();
            }
            ViewBag.COM_PKid = new SelectList(db.COMPANY, "COM_PKid", "COM_NAME", cLIENTS.COM_PKid);
            ViewBag.PRS_PKid = new SelectList(db.PERSON, "PRS_PKid", "PRS_NAME", cLIENTS.PRS_PKid);
            return View(cLIENTS);
        }

        // POST: CLIENTS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CLI_PKid,CLI_LOGIN,CLI_PASSWORD,CLI_ACCTYPE,CLI_POINTS,CLI_LASTCHANGE,COM_PKid,PRS_PKid")] CLIENTS cLIENTS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cLIENTS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.COM_PKid = new SelectList(db.COMPANY, "COM_PKid", "COM_NAME", cLIENTS.COM_PKid);
            ViewBag.PRS_PKid = new SelectList(db.PERSON, "PRS_PKid", "PRS_NAME", cLIENTS.PRS_PKid);
            return View(cLIENTS);
        }

        // GET: CLIENTS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CLIENTS cLIENTS = db.CLIENTS.Find(id);
            if (cLIENTS == null)
            {
                return HttpNotFound();
            }
            return View(cLIENTS);
        }

        // POST: CLIENTS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CLIENTS cLIENTS = db.CLIENTS.Find(id);
            db.CLIENTS.Remove(cLIENTS);
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
