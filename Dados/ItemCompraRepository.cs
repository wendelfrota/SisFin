using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class ItemCompraRepository
    {
        private static List<ItemCompra> _itemcompras = new List<ItemCompra>();

        public void Adicionar(ItemCompra itemcompra)
        {
            _itemcompras.Add(itemcompra);
        }

        public IEnumerable<ItemCompra> ObterTodos()
        {
            return _itemcompras;
        }
    }
}
