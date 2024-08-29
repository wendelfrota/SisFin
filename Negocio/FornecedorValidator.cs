using FluentValidation;
using Dados;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using FluentValidation.Resources;
using System.Globalization;
using FluentValidation.Results;

namespace Negocio
{
    public class FornecedorValidator:AbstractValidator<Fornecedor>
    {
        FornecedorRepository _repository = new FornecedorRepository();
        
        private bool isCreatingNewFornecedor;
        private int currentFornecedorId;
        public FornecedorValidator()
        {
            LanguageManager mgr = new LanguageManager();
            mgr.Culture = CultureInfo.GetCultureInfo("pt-BR");
            ValidatorOptions.Global.LanguageManager = mgr;

            RuleFor(fornecedor => fornecedor.Numero).NotNull().NotEmpty();
            RuleFor(fornecedor => fornecedor.Cpf_cnpj).NotNull().NotEmpty().Length(11, 18).WithMessage("O campo CPF/CNPJ está invalido!");
            RuleFor(fornecedor => fornecedor.Email).NotNull().NotEmpty().EmailAddress().WithMessage("O email fornecido e invalido");
            RuleFor(fornecedor => fornecedor.Razao_social).NotNull().NotEmpty().Length(2, 60).WithMessage("A Razão social deve ter entre 2 e 60 caracteres!");
            RuleFor(fornecedor => fornecedor.Celular).NotNull().NotEmpty().Matches("[0-9]").WithMessage("O celular deve conter apenas números").Length(11).WithMessage("O celular deverá ter 11 dígitos");
            RuleFor(fornecedor => fornecedor.CEP).NotNull().NotEmpty().Matches("[0-9]").WithMessage("O CEP deve conter apenas numeros!").Length(8).WithMessage("O CEP deve conter 8 digitos");
            RuleFor(fornecedor => fornecedor.Rua).NotNull().NotEmpty();
            RuleFor(fornecedor => fornecedor.Complemento).NotNull();
            RuleFor(fornecedor => fornecedor.Cidade).NotNull().NotEmpty();
            RuleFor(fornecedor => fornecedor.Bairro).NotNull().NotEmpty();
            RuleFor(fornecedor => fornecedor.Telefone).NotNull().NotEmpty().Matches("[0-9]").WithMessage("O Telefone deve conter apenas números!").Length(8).WithMessage("O Telefone deve conter 8 dígitos");

        }

        public ValidationResult ValidateWithState(Fornecedor f, Boolean creatingNewFornecedor)
        {
            this.isCreatingNewFornecedor = creatingNewFornecedor;
            this.currentFornecedorId = f.Id;
            return Validate(f);
        }

    }
}
