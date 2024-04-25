using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class CompraRepository
    {
        private static List<Compra> _compras = new List<Compra>();

        public void Adicionar(Compra compra)
        {
            _compras.Add(compra);
        }

        public IEnumerable<Compra> ObterTodos()
        {
            return _compras;
        }
    }
}
