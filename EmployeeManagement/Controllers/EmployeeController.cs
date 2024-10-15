using EmployeeManagement.Data.Employees;
using Microsoft.AspNetCore.Mvc;
namespace EmployeeManagement.Controllers
{
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeController> _logger;
        public EmployeeController(
            IEmployeeRepository employeeRepository,
            ILogger<EmployeeController> logger) 
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }

        [HttpGet()]
        [Route("api/employees")]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Employee> employees = await _employeeRepository.GetAll();
            return Ok(employees);
        }

        [HttpGet()]
        [Route("api/employees/{id}")]
        public async Task<IActionResult> Post(int id)
        {
            Employee? employee = await _employeeRepository.Get(id);
            return Ok(employee);
        }

        [HttpPost()]
        [Route("api/employees")]
        public async Task<IActionResult> Post([FromBody]Employee employee)
        {
            Employee newEmployee = await _employeeRepository.Add(employee);
            return Ok(newEmployee);
        }

        [HttpDelete()]
        [Route("api/employees/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Employee? newEmployee = await _employeeRepository.Delete(id);
            return Ok(newEmployee);
        }

        [HttpPut()]
        [Route("api/employees")]
        public async Task<IActionResult> Put([FromBody] Employee employee)
        {
            Employee newEmployee = await _employeeRepository.Update(employee);
            return Ok(newEmployee);
        }
    }
}
