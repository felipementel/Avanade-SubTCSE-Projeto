using Avanade.SubTCSE.Projeto.Domain.Aggregates.EmployeeRole.Interfaces.Repository;
using Avanade.SubTCSE.Projeto.Domain.Base.Repository.MongoDB;
using Avanade.SubTCSE.Projeto.Infra.Data.Repositories.Base;

namespace Avanade.SubTCSE.Projeto.Infra.Data.Repositories.EmployeeRole
{
    public class EmployeeRoleRespository
        : BaseRepository<Domain.Aggregates.EmployeeRole.Entities.EmployeeRole, string>
        , IEmployeeRoleRepository
    {
        public EmployeeRoleRespository(IMongoDBContext mongoDBContext)
            : base(mongoDBContext, "employeeRole")
        {
        }
    }
}
