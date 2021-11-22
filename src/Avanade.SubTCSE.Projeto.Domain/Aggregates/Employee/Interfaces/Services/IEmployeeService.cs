using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avanade.SubTCSE.Projeto.Domain.Aggregates.Employee.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<Entities.Employee> AddEmployeeAsync(Entities.Employee employee);

        Task<Entities.Employee> GetEmployeeAsync(string id);

        Task<List<Entities.Employee>> ListEmployeeAsync();

        Task<Entities.Employee> UpdateEmployeeAsync(string id, Entities.Employee employee);

        Task DeleteEmployeeAsync(string id);
    }
}