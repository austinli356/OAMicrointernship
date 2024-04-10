using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OAinternship.Models;


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
        public ActionResult<IEnumerable<VMedicalTransaction>> GetMedicalTransactions(int pageIndex = 0, int pageSize = 10, int? patientId = null)
        {
            var patientName = "";
            var medicalTransactionsQuery = _context.VMedicalTransactions.AsQueryable();

            if (patientId != null)
            {
                var patient = _context.Patients.FirstOrDefault(p => p.Id == patientId.Value);
                patientName = patient.FirstName + " " + patient.LastName;
                medicalTransactionsQuery = medicalTransactionsQuery.Where(x => x.PatientId == patientId);
            }
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
