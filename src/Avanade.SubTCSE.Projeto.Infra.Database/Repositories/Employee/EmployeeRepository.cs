using Avanade.SubTCSE.Projeto.Domain.Aggregates.Employee.Interfaces.Repositories;
using Avanade.SubTCSE.Projeto.Domain.Base.Repository.MongoDB;
using Avanade.SubTCSE.Projeto.Infra.Database.Repositories.Base;

namespace Avanade.SubTCSE.Projeto.Infra.Database.Repositories.Employee
{
    public class EmployeeRepository : BaseRepository<Domain.Aggregates.Employee.Entities.Employee, string>, IEmployeeRepository
    {
        public EmployeeRepository(IMongoDBContext context) : base(context, "employee")
        {
        }
    }
}
