using Microsoft.AspNetCore.Mvc;
using OAinternship.Models;

namespace OAinternship.Controllers
{
    //[Route("api/hospital")]
    //[ApiController]
    public class HospitalController : Controller
    {
        private readonly MytestserverContext _context;

        public HospitalController(MytestserverContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            return View();
        }
        [HttpGet]
        public ActionResult<IEnumerable<VHospital>> GetHospitals(int pageIndex = 0, int pageSize = 10)
        {
            var totalRecords = _context.VHospitals.Count();
            var hospitals = _context.VHospitals.Skip((pageIndex - 1) * pageSize)
                                .Take(pageSize)
                                .ToList();
            var response = new
            {
                Data = hospitals,
                TotalRecords = totalRecords,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(totalRecords / (double)pageSize)
            };
            return Ok(response);
        }
    }
}
