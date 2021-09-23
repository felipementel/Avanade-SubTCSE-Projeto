using System.Collections.Generic;
using System.Threading.Tasks;

namespace Avanade.SubTCSE.Projeto.Domain.Aggregates.Employee.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<Entities.Employee> AddEmployee(Entities.Employee employee);

        Task<Entities.Employee> GetEmployee(string id);

        Task<List<Entities.Employee>> ListEmployee();
    }
}