using FindADoctor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FindADoctor.Controllers
{
    public class AppointmentsController : Controller
    {

        ApplicationDbContext db = new ApplicationDbContext();

        // GET: Appointment
        public ActionResult StepOne()
        {
            var specialties = db.Specialties.ToList();

            var viewModel = new StepOneViewModel
            {
                Specialties = specialties
            };

            return View("StepOne", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StepTwo(StepOneViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("StepOne");
            }

            var selectedSpecialtyTypeId = viewModel.SelectedSpecialty;

            if (selectedSpecialtyTypeId == null)
            {
                return RedirectToAction("StepOne");
            }

            var possibleDoctors = from d in db.Doctors
                                  where d.SpecialtyId == selectedSpecialtyTypeId
                                  select d;

            var possibleAssignments = from a in db.DoctorAssignments
                              join b in possibleDoctors on a.DoctorId equals b.Id
                              select a;

            var possibleMedicalCenters = from a in db.MedicalCenters
                                         join b in possibleAssignments on a.Id equals b.MedicalCenterId
                                         select a;
            
            return View("StepTwo", possibleMedicalCenters);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StepThree(MedicalCenter viewModel)
        {

            return View("StepThree");
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