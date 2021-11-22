using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avanade.SubTCSE.Projeto.Application.Interfaces.Employee
{
    public interface IEmployeeAppService
    {
        Task<Dtos.Employee.EmployeeDto> AddEmployeeAsync(Dtos.Employee.EmployeeDto employeeDto);

        Task<Dtos.Employee.EmployeeDto> GetEmployeeAsync(string id);

        Task<List<Dtos.Employee.EmployeeDto>> ListEmployeeAsync();

        Task<Dtos.Employee.EmployeeDto> UpdateEmployeeAsync(string id, Application.Dtos.Employee.EmployeeDto employeeDto);

        Task DeleteEmployeeAsync(string id);
    }
}