using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class Cliente
    { 
        private int id { get; set; }
		private TipoPessoa tipoCliente { get; set; }
		private String cpf_cnpj { get; set; }
		private String razaoSocial { get; set; }
		private DateTime dataNascimento { get; set; }
		private String nome { get; set; }
		private String rua { get; set; }
		private int numero { get; set; }
		private String bairro { get; set; }
		private String cidade { get; set; }
		private String complemento { get; set; }
		private String cep { get; set; }
		private String telefone { get; set; }
		private String email { get; set; }
		private String celular { get; set; }
		private decimal limite { get; set; }

        public Cliente(int id, TipoPessoa tipoCliente, string cpf_cnpj, string razaoSocial, DateTime dataNascimento, string nome, string rua, int numero, string bairro, string cidade, string complemento, string cep, string telefone, string email, string celular, decimal limite)
        {
            this.id = id;
            this.tipoCliente = tipoCliente;
            this.cpf_cnpj = cpf_cnpj;
            this.razaoSocial = razaoSocial;
            this.dataNascimento = dataNascimento;
            this.nome = nome;
            this.rua = rua;
            this.numero = numero;
            this.bairro = bairro;
            this.cidade = cidade;
            this.complemento = complemento;
            this.cep = cep;
            this.telefone = telefone;
            this.email = email;
            this.celular = celular;
            this.limite = limite;
        }
    }
}
