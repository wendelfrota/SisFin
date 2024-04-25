using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dados;

namespace Negocio
{
    public class ContaService
    {
        private readonly ContaRepository _repository;

        public ContaService()
        {
            _repository = new ContaRepository();
        }

        public void CadastrarConta(int id, String descricao, TipoConta tipo, bool status)
        {
            var conta = new Conta
            {
                Id = id,
                Descricao = descricao,  
                Status = status,
                Tipo = tipo
            };

            _repository.Adicionar(conta);
        }

        public IEnumerable<Conta> ObterTodos()
        {
            return _repository.ObterTodos();
        }

    }
}
