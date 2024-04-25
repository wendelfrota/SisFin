using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dados;

namespace Negocio
{
    public class ProdutoService
    {
        private readonly ProdutoRepository _repository;

        public ProdutoService()
        {
            _repository = new ProdutoRepository();
        }

        public void CadastrarProduto(int id, String nome, decimal preco)
        {
            var produto = new Produto
            {
                Id = id,
                Nome = nome,    
                Preco = preco
            };

            _repository.Adicionar(produto);
        }

        public IEnumerable<Produto> ObterTodos()
        {
            return _repository.ObterTodos();
        }

    }
}
