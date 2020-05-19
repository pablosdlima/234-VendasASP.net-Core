using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vendas.Models;

namespace Vendas.Services
{
    public class ServicoVendas
    {
        private readonly VendasContext _context; //obj de leitura 

        public ServicoVendas(VendasContext context)
        {
            _context = context;
        }

        public List<Vendedor> FindAll()
        {
            return _context.Vendedor.ToList();
        }
        public void Insert(Vendedor obj)
        {
            obj.Departamento = _context.Departamento.First(); //pega o primeiro registro de departamento
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
