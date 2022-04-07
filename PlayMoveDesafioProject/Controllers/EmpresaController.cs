using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlayMoveDesafioProject.Data;
using PlayMoveDesafioProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PlayMoveDesafioProject.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly WebContext _context;

        public EmpresaController(WebContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var resultado = await _context.Empresas
                .OrderByDescending(d => d.Id)
                .AsNoTracking().ToListAsync();

            return View(resultado);
        }
        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                _context.Empresas.Add(empresa);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(empresa);
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var result = await _context.Empresas.FirstOrDefaultAsync(x => x.Id == id);

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Empresa empresa)
        {
            if (empresa == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Empresas.Update(empresa);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(empresa);
        }

        [HttpGet]
        public async Task<IActionResult> Deletar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var result = await _context.Empresas.FirstOrDefaultAsync(x => x.Id == id);

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Deletar(int id)
        {
            var result = await _context.Empresas.FirstOrDefaultAsync(x => x.Id == id);
            _context.Empresas.Remove(result);
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
            var result = await _context.Empresas.FirstOrDefaultAsync(x => x.Id == id);

            return View(result);
        }
    }
}
