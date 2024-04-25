using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dados;

namespace Negocio
{
    public class ContaPagarService
    {
        private readonly ContaPagarRepository _repository;

        public ContaPagarService()
        {
            _repository = new ContaPagarRepository();
        }

        public void CadastrarContaPagar(int id, decimal valor, DateTime dataCadastro, DateTime dataVencimento, DateTime dataPagamento, MeioPagamento meioPagamento, EstadoPagamento situacao)
        {
            var contapagar = new ContaPagar
            {
                Id = id,
                Valor = valor,  
                DataCadastro = dataCadastro,
                DataPagamento = dataPagamento,
                DataVencimento = dataVencimento,
                MeioPagamento = meioPagamento,
                Situacao = situacao
            };


            _repository.Adicionar(contapagar);
        }

        public IEnumerable<ContaPagar> ObterTodos()
        {
            return _repository.ObterTodos();
        }

    }
}
