using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dados;

namespace Negocio
{
    public class ControleCaixaService
    {
        private readonly ControleCaixaRepository _repository;

        public ControleCaixaService()
        {
            _repository = new ControleCaixaRepository();
        }

        public void CadastrarControleCaixa(int id, decimal valor, DateTime data)
        {
            var controlecaixa = new ControleCaixa { 
                Id = id,
                Valor = valor,  
                Data = data
            };

            _repository.Adicionar(controlecaixa);
        }

        public IEnumerable<ControleCaixa> ObterTodos()
        {
            return _repository.ObterTodos();
        }

    }
}
