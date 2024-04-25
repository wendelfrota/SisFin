using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dados;

namespace Negocio
{
    public class ItemVendaService
    {
        private readonly ItemVendaRepository _repository;

        public ItemVendaService()
        {
            _repository = new ItemVendaRepository();
        }

        public void CadastrarItemVenda(int quantidade, decimal preco, decimal desconto)
        {
            var itemvenda = new ItemVenda
            {
                Quantidade = quantidade,
                Preco = preco,  
                Desconto = desconto
            };

            _repository.Adicionar(itemvenda);
        }

        public IEnumerable<ItemVenda> ObterTodos()
        {
            return _repository.ObterTodos();
        }

    }
}
