using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vendas.Models;
using Microsoft.EntityFrameworkCore;

namespace Vendas.Services
{
    public class VendasRecordeServico
    {
        private readonly VendasContext _context; //obj de leitura 

        public VendasRecordeServico(VendasContext context)
        {
            _context = context;
        }

        public async Task<List<VendasRecord>> FindByDateAsync(DateTime? minData, DateTime? maxData)
        {
            var Resultado = from obj in _context.VendasRecord select obj;
            if (minData.HasValue)
            {
                Resultado = Resultado.Where(x => x.Data >= minData.Value);
            }
            if (maxData.HasValue)
            {
                Resultado = Resultado.Where(x => x.Data <= maxData.Value);
            }
            return await Resultado.Include(x => x.Vendedor).Include(x => x.Vendedor.Departamento).OrderByDescending(x => x.Data).ToListAsync();
        }

        public async Task<List<IGrouping<Departamento, VendasRecord>>> FindByDateGroupingAsync(DateTime? minData, DateTime? maxData)
        {
            var Resultado = from obj in _context.VendasRecord select obj;
            if (minData.HasValue)
            {
                Resultado = Resultado.Where(x => x.Data >= minData.Value);
            }
            if (maxData.HasValue)
            {
                Resultado = Resultado.Where(x => x.Data <= maxData.Value);
            }
            return await Resultado.Include(x => x.Vendedor).Include(x => x.Vendedor.Departamento).OrderByDescending(x => x.Data).GroupBy(x => x.Vendedor.Departamento).ToListAsync();
        }
    }
}
