using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OAinternship.Models;
using System;
using System.Net;


namespace OAinternship.Controllers
{
    public class MedicalTransactionsController : Controller
    {
        private readonly MytestserverContext _context;

        public MedicalTransactionsController(MytestserverContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult<IEnumerable<VMedicalTransaction>> GetMedicalTransactions(int pageIndex = 0, int pageSize = 10, int? patientId = null, string firstname = "", string lastname = "", int max = 100000, int min = 0, string nurse = "", string doctor = "", string start = "2000-01-01", string end = "3000-01-01")
        {
            
            DateOnly startDate = DateOnly.ParseExact(start, "yyyy-MM-dd"); //convert string to DateOnly
            DateOnly endDate = DateOnly.ParseExact(end, "yyyy-MM-dd");
            var patientName = "";
            var medicalTransactionsQuery = _context.VMedicalTransactions.AsQueryable();

            //check for patientId
            if (patientId != null)
            {
                var patient = _context.Patients.FirstOrDefault(p => p.Id == patientId.Value);
                patientName = patient.FirstName + " " + patient.LastName;
                medicalTransactionsQuery = medicalTransactionsQuery.Where(x => x.PatientId == patientId);
            }

            //Query with passed parameters
            medicalTransactionsQuery = medicalTransactionsQuery.Where
                (
                x => (x.PatientFirstName.Contains(firstname) && 
                x.PatientLastName.Contains(lastname) && 
                (x.NurseFirstName + x.NurseLastName).Contains(nurse) && 
                (x.DoctorFirstName + x.DoctorLastName).Contains(doctor)&&
                (x.TotalCost.Value >= min && x.TotalCost <= max)&&
                (x.TransactionDate>=startDate && x.TransactionDate<=endDate))
                );

            var totalRecords = medicalTransactionsQuery.Count();
            //get pageSize amount of data starting from pageIndex 
            var medicalTransactions = medicalTransactionsQuery.Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToList();

            var response = new
            {
                Data = medicalTransactions,
                TotalRecords = totalRecords,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(totalRecords / (double)pageSize),
                PatientName = patientName
            };
            return Ok(response);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mt = _context.MedicalTransactions.Find(id);
            if (mt == null)
            {
                return NotFound();
            }

            var patients = _context.Patients.Select(p => new
            {
                p.Id,
                p.FirstName
            }).ToList();

            ViewBag.Patients = new SelectList(patients, "Id", "FirstName");

            return View("MedicaLTransactionsEdit", mt);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(MedicalTransaction mt)
        {
            var patients = _context.Patients.Select(p => new
            {
                p.Id,
                p.FirstName,
                p.LastName
            }).ToList();

            ViewBag.Patients = new SelectList(patients, "Id", "FirstName");

            if (mt.RxNumber == null)
            {
                return NotFound();
            }
            var dbMedicalTransaction = _context.MedicalTransactions.Find(mt.RxNumber);
            dbMedicalTransaction.PatientId = mt.PatientId;
            dbMedicalTransaction.TotalCost = mt.TotalCost;
            dbMedicalTransaction.DateFilled = mt.DateFilled;
            _context.Update(dbMedicalTransaction);
            _context.SaveChanges();
            return View("MedicalTransactionsEdit", mt);
        }
    }
}
