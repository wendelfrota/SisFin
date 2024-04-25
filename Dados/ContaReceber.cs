using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class ContaReceber

    { 
        public int Id { get; set; }
		public decimal Valor { get; set; }
		public DateTime DataCadastro { get; set; }
		public DateTime DataVencimento { get; set; }
		public DateTime DataRecebimento { get; set; }
		public decimal ValorRecebido { get; set; }
		public MeioPagamento MeioPagamento { get; set; }
        public EstadoPagamento Situacao { get; set; } 
    }
}
