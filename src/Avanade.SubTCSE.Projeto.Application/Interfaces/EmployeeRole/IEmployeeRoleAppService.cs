using Avanade.SubTCSE.Projeto.Application.Dtos.EmployeeRole;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avanade.SubTCSE.Projeto.Application.Interfaces.EmployeeRole
{
    public interface IEmployeeRoleAppService
    {
        Task<EmployeeRoleDto> AddEmployeeRoleAsync(EmployeeRoleDto employeeRoleDto);

        Task<List<EmployeeRoleDto>> FindAllEmployeeRoleAsync();

        Task<EmployeeRoleDto> GetById(string id); //TODO: Generics
    }
}