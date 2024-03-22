using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WebApi_Video.DataContext;
using WebApi_Video.Models;

namespace WebApi_Video.Services.EmployeeService
{
    public class EmployeeService : IEmployeeInterface
    {
        private readonly ApplicationDbContext _context;
        public EmployeeService(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<ServiceResponse<EmployeeModel>> CreateEmployee(EmployeeModel newEmployee)
        {
            ServiceResponse<EmployeeModel> serviceResponse = new ServiceResponse<EmployeeModel>();

            try
            {

                if (newEmployee == null)
                {
                    serviceResponse.Data= null;
                    serviceResponse.Message = "Fill in the data";
                    serviceResponse.Sucess = false;

                    return serviceResponse;
                }

                _context.Add(newEmployee);
                    await _context.SaveChangesAsync();
                serviceResponse.Data = newEmployee;

            }
            catch (Exception ex)
            {

                serviceResponse.Message = ex.Message;
                serviceResponse.Sucess = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<EmployeeModel>> DeleteEmployee(int id)
        {
            ServiceResponse<EmployeeModel> serviceResponse = new ServiceResponse<EmployeeModel>();

            try
            {
                EmployeeModel employee = _context.Employee.FirstOrDefault(x => x.Id == id);

                if (employee == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Employee not found";
                    serviceResponse.Sucess = false;
                }

               _context.Employee.Remove(employee);
                await _context.SaveChangesAsync();

                serviceResponse.Data = employee;
            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Sucess = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<EmployeeModel>> GetEmployeeById(int id)
        {
            ServiceResponse<EmployeeModel> serviceResponse= new ServiceResponse<EmployeeModel>();


            try
            {
                EmployeeModel employee = _context.Employee.FirstOrDefault(x => x.Id == id);

                if (employee == null)
                {
                    serviceResponse.Data= null;
                    serviceResponse.Message = "Employee not found";
                    serviceResponse.Sucess = false;
                }
                serviceResponse.Data = employee;
            }
            catch (Exception ex )
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Sucess = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<EmployeeModel>>> GetEmployees()
        {
            ServiceResponse<List<EmployeeModel>> serviceResponse = new ServiceResponse<List<EmployeeModel>>();

            try
            {
                serviceResponse.Data = _context.Employee.ToList();

                if(serviceResponse.Data.Count == 0) 
                {
                    serviceResponse.Message = "Data not fond";
                }
            }
            catch (Exception ex)
            {
                serviceResponse.Message= ex.Message;
                serviceResponse.Sucess = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<EmployeeModel>> InactiveEmployee(int id)
        {
            ServiceResponse<EmployeeModel> serviceResponse = new ServiceResponse<EmployeeModel>();

            try
            {
                EmployeeModel employee = _context.Employee.FirstOrDefault(x => x.Id == id);

                if (employee == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Employee not found";
                    serviceResponse.Sucess = false;
                    
                }
                employee.Active = false;
                employee.UpdateDate = DateTime.Now.ToLocalTime();

                _context.Employee.Update(employee);
                await _context.SaveChangesAsync();
                
                serviceResponse.Data = employee;
            }
            catch (Exception ex)
            {

                serviceResponse.Message = ex.Message;
                serviceResponse.Sucess = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<EmployeeModel>> UpdateEmployee(EmployeeModel upDateEmployee)
        {
            ServiceResponse<EmployeeModel> serviceResponse = new ServiceResponse<EmployeeModel>();

            try
            {
                EmployeeModel employee = _context.Employee.AsNoTracking().FirstOrDefault(x => x.Id == upDateEmployee.Id);

                if (employee == null)
                {
                    serviceResponse.Data = null;
                    serviceResponse.Message = "Employee not found";
                    serviceResponse.Sucess = false;
                    
                }

                employee.UpdateDate = DateTime.Now.ToLocalTime();
                _context.Employee.Update(upDateEmployee);
                await _context.SaveChangesAsync();
                serviceResponse.Data = upDateEmployee;

            }
            catch (Exception ex)
            {
                serviceResponse.Message = ex.Message;
                serviceResponse.Sucess = false;
            }
            return serviceResponse;
        }
    }
}
