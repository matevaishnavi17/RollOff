using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RollOff.Models;

namespace RollOff.Controllers
{
    public class RolloffsController : Controller
    {
        private ROLLOFFEntities1 db = new ROLLOFFEntities1();

        // GET: Rolloffs
        public ActionResult Index()
        {
            return View(db.Rolloffs.ToList());
        }

        // GET: Rolloffs/Details/5
        public ActionResult Details(double? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rolloff rolloff = db.Rolloffs.Find(id);
            if (rolloff == null)
            {
                return HttpNotFound();
            }
            return View(rolloff);
        }

        // GET: Rolloffs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rolloffs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Country,Global_Group_ID,Employee_no,Name,Local_Grade,Main_Client,Email,Joining_Date,Project_Code,Project_Name,Project_Start_Date,Project_End_Date,People_Manager__Performance_Reviewer_,Practice,PSP_Name,New_Global_Practice,Office_City")] Rolloff rolloff)
        {
            if (ModelState.IsValid)
            {
                db.Rolloffs.Add(rolloff);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rolloff);
        }

        // GET: Rolloffs/Edit/5
        public ActionResult Edit(double? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rolloff rolloff = db.Rolloffs.Find(id);
            if (rolloff == null)
            {
                return HttpNotFound();
            }
            return View(rolloff);
        }

        // POST: Rolloffs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Country,Global_Group_ID,Employee_no,Name,Local_Grade,Main_Client,Email,Joining_Date,Project_Code,Project_Name,Project_Start_Date,Project_End_Date,People_Manager__Performance_Reviewer_,Practice,PSP_Name,New_Global_Practice,Office_City")] Rolloff rolloff)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rolloff).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rolloff);
        }

        // GET: Rolloffs/Delete/5
        public ActionResult Delete(double? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Rolloff rolloff = db.Rolloffs.Find(id);
            if (rolloff == null)
            {
                return HttpNotFound();
            }
            return View(rolloff);
        }

        // POST: Rolloffs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(double id)
        {
            Rolloff rolloff = db.Rolloffs.Find(id);
            db.Rolloffs.Remove(rolloff);
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
