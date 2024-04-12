using FluentValidation.Results;
using System.Collections.Generic;

namespace Avanade.SubTCSE.Projeto.Domain.Aggregates
{
    public record BaseEntity<Tid>
    {
        public Tid Id { get; set; }

        public List<string> Erros { get; set; }
    }
}