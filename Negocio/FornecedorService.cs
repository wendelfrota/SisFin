using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dados;
using FluentValidation;

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
            {
                Console.WriteLine("Falha por validação");
                return "FALHA";
            }

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

        public DataTable getById(int id)
        {
            return _repository.getById(id);
        }

        public static Fornecedor fromDatatable(DataTable dt)
        {
            if(dt.Rows.Count == 0)
            {
                return new Fornecedor();
            }
            DataRow row = dt.Rows[0];
            Fornecedor f = new Fornecedor
            {
                Id = Convert.ToInt32(row["Id"]),
                TipoFornecedor = (TipoPessoa)row["TipoPessoa"],
                Nome = Convert.ToString(row["Nome"]),
                Email = Convert.ToString(row["Email"]),
                Cpf_cnpj = Convert.ToString(row["Cpf_cnpj"]),
                Razao_social = Convert.ToString(row["Razao_social"]),
                Cidade = Convert.ToString(row["Cidade"]),
                Rua = Convert.ToString(row["Rua"]),
                Bairro = Convert.ToString(row["Bairro"]),
                Complemento = Convert.ToString(row["Complemento"]),
                Numero = Convert.ToInt32(row["Numero"]),
                CEP = Convert.ToString(row["Cep"]),
                Telefone = Convert.ToString(row["Telefone"]),
                Celular = Convert.ToString(row["Celular"])
            };
            Console.WriteLine(f);
            return f;
        }
    }
}
