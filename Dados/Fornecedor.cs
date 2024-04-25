using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class Fornecedor

    { 
        private int id { get; set; }
		private TipoPessoa tipoFornecedor { get; set; }
		private String cpf_cnpj { get; set; }
		private String razao_social { get; set; }
		private String nome { get; set; }
		private String rua { get; set; }
		private int numero { get; set; }
		private String bairro { get; set; }
		private String cidade { get; set; }
		private String complemento { get; set; }
		private String cep { get; set; }
		private String telefone { get; set; }
		private String celular { get; set; }
		private String email { get; set; }

        public Fornecedor(int id, TipoPessoa tipoFornecedor, string cpf_cnpj, string razao_social, string nome, string rua, int numero, string bairro, string cidade, string complemento, string cep, string telefone, string celular, string email)
        {
            this.id = id;
            this.tipoFornecedor = tipoFornecedor;
            this.cpf_cnpj = cpf_cnpj;
            this.razao_social = razao_social;
            this.nome = nome;
            this.rua = rua;
            this.numero = numero;
            this.bairro = bairro;
            this.cidade = cidade;
            this.complemento = complemento;
            this.cep = cep;
            this.telefone = telefone;
            this.celular = celular;
            this.email = email;
        }
    }
}
