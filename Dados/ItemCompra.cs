using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class ItemCompra

    { 
        private int quantidade { get; set; }
		private decimal preco { get; set; }

        public ItemCompra(int quantidade, decimal preco)
        {
            this.quantidade = quantidade;
            this.preco = preco;
        }
    }
}
