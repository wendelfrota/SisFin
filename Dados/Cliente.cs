using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class Cliente
    {
        public int Id { get; set; }
		public TipoPessoa TipoCliente { get; set; }
		public String Cpf_cnpj { get; set; }
		public String RazaoSocial { get; set; }
		public DateTime DataNascimento { get; set; }
        public String Nome { get; set; }
        public String Rua { get; set; }
		public int Numero { get; set; }
        public String Bairro { get; set; }
		public String Cidade { get; set; }
		public String Complemento { get; set; }
		public String CEP { get; set; }
		public String Telefone { get; set; }
		public String Email { get; set; }
		public String Celular { get; set; }
		public decimal Limite { get; set; }
    }
}
