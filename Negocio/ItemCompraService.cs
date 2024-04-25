using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dados;

namespace Negocio
{
    public class ItemCompraService
    {
        private readonly ItemCompraRepository _repository;

        public ItemCompraService()
        {
            _repository = new ItemCompraRepository();
        }

        public void CadastrarItemCompra(int quantidade, decimal preco)
        {
            var itemcompra = new ItemCompra(quantidade, preco);

            _repository.Adicionar(itemcompra);
        }

        public IEnumerable<ItemCompra> ObterTodos()
        {
            return _repository.ObterTodos();
        }

    }
}
