using Avanade.SubTCSE.Projeto.Domain.Aggregates.EmployeeRole.Validators;
using FluentValidation;

namespace Avanade.SubTCSE.Projeto.Domain.Aggregates.Employee.Validators
{
    public class EmployeeValidator : AbstractValidator<Entities.Employee>
    {
        public EmployeeValidator()
        {
            RuleSet("new", () => 
            {
                RuleFor(e => e.FirstName)
                .NotEmpty()
                .WithMessage("{PropertyName} can not be empty");

                RuleFor(e => e.SurName)
                .NotEmpty()
                .WithMessage("{PropertyName} can not be empty");

                RuleFor(e => e.EmployeeRole)
                .SetValidator(new EmployeeRoleValidator());
            });
        }
    }
}
