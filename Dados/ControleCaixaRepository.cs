using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    public class ControleCaixaRepository
    {
        private static List<ControleCaixa> _controlecaixas = new List<ControleCaixa>();

        public void Adicionar(ControleCaixa controlecaixa)
        {
            _controlecaixas.Add(controlecaixa);
        }

        public IEnumerable<ControleCaixa> ObterTodos()
        {
            return _controlecaixas;
        }
    }
}
