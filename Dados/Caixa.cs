using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class Caixa

    { 
        private int id { get; set; }
		private String nome { get; set; }

        public Caixa(int id, string nome)
        {
            this.id = id;
            this.nome = nome;
        }
    }
}
