using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vendas.Models.Enum;

namespace Vendas.Models
{
    public class VendasContext : DbContext
    {
        public VendasContext (DbContextOptions<VendasContext> options)
            : base(options)
        {
        }

        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<VendasRecord> VendasRecord { get; set; }
        public DbSet<Vendedor> Vendedor { get; set; }
    }
}
