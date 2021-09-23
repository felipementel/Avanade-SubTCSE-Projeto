using Avanade.SubTCSE.Projeto.Domain.Aggregates.EmployeeRole.Interfaces.Repositories;
using Avanade.SubTCSE.Projeto.Domain.Base.Repository.MongoDB;
using Avanade.SubTCSE.Projeto.Infra.Data.Repositories.Base;

namespace Avanade.SubTCSE.Projeto.Infra.Data.Repositories.EmployeeRole
{
    public class EmployeeRoleRepository : BaseRepository<Domain.Aggregates.EmployeeRole.Entities.EmployeeRole, string>, IEmployeeRoleRepository
    {
        public EmployeeRoleRepository(IMongoDBContext mongoDBContext) : base(mongoDBContext, "employeeRole")
        {
        }
    }
}