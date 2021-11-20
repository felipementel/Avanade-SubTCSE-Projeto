using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avanade.SubTCSE.Projeto.Domain.Aggregates.Employee.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<Entities.Employee> AddEmployeeAsync(Entities.Employee employee);

        Task<Entities.Employee> GetEmployeeAsync(string id);

        Task<List<Entities.Employee>> ListEmployeeAsync();

        Task UpdateEmployeeRoleAsync(string id, Entities.Employee employee);

        Task DeleteEmployeeRoleAsyncAsync(string id);
    }
}