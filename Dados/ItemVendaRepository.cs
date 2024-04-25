using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class ItemVendaRepository
    {
        private static List<ItemVenda> _itemvendas = new List<ItemVenda>();

        public void Adicionar(ItemVenda itemvenda)
        {
            _itemvendas.Add(itemvenda);
        }

        public IEnumerable<ItemVenda> ObterTodos()
        {
            return _itemvendas;
        }
    }
}
