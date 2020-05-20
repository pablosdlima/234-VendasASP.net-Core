using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vendas.Models;

namespace Vendas.Services
{
    public class DepartamentoServico
    {
        private readonly VendasContext _context; //obj de leitura 

        public DepartamentoServico(VendasContext context)
        {
            _context = context;
        }

        public List<Departamento> FindAll()
        {
            return _context.Departamento.OrderBy(x => x.Nome).ToList(); //retornar nomes ordenados.
        }
    }
}
