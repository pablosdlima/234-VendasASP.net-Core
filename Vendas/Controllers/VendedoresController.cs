using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vendas.Models;
using Vendas.Models.ViewModels;
using Vendas.Services;
using Vendas.Services.Exceptions;

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
                return RedirectToAction(nameof(Error), new { messagem = "Id Não encontrado" } );
            }

            var obj = _servicoVendas.FindById(id.Value);

            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { messagem = "Id Não encontrado" } );
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

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { messagem = "Id Não encontrado" } );
            }

            var obj = _servicoVendas.FindById(id.Value);

            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { messagem = "Id Não encontrado" } );
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { messagem = "Id Não encontrado" } );
            }
            var obj = _servicoVendas.FindById(id.Value);
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { messagem = "Id Não encontrado" } );
            }
            List<Departamento> departamentos = _departamentoServico.FindAll();
            VendasViewModel viewModel = new VendasViewModel { Vendedor = obj, Departamentoes = departamentos };

            return View(viewModel);
        }

        [HttpPost] //informa que metodo é post
        [ValidateAntiForgeryToken] //evita fraudes
        public IActionResult Edit(int id,Vendedor vendedor)
        {
            if (id != vendedor.ID)
            {
                return RedirectToAction(nameof(Error), new { messagem = "Id Não encontrado" } );
            }
            try
            {
                _servicoVendas.Update(vendedor);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException)
            {
                return RedirectToAction(nameof(Error), new { messagem = "Id Não encontrado" } );
            }
            catch (DBConcurrencyException)
            {
                return RedirectToAction(nameof(Error), new { messagem = "Id Não encontrado" } );
            }
        }

        public IActionResult Error (string messagem)
        {
            var viewModel = new ErrorViewModel
            {
                Mensagem = messagem,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View();
        }
    }
}