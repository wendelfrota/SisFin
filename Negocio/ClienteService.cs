using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dados;

namespace Negocio
{
    public class ClienteService
    {
        private readonly ClienteRepository _repository;

        public ClienteService()
        {
            _repository = new ClienteRepository();
        }

        public void CadastrarCliente(int id, TipoPessoa tipoCliente, String cpf_cnpj, String razaoSocial, DateTime dataNascimento, String nome, String rua, int numero, String bairro, String cidade, String complemento, String cep, String telefone, String email, String celular, decimal limite)
        {
            var cliente = new Cliente(id, tipoCliente, cpf_cnpj, razaoSocial, dataNascimento, nome, rua, numero, bairro, cidade, complemento, cep, telefone, email, celular, limite);

            _repository.Adicionar(cliente);
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            return _repository.ObterTodos();
        }

    }
}
