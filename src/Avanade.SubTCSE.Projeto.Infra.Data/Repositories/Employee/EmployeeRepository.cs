using Avanade.SubTCSE.Projeto.Domain.Aggregates.Employee.Interfaces.Repositories;
using Avanade.SubTCSE.Projeto.Domain.Base.Repository.MongoDB;
using Avanade.SubTCSE.Projeto.Infra.Data.Repositories.Base;

namespace Avanade.SubTCSE.Projeto.Infra.Data.Repositories.Employee
{
    public class EmployeeRepository
        : BaseRepository<Domain.Aggregates.Employee.Entities.Employee, string>
        , IEmployeeRepository
    {
        public EmployeeRepository(IMongoDBContext mongoDBContext)
            : base(mongoDBContext, "employee")
        {

        }
    }
}
