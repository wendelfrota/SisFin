using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class VendaRepository
    {
        private static List<Venda> _vendas = new List<Venda>();

        public void Adicionar(Venda venda)
        {
            _vendas.Add(venda);
        }

        public IEnumerable<Venda> ObterTodos()
        {
            return _vendas;
        }
    }
}
