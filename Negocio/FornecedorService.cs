using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dados;
using MySql.Data.MySqlClient;

namespace Negocio
{
    public class FornecedorService
    {
        private FornecedorRepository _repository;

        public FornecedorService()
        {
            _repository = new FornecedorRepository();
        }

        public string Update(int? id, TipoPessoa tipoPessoa, string nome, string email)
        {
            // Insira as validações e regras de negócio aqui
            // Por exemplo, verificar se o email já está cadastrado

            var fornecedor = new Fornecedor
            {
                Id = id.Value,
                TipoFornecedor = tipoPessoa,
                Nome = nome,
                Email = email
            };

            if (id == null)
                return _repository.Insert(fornecedor);
            else
                return _repository.Update(fornecedor);

        }

        public string Insert(Fornecedor cliente)
        {
            // Insira as validações e regras de negócio aqui
            // Por exemplo, verificar se o email já está cadastrado

            return _repository.Insert(cliente);

        }
        public string Remove(int idCliente)
        {
            // Insira as validações e regras de negócio aqui
            // Por exemplo, verificar se o email já está cadastrado

            return _repository.Remove(idCliente);

        }

        public DataTable getAll()
        {
            return _repository.getAll();
        }
        public DataTable filterByName(string nome)
        {
            return _repository.filterByName(nome);
        }

    }
}
