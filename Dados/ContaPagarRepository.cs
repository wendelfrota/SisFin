using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class ContaPagarRepository
    {
        private static List<ContaPagar> _contapagar = new List<ContaPagar>();

        public void Adicionar(ContaPagar contapagar)
        {
            _contapagar.Add(contapagar);
        }

        public IEnumerable<ContaPagar> ObterTodos()
        {
            return _contapagar;
        }
    }
}
