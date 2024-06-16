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
            int id, TipoPessoa tipoFornecedor, String cpf_cnpj,
            String nome, String rua, int numero, String bairro,
            String cidade, String complemento, String cep,
            String telefone, String celular, String email, Boolean isNew)
        {
            // Insira as validações e regras de negócio aqui
            // Por exemplo, verificar se o email já está cadastrado
            var fornecedor = new Fornecedor
            {
                Id = id,
                TipoFornecedor = tipoFornecedor,
                Nome = nome,
                Email = email,
                Cpf_cnpj = cpf_cnpj,
                Cidade = cidade,
                Rua = rua,
                Bairro = bairro,
                Complemento = complemento,
                Numero = numero,
                CEP = cep,
                Telefone = telefone,
                Celular = celular
            };

            if (isNew)
                return _repository.Insert(fornecedor);
            else
                return _repository.Update(fornecedor);

        }

        public string Insert(Fornecedor fornecedor)
        {
            // Insira as validações e regras de negócio aqui
            // Por exemplo, verificar se o email já está cadastrado

            return _repository.Insert(fornecedor);

        }
        public string Remove(int idFornecedor)
        {
            // Insira as validações e regras de negócio aqui
            // Por exemplo, verificar se o email já está cadastrado

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

    }
}
