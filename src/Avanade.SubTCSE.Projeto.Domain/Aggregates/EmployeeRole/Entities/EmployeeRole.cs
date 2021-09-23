namespace Avanade.SubTCSE.Projeto.Domain.Aggregates.EmployeeRole.Entities
{
    public record EmployeeRole : BaseEntity<string>
    {
        public EmployeeRole(string roleName)
        {
            RoleName = roleName;
        }

        public string RoleName { get; init; }
    }
}