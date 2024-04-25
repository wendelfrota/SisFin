using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class Venda 
    { 
        private int id { get; set; }
		private DateTime instante { get; set; }
		private String descricao { get; set; }
		private double desconto { get; set; }
		private double valor_total { get; set; }

        public Venda(int id, DateTime instante, string descricao, double desconto, double valor_total)
        {
            this.id = id;
            this.instante = instante;
            this.descricao = descricao;
            this.desconto = desconto;
            this.valor_total = valor_total;
        }
    }
}
