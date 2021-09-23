using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avanade.SubTCSE.Projeto.Application.Interfaces.Employee
{
    public interface IEmployeeAppService
    {
        Task<Dtos.Employee.EmployeeDto> AddEmployee(Dtos.Employee.EmployeeDto employeeDto);

        Task<Dtos.Employee.EmployeeDto> GetEmployee(string id);

        Task<List<Dtos.Employee.EmployeeDto>> ListEmployee();
    }
}