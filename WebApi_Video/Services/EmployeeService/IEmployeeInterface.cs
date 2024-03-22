using WebApi_Video.Models;

namespace WebApi_Video.Services.EmployeeService
{
    public interface IEmployeeInterface
    {
        Task<ServiceResponse<List<EmployeeModel>>> GetEmployees();
        Task<ServiceResponse<EmployeeModel>> CreateEmployee(EmployeeModel newEmployee);
        Task<ServiceResponse<EmployeeModel>> GetEmployeeById(int id);
        Task<ServiceResponse<EmployeeModel>> UpdateEmployee(EmployeeModel upDateEmployee);
        Task<ServiceResponse<EmployeeModel>> DeleteEmployee(int id);
        Task<ServiceResponse<EmployeeModel>> InactiveEmployee(int id);
    }
}
