using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class Conta

    { 
        private int id { get; set; }
		private String descricao { get; set; }
		private TipoConta tipo { get; set; }
		private bool status { get; set; }

        public Conta(int id, string descricao, TipoConta tipo, bool status)
        {
            this.id = id;
            this.descricao = descricao;
            this.tipo = tipo;
            this.status = status;
        }
    }
}
