using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vendas.Services;

namespace Vendas.Controllers
{
    public class VendasRecordController : Controller
    {
        private readonly VendasRecordeServico _vendasRecordServico;

        public VendasRecordController(VendasRecordeServico vendasRecordServico)
        {
            _vendasRecordServico = vendasRecordServico;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> BuscaSimples(DateTime? minData, DateTime? maxData)
        {
            var resultado = await _vendasRecordServico.FindByDateAsync(minData, maxData);
            return View(resultado);
        }
        public async Task<IActionResult> BuscarGrupo(DateTime? minData, DateTime? maxData)
        {
            var resultado = await _vendasRecordServico.FindByDateGroupingAsync(minData, maxData);
            return View(resultado);
        }
    }
}