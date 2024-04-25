using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dados;

namespace Negocio
{
    public class ContaReceberService
    {
        private readonly ContaReceberRepository _repository;

        public ContaReceberService()
        {
            _repository = new ContaReceberRepository();
        }

        public void CadastrarContaReceber(int id, decimal valor, DateTime dataCadastro, DateTime dataVencimento, DateTime dataRecebimento, decimal valorRecebido, MeioPagamento meioPagamento, EstadoPagamento situacao)
        {
            var contareceber = new ContaReceber
            {
                Id = id,
                MeioPagamento = meioPagamento,
                DataVencimento = dataVencimento,
                DataCadastro = dataCadastro,
                DataRecebimento = dataRecebimento,
                ValorRecebido = valorRecebido,
                Valor = valor,
                Situacao = situacao
            };

            _repository.Adicionar(contareceber);
        }

        public IEnumerable<ContaReceber> ObterTodos()
        {
            return _repository.ObterTodos();
        }

    }
}
