using Microsoft.AspNetCore.Mvc;
using BusinessLayer.Interface;
using ModelLayer;

namespace CSVReaderApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IReadBL _businessLayer;

        public HomeController(IReadBL businessLayer)
        {
            _businessLayer = businessLayer;
        }

        // ✅ Get all employees
        [HttpGet("employees")]
        public ActionResult<IEnumerable<Employee>> GetAllEmployees()
        {
            var employees = _businessLayer.GetAllEmployees();

            if (employees == null || employees.Count == 0)
                return NotFound("No employees found in the CSV file.");

            return Ok(employees);
        }


        // ✅ Add a new employee
        [HttpPost("employees")]
        public ActionResult AddEmployee([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Invalid employee data.");
            }

            _businessLayer.AddEmployee(employee);
            return Ok("Employee added successfully.");
        }
    }
}
