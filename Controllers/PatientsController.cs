using Microsoft.AspNetCore.Mvc;
using OAinternship.Models;



namespace OAinternship.Controllers
{
    public class PatientsController : Controller
    {
        private readonly MytestserverContext _context;

        public PatientsController(MytestserverContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public ActionResult<IEnumerable<VPatient>> GetPatients(int pageIndex = 0, int pageSize = 10, int? hospitalId = null, string? name = "", string ? address = "", string ? hospital = "", int min = 0, int max = 120)
        {
            var hospitalName = ""   ;
            var patientsQuery = _context.VPatients.AsQueryable();

            if (hospitalId != null)
            {
                patientsQuery = patientsQuery.Where(p => p.HospitalId == hospitalId);
                hospitalName = _context.Hospitals.FirstOrDefault(x => x.Id == hospitalId.Value).HospitalName;
            }

            // Code below would not work if address variable is empty or patient name filter variable is empty.  
            // try next :  (string.IsNullOrEmpty(address) || p.PatientAddress.Contains(address)) and same with patient name.In this case if address is empty then nothis will be removed from the list of patients
            patientsQuery = patientsQuery.Where(p => (p.FirstName + p.LastName).Contains(name) && p.PatientAddress.Contains(address) && p.HospitalName.Contains(hospital) && (p.Age.Value >= min && p.Age<=max));

            var totalRecords = patientsQuery.Count();
            var patients = patientsQuery.Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToList();
            var response = new
            {
                Data = patients,
                TotalRecords = totalRecords,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(totalRecords / (double)pageSize),
                HospitalName = hospitalName
            };
            return Ok(response);
        }
    }
}

