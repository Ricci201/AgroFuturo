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
    public class ConsumoInsumosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConsumoInsumosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ConsumoInsumos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ConsumoInsumo.Include(c => c.CategoriaInsumo).Include(c => c.Equipamento).Include(c => c.Fazenda);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ConsumoInsumos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumoInsumo = await _context.ConsumoInsumo
                .Include(c => c.CategoriaInsumo)
                .Include(c => c.Equipamento)
                .Include(c => c.Fazenda)
                .FirstOrDefaultAsync(m => m.ConsumoInsumoId == id);
            if (consumoInsumo == null)
            {
                return NotFound();
            }

            return View(consumoInsumo);
        }

        // GET: ConsumoInsumos/Create
        public IActionResult Create()
        {
            ViewData["CategoriaInsumoId"] = new SelectList(_context.CategoriaInsumo, "CategoriaInsumoId", "CategoriaInsumoId");
            ViewData["EquipamentoId"] = new SelectList(_context.Equipamento, "EquipamentoId", "EquipamentoId");
            ViewData["FazendaId"] = new SelectList(_context.Fazenda, "FazendaId", "FazendaId");
            return View();
        }

        // POST: ConsumoInsumos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ConsumoInsumoId,QuantidadeConsumida,SafraInicio,SafraFim,CustoTotal,EquipamentoId,CategoriaInsumoId,FazendaId")] ConsumoInsumo consumoInsumo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consumoInsumo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaInsumoId"] = new SelectList(_context.CategoriaInsumo, "CategoriaInsumoId", "CategoriaInsumoId", consumoInsumo.CategoriaInsumoId);
            ViewData["EquipamentoId"] = new SelectList(_context.Equipamento, "EquipamentoId", "EquipamentoId", consumoInsumo.EquipamentoId);
            ViewData["FazendaId"] = new SelectList(_context.Fazenda, "FazendaId", "FazendaId", consumoInsumo.FazendaId);
            return View(consumoInsumo);
        }

        // GET: ConsumoInsumos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumoInsumo = await _context.ConsumoInsumo.FindAsync(id);
            if (consumoInsumo == null)
            {
                return NotFound();
            }
            ViewData["CategoriaInsumoId"] = new SelectList(_context.CategoriaInsumo, "CategoriaInsumoId", "CategoriaInsumoId", consumoInsumo.CategoriaInsumoId);
            ViewData["EquipamentoId"] = new SelectList(_context.Equipamento, "EquipamentoId", "EquipamentoId", consumoInsumo.EquipamentoId);
            ViewData["FazendaId"] = new SelectList(_context.Fazenda, "FazendaId", "FazendaId", consumoInsumo.FazendaId);
            return View(consumoInsumo);
        }

        // POST: ConsumoInsumos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ConsumoInsumoId,QuantidadeConsumida,SafraInicio,SafraFim,CustoTotal,EquipamentoId,CategoriaInsumoId,FazendaId")] ConsumoInsumo consumoInsumo)
        {
            if (id != consumoInsumo.ConsumoInsumoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consumoInsumo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsumoInsumoExists(consumoInsumo.ConsumoInsumoId))
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
            ViewData["CategoriaInsumoId"] = new SelectList(_context.CategoriaInsumo, "CategoriaInsumoId", "CategoriaInsumoId", consumoInsumo.CategoriaInsumoId);
            ViewData["EquipamentoId"] = new SelectList(_context.Equipamento, "EquipamentoId", "EquipamentoId", consumoInsumo.EquipamentoId);
            ViewData["FazendaId"] = new SelectList(_context.Fazenda, "FazendaId", "FazendaId", consumoInsumo.FazendaId);
            return View(consumoInsumo);
        }

        // GET: ConsumoInsumos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consumoInsumo = await _context.ConsumoInsumo
                .Include(c => c.CategoriaInsumo)
                .Include(c => c.Equipamento)
                .Include(c => c.Fazenda)
                .FirstOrDefaultAsync(m => m.ConsumoInsumoId == id);
            if (consumoInsumo == null)
            {
                return NotFound();
            }

            return View(consumoInsumo);
        }

        // POST: ConsumoInsumos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consumoInsumo = await _context.ConsumoInsumo.FindAsync(id);
            if (consumoInsumo != null)
            {
                _context.ConsumoInsumo.Remove(consumoInsumo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ConsumoInsumoExists(int id)
        {
            return _context.ConsumoInsumo.Any(e => e.ConsumoInsumoId == id);
        }
    }
}
