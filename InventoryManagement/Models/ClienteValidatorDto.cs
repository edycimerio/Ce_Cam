using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Cliente.Domain.Dtos;

namespace ClienteManagement.Models
{
    

    public class ClienteValidatorDto : AbstractValidator<Clientes>
    {
        public ClienteValidatorDto()
        {
            //Definição das validações 
            RuleFor(x => x.RazaoSocial)
                .NotEmpty().WithMessage("Informe o nome da razão social")
                .Length(1,50).WithMessage("O nome deve ter no máximo 50 caracteres");

            RuleFor(c => c.Cnpj)
                .NotEmpty().WithMessage("Informe o numero do cnpj")
                .Length(1,18).WithMessage("O nome deve ter no máximo 18 caracteres");

            RuleFor(c => c.DataCadastro)
                .NotEmpty().WithMessage("Informe a data de cadastro");

            RuleFor(c => c.Ativo)
               .NotEmpty().WithMessage("O cadastro precisa ser ativo");
        }
        
    }
}
