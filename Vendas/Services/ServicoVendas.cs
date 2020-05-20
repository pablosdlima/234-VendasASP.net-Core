using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vendas.Models;
using Vendas.Services.Exceptions;

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
            return _context.Vendedor.Include(obj => obj.Departamento).ToList();
        }
        public void Insert(Vendedor obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Vendedor FindById(int id)
        {
            return _context.Vendedor.Include(obj => obj.Departamento).FirstOrDefault(obj => obj.ID == id);
        }

        public void Remove(int id)
        {
            var obj = _context.Vendedor.Find(id);
            _context.Vendedor.Remove(obj);
            _context.SaveChanges();
        }

        public void Update(Vendedor obj)
        {
            if (!_context.Vendedor.Any(x => x.ID == obj.ID))
            {
                throw new NotFoundException("Id não existe...");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch(DBConcurrencyException e)
            {
                throw new DBConcurrencyException(e.Message);
            }

        }
    }
}
