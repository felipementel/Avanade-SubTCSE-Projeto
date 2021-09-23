using FluentValidation.Results;

namespace Avanade.SubTCSE.Projeto.Application.Dtos.Base
{
    public abstract class BaseDto
    {
        public string Identificador { get; set; }

        public ValidationResult ValidationResult { get; set; }
    }
}