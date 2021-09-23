using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avanade.SubTCSE.Projeto.Domain.Aggregates.EmployeeRole.Interfaces.Services
{
    public interface IEmployeeRoleService
    {
        Task<Entities.EmployeeRole> AddEmployeeRole(Entities.EmployeeRole employeeRole);

        Task<Entities.EmployeeRole> GetEmployeeRole(string id);

        Task<List<Entities.EmployeeRole>> ListEmployeeRole();
    }
}