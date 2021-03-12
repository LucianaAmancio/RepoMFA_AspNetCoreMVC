using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreMvc.Context;
using AspNetCoreMvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreMvc.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminLanchesController : Controller
    {
        private readonly AppDbContext _context;

        public AdminLanchesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Admin/AdminLanches
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Comidas.Include(l => l.Categoria);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Admin/AdminComidas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comida = await _context.Comidas
                .Include(l => l.Categoria)
                .SingleOrDefaultAsync(m => m.ComidaId == id);
            if (comida == null)
            {
                return NotFound();
            }

            return View(comida);
        }

        // GET: Admin/AdminComidas/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome");
            return View();
        }

        // POST: Admin/AdminLanches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ComidaId,Nome,DescricaoCurta,DescricaoDetalhada,Preco,ImagemUrl,ImagemThumbnailUrl,IsComidaPreferida,EmEstoque,CategoriaId")] Comida comida)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comida);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome", comida.CategoriaId);
            return View(comida);
        }

        // GET: Admin/AdminComidas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comida = await _context.Comidas.SingleOrDefaultAsync(m => m.ComidaId == id);
            if (comida == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome", comida.CategoriaId);
            return View(comida);
        }

        // POST: Admin/AdminComidas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ComidaId,Nome,DescricaoCurta,DescricaoDetalhada,Preco,ImagemUrl,ImagemThumbnailUrl,IsComidaPreferida,EmEstoque,CategoriaId")] Comida comida)
        {
            if (id != comida.ComidaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comida);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComidaExists(comida.ComidaId))
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
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "CategoriaNome", comida.CategoriaId);
            return View(comida);
        }

        // GET: Admin/AdminComidas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comida = await _context.Comidas
                .Include(l => l.Categoria)
                .SingleOrDefaultAsync(m => m.ComidaId == id);
            if (comida == null)
            {
                return NotFound();
            }

            return View(comida);
        }

        // POST: Admin/AdminComidas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comida = await _context.Comidas.SingleOrDefaultAsync(m => m.ComidaId == id);
            _context.Comidas.Remove(comida);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ComidaExists(int id)
        {
            return _context.Comidas.Any(e => e.ComidaId == id);
        }
    }
}
