using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class ControleCaixa

    { 
        private int id { get; set; }
		private decimal valor { get; set; }
		private DateTime data { get; set; }

        public ControleCaixa(int id, decimal valor, DateTime data)
        {
            this.id = id;
            this.valor = valor;
            this.data = data;
        }
    }
}
