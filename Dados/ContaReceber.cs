using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class ContaReceber

    { 
        private int id { get; set; }
		private decimal valor { get; set; }
		private DateTime dataCadastro { get; set; }
		private DateTime dataVencimento { get; set; }
		private DateTime dataRecebimento { get; set; }
		private decimal valorRecebido { get; set; }
		private MeioPagamento meioPagamento { get; set; }
		private EstadoPagamento situacao { get; set; }

        public ContaReceber(int id, decimal valor, DateTime dataCadastro, DateTime dataVencimento, DateTime dataRecebimento, decimal valorRecebido, MeioPagamento meioPagamento, EstadoPagamento situacao)
        {
            this.id = id;
            this.valor = valor;
            this.dataCadastro = dataCadastro;
            this.dataVencimento = dataVencimento;
            this.dataRecebimento = dataRecebimento;
            this.valorRecebido = valorRecebido;
            this.meioPagamento = meioPagamento;
            this.situacao = situacao;
        }
    }
}
