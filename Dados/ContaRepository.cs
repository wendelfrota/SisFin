using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class ContaRepository
    {
        private static List<Conta> _contas = new List<Conta>();

        public void Adicionar(Conta conta)
        {
            _contas.Add(conta);
        }

        public IEnumerable<Conta> ObterTodos()
        {
            return _contas;
        }
    }
}
