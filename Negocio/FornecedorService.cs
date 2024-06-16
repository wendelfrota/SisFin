using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dados;

namespace Negocio
{
    public class FornecedorService
    {
        private FornecedorRepository _repository;

        public FornecedorService()
        {
            _repository = new FornecedorRepository();
        }

        public string Update(
            int id, TipoPessoa tipoFornecedor, String cpf_cnpj, string razao_social,
            String nome, String rua, int numero, String bairro,
            String cidade, String complemento, String cep,
            String telefone, String celular, String email, Boolean isNew)
        {
                var fornecedor = new Fornecedor
            {
                Id = id,
                TipoFornecedor = tipoFornecedor,
                Nome = nome,
                Email = email,
                Cpf_cnpj = cpf_cnpj,
                Razao_social = razao_social,
                Cidade = cidade,
                Rua = rua,
                Bairro = bairro,
                Complemento = complemento,
                Numero = numero,
                CEP = cep,
                Telefone = telefone,
                Celular = celular
            };

            if (!isValidFornecedor(fornecedor))
                return "FALHA";

            if (isNew)
                return _repository.Insert(fornecedor);
            else
                return _repository.Update(fornecedor);

        }

        public string Insert(Fornecedor fornecedor)
        {
            if (isValidFornecedor(fornecedor))
                return _repository.Insert(fornecedor);
            return "FALHA";
        }
        public string Remove(int idFornecedor)
        {
            return _repository.Remove(idFornecedor);
        }

        public DataTable getAll()
        {
            return _repository.getAll();
        }
        public DataTable filterByName(string nome)
        {
            return _repository.filterByName(nome);
        }

        private bool isValidFornecedor(Fornecedor f)
        {
            if (!IsValidEmail(f.Email) || EmailExists(f.Email))
                return false;
            return true;
        }

        private bool EmailExists(string email)
        {
            var fornecedores = _repository.getAll();

            foreach (DataRow row in fornecedores.Rows)
                if (row["Email"].ToString().Equals(email, StringComparison.OrdinalIgnoreCase))
                    return true;
                
            return false;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
