using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avanade.SubTCSE.Projeto.Domain.Aggregates.EmployeeRole.Interfaces.Services
{
    public interface IEmployeeRoleService
    {
        Task<Entities.EmployeeRole> AddEmployeeRoleAsync(Entities.EmployeeRole employeeRole);

        Task<Entities.EmployeeRole> GetEmployeeRoleAsync(string id);

        Task<List<Entities.EmployeeRole>> ListEmployeeRoleAsync();

        Task<Entities.EmployeeRole> UpdateEmployeeRoleAsync(string id, Entities.EmployeeRole employeeRole);

        Task DeleteEmployeeRoleAsync(string id);
    }
}