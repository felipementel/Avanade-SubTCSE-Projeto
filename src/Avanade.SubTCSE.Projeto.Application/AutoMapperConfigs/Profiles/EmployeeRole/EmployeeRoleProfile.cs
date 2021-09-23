using AutoMapper;

namespace Avanade.SubTCSE.Projeto.Application.AutoMapperConfigs.Profiles.EmployeeRole
{
    public class EmployeeRoleProfile : Profile
    {
        public EmployeeRoleProfile()
        {
            CreateMap<Dtos.EmployeeRole.EmployeeRoleDto, Domain.Aggregates.EmployeeRole.Entities.EmployeeRole>()
            .ConstructUsing((ctor, res) =>
             {
                 return new Domain.Aggregates.EmployeeRole.Entities.EmployeeRole(
                 ctor.Cargo);
             })
            .ForAllOtherMembers(i => i.Ignore());

            //    .ForCtorParam("roleName", opt => opt.MapFrom(src => src.Cargo))
            //    .ForAllOtherMembers(i => i.Ignore());

            CreateMap<Domain.Aggregates.EmployeeRole.Entities.EmployeeRole, Dtos.EmployeeRole.EmployeeRoleDto>()
                .ForMember(dest => dest.Identificador, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Cargo, opt => opt.MapFrom(src => src.RoleName))
                .ForMember(dest => dest.ValidationResult, opt => opt.MapFrom(src => src.ValidationResult))
                .ForAllOtherMembers(i => i.Ignore());
        }
    }
}