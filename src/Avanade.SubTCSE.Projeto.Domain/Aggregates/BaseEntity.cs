using FluentValidation.Results;

namespace Avanade.SubTCSE.Projeto.Domain.Aggregates
{
    public record BaseEntity<Tid>
    {
        public Tid Id { get; set; }

        public ValidationResult ValidationResult { get; set; }
    }
}
