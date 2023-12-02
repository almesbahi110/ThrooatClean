using Application.Dtos.Requst;
using Application.Dtos.Response;
using Domain.Entities;
namespace Application.Interface
{
    public interface IEmployee
    {
        Task<ResponeEmployeeDto> PostData(EmployeeRequstDTo employeeRequst);
        Task<ResponeEmployeeDto> UpdateData(EmployeeRequstDTo employeeRequst);
        Task<IReadOnlyList<Employee>> GetAll();
        Task<Employee> GetEmployeeById(int id);
        Task<ResponeEmployeeDto> Delete(int id);
    }
}
