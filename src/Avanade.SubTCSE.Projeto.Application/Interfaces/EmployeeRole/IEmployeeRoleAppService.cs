using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avanade.SubTCSE.Projeto.Application.Interfaces.EmployeeRole
{
    public interface IEmployeeRoleAppService
    {
        Task<Dtos.EmployeeRole.EmployeeRoleDto> AddEmployeeRoleAsync(Application.Dtos.EmployeeRole.EmployeeRoleDto employeeRoleDto);

        Task<Dtos.EmployeeRole.EmployeeRoleDto> GetEmployeeRoleAsync(string id);

        Task<List<Dtos.EmployeeRole.EmployeeRoleDto>> ListEmployeeRoleAsync();

        Task<Dtos.EmployeeRole.EmployeeRoleDto> UpdateEmployeeRoleAsync(string id, Application.Dtos.EmployeeRole.EmployeeRoleDto employeeRoleDto);

        Task DeleteEmployeeRoleAsync(string id);
    }
}