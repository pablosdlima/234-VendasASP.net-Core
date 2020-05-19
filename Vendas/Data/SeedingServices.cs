using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vendas.Models;

namespace Vendas.Data
{
    public class SeedingServices //context para gravar os dados na inicialização.
    {
        private VendasContext _context;

        public SeedingServices(VendasContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if(_context.Departamento.Any() ||
                    _context.Vendedor.Any() ||
                    _context.VendasRecord.Any())
            {

                return;
            }

            Departamento d1 = new Departamento(1, "Computador");
            Departamento d2 = new Departamento(1, "Eletronico");
            Departamento d3 = new Departamento(1, "Moda");
            Departamento d4 = new Departamento(1, "Livros");

            Vendedor vend1 = new Vendedor(1, "Fulano de tal", "Fulano@email.com", 1000.0, new DateTime(1990, 4, 2), d1);
            Vendedor vend2 = new Vendedor(2, "Beltrano de tal", "Beltrano@email.com", 1000.0, new DateTime(1990, 7, 2), d1);
            Vendedor vend3 = new Vendedor(3, "Siclano de tal", "Siclano@email.com", 1000.0, new DateTime(1990, 4, 8), d1);

            VendasRecord vr1 = new VendasRecord(1, new DateTime(2000, 01, 10), 1100.00, Models.Enum.VendasStatus.Fatura, vend1);

            _context.Departamento.AddRange(d1, d2, d3, d4);
            _context.Vendedor.AddRange(vend1, vend2, vend3);
            _context.VendasRecord.AddRange(vr1);


        }
    }
}
