using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vendas.Models.ViewModels
{
    public class VendasViewModel
    {
        public Vendedor Vendedor { get; set; }
        public ICollection<Departamento> Departamentoes { get; set; }
    }
}
