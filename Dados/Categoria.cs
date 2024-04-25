using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class Categoria

    { 
        private int id { get; set; }
		private String nome { get; set; }

        public Categoria(int id, string nome)
        {
            this.id = id;
            this.nome = nome;
        }
    }
}
