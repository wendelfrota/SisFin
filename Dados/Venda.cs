using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class Venda 
    { 
        public int Id { get; set; }
		public DateTime Instante { get; set; }
		public String Descricao { get; set; }
		public double Desconto { get; set; }
        public double Valor_total { get; set; } 
    }
}
