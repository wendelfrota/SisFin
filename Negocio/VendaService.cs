using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dados;

namespace Negocio
{
    public class VendaService
    {
        private readonly VendaRepository _repository;

        public VendaService()
        {
            _repository = new VendaRepository();
        }

        public void CadastrarVenda(int id, DateTime instante, String descricao, double desconto, double valor_total)
        {
            var venda = new Venda
            {
                Id = id,
                Instante = instante,
                Descricao = descricao,
                Desconto = desconto,
                Valor_total = valor_total
            };

            _repository.Adicionar(venda);
        }

        public IEnumerable<Venda> ObterTodos()
        {
            return _repository.ObterTodos();
        }

    }
}
