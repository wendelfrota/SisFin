using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class ContaReceberRepository
    {
        private static List<ContaReceber> _contareceber = new List<ContaReceber>();

        public void Adicionar(ContaReceber contareceber)
        {
            _contareceber.Add(contareceber);
        }

        public IEnumerable<ContaReceber> ObterTodos()
        {
            return _contareceber;
        }
    }
}
