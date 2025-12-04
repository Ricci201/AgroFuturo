using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AgroFuturo.Data;
using AgroFuturo.Models;

namespace AgroFuturo.Controllers
{
    public class CategoriasInsumosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriasInsumosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CategoriasInsumos
        public async Task<IActionResult> Index()
        {
            return View(await _context.CategoriaInsumo.ToListAsync());
        }

        // GET: CategoriasInsumos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaInsumo = await _context.CategoriaInsumo
                .FirstOrDefaultAsync(m => m.CategoriaInsumoId == id);
            if (categoriaInsumo == null)
            {
                return NotFound();
            }

            return View(categoriaInsumo);
        }

        // GET: CategoriasInsumos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoriasInsumos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoriaInsumoId,Nome,Categoria,UnidadeMedida,Quantidade")] CategoriaInsumo categoriaInsumo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoriaInsumo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaInsumo);
        }

        // GET: CategoriasInsumos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaInsumo = await _context.CategoriaInsumo.FindAsync(id);
            if (categoriaInsumo == null)
            {
                return NotFound();
            }
            return View(categoriaInsumo);
        }

        // POST: CategoriasInsumos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoriaInsumoId,Nome,Categoria,UnidadeMedida,Quantidade")] CategoriaInsumo categoriaInsumo)
        {
            if (id != categoriaInsumo.CategoriaInsumoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoriaInsumo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoriaInsumoExists(categoriaInsumo.CategoriaInsumoId))
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
            return View(categoriaInsumo);
        }

        // GET: CategoriasInsumos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoriaInsumo = await _context.CategoriaInsumo
                .FirstOrDefaultAsync(m => m.CategoriaInsumoId == id);
            if (categoriaInsumo == null)
            {
                return NotFound();
            }

            return View(categoriaInsumo);
        }

        // POST: CategoriasInsumos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoriaInsumo = await _context.CategoriaInsumo.FindAsync(id);
            if (categoriaInsumo != null)
            {
                _context.CategoriaInsumo.Remove(categoriaInsumo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoriaInsumoExists(int id)
        {
            return _context.CategoriaInsumo.Any(e => e.CategoriaInsumoId == id);
        }
    }
}
