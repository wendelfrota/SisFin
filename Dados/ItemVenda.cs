using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class ItemVenda

    { 
        private int quantidade { get; set; }
		private decimal preco { get; set; }
		private decimal desconto { get; set; }

        public ItemVenda(int quantidade, decimal preco, decimal desconto)
        {
            this.quantidade = quantidade;
            this.preco = preco;
            this.desconto = desconto;
        }
    }
}
