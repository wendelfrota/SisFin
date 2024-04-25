using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dados;

namespace Negocio
{
    public class CompraService
    {
        private readonly CompraRepository _repository;

        public CompraService()
        {
            _repository = new CompraRepository();
        }

        public void CadastrarCompra(int id, DateTime instante, String descricao, double desconto, double valor_total)
        {
            var compra = new Compra
            {
                Id = id,
                Instante = instante,
                Descricao = descricao,
                Desconto = desconto,
                Valor_total = valor_total 
            };

            _repository.Adicionar(compra);
        }

        public IEnumerable<Compra> ObterTodos()
        {
            return _repository.ObterTodos();
        }

    }
}
