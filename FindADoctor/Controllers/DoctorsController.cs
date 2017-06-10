using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FindADoctor.Models;

namespace FindADoctor.Controllers
{
    [Authorize]
    public class DoctorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Doctors
        [Authorize(Roles = "Admin, Patient")]
        public ActionResult Index()
        {
            var doctors = db.Doctors.Include(d => d.Degree).Include(d => d.Specialty);
            return View(doctors.ToList());
        }

        // GET: Doctors/Details/5
        [Authorize(Roles = "Admin, Patient")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // GET: Doctors/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.DegreeId = new SelectList(db.Degrees, "Id", "Name");
            ViewBag.SpecialtyId = new SelectList(db.Specialties, "Id", "Type");
            return View();
        }

        // POST: Doctors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Phone,SpecialtyId,DegreeId")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.Doctors.Add(doctor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DegreeId = new SelectList(db.Degrees, "Id", "Name", doctor.DegreeId);
            ViewBag.SpecialtyId = new SelectList(db.Specialties, "Id", "Type", doctor.SpecialtyId);
            return View(doctor);
        }

        // GET: Doctors/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            ViewBag.DegreeId = new SelectList(db.Degrees, "Id", "Name", doctor.DegreeId);
            ViewBag.SpecialtyId = new SelectList(db.Specialties, "Id", "Type", doctor.SpecialtyId);
            return View(doctor);
        }

        // POST: Doctors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Phone,SpecialtyId,DegreeId")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DegreeId = new SelectList(db.Degrees, "Id", "Name", doctor.DegreeId);
            ViewBag.SpecialtyId = new SelectList(db.Specialties, "Id", "Type", doctor.SpecialtyId);
            return View(doctor);
        }

        // GET: Doctors/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            Doctor doctor = db.Doctors.Find(id);
            db.Doctors.Remove(doctor);
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
