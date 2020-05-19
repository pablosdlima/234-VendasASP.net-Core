using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vendas.Models;
using Vendas.Services;

namespace Vendas.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly ServicoVendas _servicoVendas;

        public VendedoresController(ServicoVendas servicoVendas)
        {
            _servicoVendas = servicoVendas;
        }

        public IActionResult Index()
        {
            var lista = _servicoVendas.FindAll();
            return View(lista);
        }

        public IActionResult Create() //metodo para retorndo da Page
        {
            return View();
        }

        [HttpPost] //informa que metodo é post
        [ValidateAntiForgeryToken] //evita fraudes
        public IActionResult Create(Vendedor vendedor)
        {
            _servicoVendas.Insert(vendedor);
            return RedirectToAction(nameof(Index));
        }
    }
}