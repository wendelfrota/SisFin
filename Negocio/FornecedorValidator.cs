using FluentValidation;
using Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Negocio
{
    public class FornecedorValidator:AbstractValidator<Fornecedor>
    {
        FornecedorRepository _repository = new FornecedorRepository();
        public FornecedorValidator()
        {


            RuleFor(fornecedor => fornecedor.Numero).NotNull().NotEmpty().WithMessage("O campo número está inválido!");
            RuleFor(fornecedor => fornecedor.Cpf_cnpj).NotNull().NotEmpty().Length(11, 18).WithMessage("O campo CPF/CNPJ está invalido!");
            RuleFor(fornecedor => fornecedor.Email).NotNull().NotEmpty().Must(EmailExists).WithMessage("O email fornecido é invalido ou ja está cadastrado!");
        }

        private bool EmailExists(string email)
        {
            var fornecedores = _repository.getAll();
            int entries = 0;

            foreach (DataRow row in fornecedores.Rows)
            {
                if (row["Email"].ToString().Equals(email, StringComparison.OrdinalIgnoreCase))
                {
                    entries++;
                }
            }

            return entries > 1;
        }
    }
}
