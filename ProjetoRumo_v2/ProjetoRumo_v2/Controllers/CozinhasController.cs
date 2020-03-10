using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoRumo_v2.Data;
using ProjetoRumo_v2.Models;

namespace ProjetoRumo_v2.Controllers
{
    public class CozinhasController : Controller
    {
        private readonly ProjetoRumo_v2Context _context;

        public CozinhasController(ProjetoRumo_v2Context context)
        {
            _context = context;
        }

        // GET: Cozinhas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cozinha.ToListAsync());
        }

        // GET: Cozinhas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cozinha = await _context.Cozinha
                .FirstOrDefaultAsync(m => m.CozinhaId == id);
            if (cozinha == null)
            {
                return NotFound();
            }

            return View(cozinha);
        }

        // GET: Cozinhas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cozinhas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CozinhaId,Prato,Quantidade")] Cozinha cozinha)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cozinha);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cozinha);
        }

        // GET: Cozinhas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cozinha = await _context.Cozinha.FindAsync(id);
            if (cozinha == null)
            {
                return NotFound();
            }
            return View(cozinha);
        }

        // POST: Cozinhas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CozinhaId,Prato,Quantidade")] Cozinha cozinha)
        {
            if (id != cozinha.CozinhaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cozinha);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CozinhaExists(cozinha.CozinhaId))
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
            return View(cozinha);
        }

        // GET: Cozinhas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cozinha = await _context.Cozinha
                .FirstOrDefaultAsync(m => m.CozinhaId == id);
            if (cozinha == null)
            {
                return NotFound();
            }

            return View(cozinha);
        }

        // POST: Cozinhas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cozinha = await _context.Cozinha.FindAsync(id);
            _context.Cozinha.Remove(cozinha);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CozinhaExists(int id)
        {
            return _context.Cozinha.Any(e => e.CozinhaId == id);
        }
    }
}
