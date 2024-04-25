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
            var cliente = new Cliente
            {
                Id = id,
                TipoCliente = tipoCliente,
                Cpf_cnpj = cpf_cnpj,
                RazaoSocial = razaoSocial,
                DataNascimento = dataNascimento,
                Nome = nome,    
                Rua = rua,
                Numero = numero,
                Bairro = bairro,
                Cidade = cidade,
                Complemento = complemento,
                CEP = cep,
                Telefone = telefone,
                Email = email,
                Celular = celular,
                Limite = limite
            };

            _repository.Adicionar(cliente);
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            return _repository.ObterTodos();
        }

    }
}
