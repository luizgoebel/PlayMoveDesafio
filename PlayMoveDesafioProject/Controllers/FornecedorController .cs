using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PlayMoveDesafioProject.Data;
using PlayMoveDesafioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayMoveDesafioProject.Controllers
{
    public class FornecedorController : Controller
    {
        private readonly WebContext _context;

        public FornecedorController(WebContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var resultado = await _context.Fornecedores
                .Include(x => x.Empresa)
                .OrderByDescending(d => d.Id)
                .AsNoTracking().ToListAsync();

            return View(resultado);
        }

        [HttpGet]
        public async Task<IActionResult> Cadastrar()
        {
            ViewData["empresaId"] = new SelectList(_context.Empresas, "Id", "NomeFantasia");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(Fornecedor fornecedor)
        {
            //ViewData["empresaId"] = new SelectList(_context.Empresas, "Id", "NomeFantasia");
            fornecedor.CadastradoEm = DateTime.Now;

            if (ModelState.IsValid)
            {
                _context.Fornecedores.Add(fornecedor);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(fornecedor);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var result = await _context.Fornecedores.FirstOrDefaultAsync(x => x.Id == id);
            ViewData["empresaId"] = new SelectList(_context.Empresas, "Id", "NomeFantasia");

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Fornecedor fornecedor)
        {
            if (fornecedor == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Fornecedores.Update(fornecedor);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(fornecedor);
        }

        [HttpGet]
        public async Task<IActionResult> Deletar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewData["empresaId"] = new SelectList(_context.Empresas, "Id", "NomeFantasia");

            var result = await _context.Fornecedores.Include(x => x.Empresa).FirstOrDefaultAsync(x => x.Id == id);

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Deletar(int id)
        {
            var result = await _context.Fornecedores.FirstOrDefaultAsync(x => x.Id == id);
            _context.Fornecedores.Remove(result);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewData["empresaId"] = new SelectList(_context.Empresas, "Id", "NomeFantasia");
            var result = await _context.Fornecedores.Include(x => x.Empresa).FirstOrDefaultAsync(x => x.Id == id);


            return View(result);
        }
    }
}
