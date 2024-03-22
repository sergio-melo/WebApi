using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Video.Models;
using WebApi_Video.Services.EmployeeService;

namespace WebApi_Video.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeInterface _employeeInterface;
        public EmployeeController(IEmployeeInterface employeeInterface) 
        {
            _employeeInterface = employeeInterface;
        }


        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<EmployeeModel>>>> GetEmployees()
        {
            return Ok(await _employeeInterface.GetEmployees());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<EmployeeModel>>> GetEmployeeById(int id)
        {
            ServiceResponse<EmployeeModel> serviceResponse = await _employeeInterface.GetEmployeeById(id);
            
            return Ok(serviceResponse);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<EmployeeModel>>> CreateEmployee(EmployeeModel newEmployee)
        {
            return Ok(await _employeeInterface.CreateEmployee(newEmployee));
        }

        [HttpPut("UpdateEmployee")]
        public async Task<ActionResult<ServiceResponse<EmployeeModel>>> UpdateEmployee(EmployeeModel upDateEmployee)
        {
            ServiceResponse<EmployeeModel> serviceResponse = await _employeeInterface.UpdateEmployee(upDateEmployee);
            return Ok(serviceResponse);
        }

        [HttpPut("InactiveEmployee")]
        public async Task<ActionResult<ServiceResponse<EmployeeModel>>> InactiveEmployee(int id)
        {
            ServiceResponse<EmployeeModel> serviceResponse = await _employeeInterface.InactiveEmployee(id);
            return Ok(serviceResponse);
        }

        [HttpDelete("DeleteEmployee")]
        public async Task<ActionResult<ServiceResponse<EmployeeModel>>> DeleteEmployee(int id)
        {
            ServiceResponse<EmployeeModel> serviceResponse = await _employeeInterface.DeleteEmployee(id);
            return Ok(serviceResponse);
        }

    }
}
