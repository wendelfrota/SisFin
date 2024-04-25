using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class Conta

    { 
        public int Id { get; set; }
		public String Descricao { get; set; }
		public TipoConta Tipo { get; set; }
        public bool Status { get; set; } 
    }
}
