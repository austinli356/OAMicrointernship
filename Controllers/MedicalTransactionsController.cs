using Microsoft.AspNetCore.Mvc;
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
            
            DateOnly startDate = DateOnly.ParseExact(start, "yyyy-MM-dd");
            DateOnly endDate = DateOnly.ParseExact(end, "yyyy-MM-dd");
            var patientName = "";
            var medicalTransactionsQuery = _context.VMedicalTransactions.AsQueryable();

            if (patientId != null)
            {
                var patient = _context.Patients.FirstOrDefault(p => p.Id == patientId.Value);
                patientName = patient.FirstName + " " + patient.LastName;
                medicalTransactionsQuery = medicalTransactionsQuery.Where(x => x.PatientId == patientId);
            }

            // in line below there as no handling of empty values in filter. 
            // You need to check whether filter variable is not empty befor applying it as a filter
            medicalTransactionsQuery = medicalTransactionsQuery.Where(x => (x.PatientFirstName.Contains(firstname) && x.PatientLastName.Contains(lastname) && (x.NurseFirstName + x.NurseLastName).Contains(nurse) && (x.DoctorFirstName + x.DoctorLastName).Contains(doctor)&&(x.TotalCost.Value >= min && x.TotalCost <= max)&&(x.TransactionDate>=startDate && x.TransactionDate<=endDate)));

            var totalRecords = medicalTransactionsQuery.Count();
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
    }
}
