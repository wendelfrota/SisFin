using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class ContaPagar

    { 
        private int id { get; set; }
		private decimal valor { get; set; }
		private DateTime dataCadastro { get; set; }
		private DateTime dataVencimento { get; set; }
		private DateTime dataPagamento { get; set; }
		private MeioPagamento meioPagamento { get; set; }
		private EstadoPagamento situacao { get; set; }

        public ContaPagar(int id, decimal valor, DateTime dataCadastro, DateTime dataVencimento, DateTime dataPagamento, MeioPagamento meioPagamento, EstadoPagamento situacao)
        {
            this.id = id;
            this.valor = valor;
            this.dataCadastro = dataCadastro;
            this.dataVencimento = dataVencimento;
            this.dataPagamento = dataPagamento;
            this.meioPagamento = meioPagamento;
            this.situacao = situacao;
        }
    }
}
