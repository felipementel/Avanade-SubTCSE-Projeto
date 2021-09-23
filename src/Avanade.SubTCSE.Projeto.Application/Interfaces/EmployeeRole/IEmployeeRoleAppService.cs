using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avanade.SubTCSE.Projeto.Application.Interfaces.EmployeeRole
{
    public interface IEmployeeRoleAppService
    {
        Task<Dtos.EmployeeRole.EmployeeRoleDto> AddEmployeeRole(Application.Dtos.EmployeeRole.EmployeeRoleDto employeeRoleDto);

        Task<Dtos.EmployeeRole.EmployeeRoleDto> GetEmployeeRole(string id);

        Task<List<Dtos.EmployeeRole.EmployeeRoleDto>> ListEmployeeRole();
    }
}