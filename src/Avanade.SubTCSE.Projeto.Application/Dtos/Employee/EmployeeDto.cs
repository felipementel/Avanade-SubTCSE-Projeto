using Avanade.SubTCSE.Projeto.Application.Dtos.Base;
using Avanade.SubTCSE.Projeto.Application.Dtos.EmployeeRole;
using System;

namespace Avanade.SubTCSE.Projeto.Application.Dtos.Employee
{
    public class EmployeeDto : BaseDto
    {
        public string PrimeiroNome { get; set; }

        public string Sobrenome { get; set; }

        public DateTime Aniversario { get; set; }

        public bool Ativo { get; set; }

        public decimal Salario { get; set; }

        public FavoriteColor FavoriteColor { get; set; }

        public EmployeeRoleDto Cargo { get; set; }
    }
}