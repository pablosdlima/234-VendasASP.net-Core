using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vendas.Models;
using Vendas.Models.ViewModels;
using Vendas.Services;

namespace Vendas.Controllers
{
    public class VendedoresController : Controller
    {
        private readonly ServicoVendas _servicoVendas;
        private readonly DepartamentoServico _departamentoServico;

        public VendedoresController(ServicoVendas servicoVendas, DepartamentoServico departamentoServico)
        {
            _servicoVendas = servicoVendas;
            _departamentoServico = departamentoServico;
        }

        public IActionResult Index()
        {
            var lista = _servicoVendas.FindAll();
            return View(lista);
        }

        public IActionResult Create() //metodo para retorndo da Page
        {
            var departamentos = _departamentoServico.FindAll(); //busca do Bd todos os departamentos.
            var viewModel = new VendasViewModel { Departamentoes = departamentos };
            return View(viewModel);
        }

        [HttpPost] //informa que metodo é post
        [ValidateAntiForgeryToken] //evita fraudes
        public IActionResult Create(Vendedor vendedor)
        {
            _servicoVendas.Insert(vendedor);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obj = _servicoVendas.FindById(id.Value);

            if(obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _servicoVendas.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}