using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class ClienteRepository
    {
        private static List<Cliente> _clientes = new List<Cliente>();

        public void Adicionar(Cliente cliente)
        {
            _clientes.Add(cliente);
        }

        public IEnumerable<Cliente> ObterTodos()
        {
            return _clientes;
        }
    }
}
