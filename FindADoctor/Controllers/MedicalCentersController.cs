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
    public class MedicalCentersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MedicalCenters
        [Authorize(Roles = "Admin, Patient")]
        public ActionResult Index()
        {
            return View(db.MedicalCenters.ToList());
        }

        // GET: MedicalCenters/Details/5
        [Authorize(Roles = "Admin, Patient")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalCenter medicalCenter = db.MedicalCenters.Find(id);
            if (medicalCenter == null)
            {
                return HttpNotFound();
            }

            var doctors = db.Doctors.ToList();
            var doctorsAssigned = db.DoctorAssignments.ToList();

            IEnumerable<Doctor> otherDoctors = from a in doctors
                                               where
                                               !(from b in doctorsAssigned
                                               where b.MedicalCenterId == id
                                               select b.DoctorId).Contains(a.Id)
                                               select a;

            ViewBag.OtherDoctors = otherDoctors;

            
            return View(medicalCenter);
        }

        // GET: MedicalCenters/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedicalCenters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "Id,Name,Address,Suburb,PostCode,City,Phone,Website,Latitute,Longitude")] MedicalCenter medicalCenter)
        {
            if (ModelState.IsValid)
            {
                db.MedicalCenters.Add(medicalCenter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medicalCenter);
        }

        // Method to Unassign doctor from Medical center
        [Authorize(Roles = "Admin")]
        public ActionResult UnlinkDoctor(int? doctorId, int? medicalId)
        {
            // first validating input parameter existence
            if (doctorId == null || medicalId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // getting the row from the assignment table
            var doctorInMedicalCenter = db.DoctorAssignments
                .First(row => row.DoctorId == doctorId && row.MedicalCenterId == medicalId);

            // returning bad request if there is no assignment in the table
            if (doctorInMedicalCenter == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            // removing assignment from database
            db.DoctorAssignments.Remove(doctorInMedicalCenter);
            db.SaveChanges();

            return RedirectToAction("Details", new { @id = medicalId });
        }

        // Method to Assign doctor to Medical center
        [Authorize(Roles = "Admin")]
        public ActionResult LinkDoctor(int? doctorId, int? medicalId)
        {
            // first validating input parameter existence
            if (doctorId == null || medicalId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // second checking doc & med existence according to input parameters
            var doctorExists = db.Doctors.Find(doctorId);
            var MedicalCenterExists = db.MedicalCenters.Find(medicalId);

            // returning bad request if there is no such doc or medical center exists
            if (doctorExists == null || MedicalCenterExists == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            // getting the assignment table row
            var doctorAlreadyAssigned = db.DoctorAssignments.FirstOrDefault(row => row.DoctorId == doctorId && row.MedicalCenterId == medicalId);
            
            // returning bad request if there is no assignment
            if (doctorAlreadyAssigned != null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            // creating assignment model
            var doctorAssignment = new DoctorAssignment
            {
                DoctorId = (int)doctorId,
                MedicalCenterId = (int)medicalId
            };

            // adding table record with assignment information
            db.DoctorAssignments.Add(doctorAssignment);
            db.SaveChanges();

            return RedirectToAction("Details", new { @id = medicalId });
        }

        // GET: MedicalCenters/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalCenter medicalCenter = db.MedicalCenters.Find(id);
            if (medicalCenter == null)
            {
                return HttpNotFound();
            }
            return View(medicalCenter);
        }

        // POST: MedicalCenters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "Id,Name,Address,Suburb,PostCode,City,Phone,Website,Latitute,Longitude")] MedicalCenter medicalCenter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicalCenter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medicalCenter);
        }

        // GET: MedicalCenters/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicalCenter medicalCenter = db.MedicalCenters.Find(id);
            if (medicalCenter == null)
            {
                return HttpNotFound();
            }
            return View(medicalCenter);
        }

        // POST: MedicalCenters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            MedicalCenter medicalCenter = db.MedicalCenters.Find(id);
            db.MedicalCenters.Remove(medicalCenter);
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
