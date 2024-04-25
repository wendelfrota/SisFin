using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class FornecedorRepository
    {
        private static List<Fornecedor> _fornecedores = new List<Fornecedor>();

        public void Adicionar(Fornecedor fornecedor)
        {
            _fornecedores.Add(fornecedor);
        }

        public IEnumerable<Fornecedor> ObterTodos()
        {
            return _fornecedores;
        }
    }
}
