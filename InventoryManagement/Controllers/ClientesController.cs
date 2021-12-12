using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cecam.Models;
using Cliente.Domain.Interfaces;
using Cliente.Domain.Dtos;

namespace Cecam.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IClientesService _clientesService;
        

        public ClientesController(IClientesService clientesService)
        {
            _clientesService = clientesService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _clientesService.ListClientes());
        }

        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var _clientes = await _clientesService.Details(id);

            if (_clientes == null)
            {
                return NotFound();
            }

            return View(_clientes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClienteId,RazaoSocial,Cnpj,DataCadastro,Ativo")] Clientes clientes)
        {
            if (ModelState.IsValid)
            {
                await _clientesService.Create(clientes);

                return RedirectToAction(nameof(Index));
            }
            return View(clientes);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var _clientes = await _clientesService.Edit(id);

            if (_clientes == null)
            {
                return NotFound();
            }
            return View(_clientes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClienteId,RazaoSocial,Cnpj,DataCadastro,Ativo")] Clientes _clientes)
        {
            if (id != _clientes.ClienteId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _clientesService.Edit(_clientes);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var result = await Task.Run(() => ClientesExists(_clientes.ClienteId));

                    if (!result)
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(_clientes);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var _clientes = await _clientesService.Delete(id);

            if (_clientes == null)
            {
                return NotFound();
            }

            return View(_clientes);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _clientesService.DeleteConfirmed(id);

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> ClientesExists(int id)
        {
            var existe = await _clientesService.ClientesExists(id);

            return existe;
        }
    }
}
