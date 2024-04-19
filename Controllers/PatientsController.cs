using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
        public ActionResult<IEnumerable<VPatient>> GetPatients(int pageIndex = 0, int pageSize = 10, int? hospitalId = null, string? name = "", string? address = "", string? hospital = "", int min = 0, int max = 120)
        {
            var hospitalName = "";
            var patientsQuery = _context.VPatients.AsQueryable();

            if (hospitalId != null)
            {
                patientsQuery = patientsQuery.Where(p => p.HospitalId == hospitalId);
                hospitalName = _context.Hospitals.FirstOrDefault(x => x.Id == hospitalId.Value).HospitalName;
            }

            patientsQuery = patientsQuery.Where(p => (p.FirstName + p.LastName).Contains(name) && p.PatientAddress.Contains(address) && p.HospitalName.Contains(hospital) && (p.Age.Value >= min && p.Age <= max));

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
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = _context.Patients.Find(id);
            if (patient == null)
            {
                return NotFound();
            }

            var hospitals = _context.Hospitals.Select(h => new
            {
                h.Id,
                h.HospitalName
            }).ToList();

            ViewBag.Hospitals = new SelectList(hospitals, "Id", "HospitalName");

            return View("PatientEdit", patient);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Patient patient)
        {
            var hospitals = _context.Hospitals.Select(h => new
            {
                h.Id,
                h.HospitalName
            }).ToList();

            ViewBag.Hospitals = new SelectList(hospitals, "Id", "HospitalName");

            if (patient.Id == null)
            {
                return NotFound();
            }
            var dbPatient = _context.Patients.Find(patient.Id);
            dbPatient.FirstName = patient.FirstName;
            dbPatient.LastName = patient.LastName;
            dbPatient.Age = patient.Age;
            dbPatient.PatientAddress = patient.PatientAddress;
            dbPatient.HospitalId = patient.HospitalId;
            _context.Update(dbPatient);
            _context.SaveChanges();
            return View("PatientEdit", patient);
        }
        public IActionResult Add()
        {
            var hospitals = _context.Hospitals.Select(h => new
            {
                h.Id,
                h.HospitalName
            }).ToList();

            ViewBag.Hospitals = new SelectList(hospitals, "Id", "HospitalName");

            return View("PatientAdd");
        }

        [HttpPost]
        public async Task<IActionResult> Add(Patient patient)
        {
            patient.Id = _context.Patients.Count();
            _context.Patients.Add(patient);
            _context.SaveChanges();
            return View("PatientEdit", patient);
        }
    }


}

