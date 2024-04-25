using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dados;

namespace Negocio
{
    public class FornecedorService
    {
        private readonly FornecedorRepository _repository;

        public FornecedorService()
        {
            _repository = new FornecedorRepository();
        }

        public void CadastrarFornecedor(int id, TipoPessoa tipoFornecedor, String cpf_cnpj, String razao_social, String nome, String rua, int numero, String bairro, String cidade, String complemento, String cep, String telefone, String celular, String email)
        {
            var fornecedor = new Fornecedor(id, tipoFornecedor, cpf_cnpj, razao_social, nome, rua, numero, bairro, cidade, complemento, cep, telefone, celular, email);

            _repository.Adicionar(fornecedor);
        }

        public IEnumerable<Fornecedor> ObterTodos()
        {
            return _repository.ObterTodos();
        }

    }
}
