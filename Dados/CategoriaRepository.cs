using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class CategoriaRepository
    {
        private static List<Categoria> _categorias = new List<Categoria>();

        public void Adicionar(Categoria categoria)
        {
            _categorias.Add(categoria);
        }

        public IEnumerable<Categoria> ObterTodos()
        {
            return _categorias;
        }
    }
}
