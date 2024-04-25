using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class Produto

    { 
        private int id { get; set; }
		private String nome { get; set; }
		private decimal preco { get; set; }

        public Produto(int id, string nome, decimal preco)
        {
            this.id = id;
            this.nome = nome;
            this.preco = preco;
        }
    }
}
