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
    public class CopasController : Controller
    {
        private readonly ProjetoRumo_v2Context _context;

        public CopasController(ProjetoRumo_v2Context context)
        {
            _context = context;
        }

        // GET: Copas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Copa.ToListAsync());
        }

        // GET: Copas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var copa = await _context.Copa
                .FirstOrDefaultAsync(m => m.CopaId == id);
            if (copa == null)
            {
                return NotFound();
            }

            return View(copa);
        }

        // GET: Copas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Copas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CopaId,Bebida,Quantidade")] Copa copa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(copa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(copa);
        }

        // GET: Copas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var copa = await _context.Copa.FindAsync(id);
            if (copa == null)
            {
                return NotFound();
            }
            return View(copa);
        }

        // POST: Copas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CopaId,Bebida,Quantidade")] Copa copa)
        {
            if (id != copa.CopaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(copa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CopaExists(copa.CopaId))
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
            return View(copa);
        }

        // GET: Copas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var copa = await _context.Copa
                .FirstOrDefaultAsync(m => m.CopaId == id);
            if (copa == null)
            {
                return NotFound();
            }

            return View(copa);
        }

        // POST: Copas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var copa = await _context.Copa.FindAsync(id);
            _context.Copa.Remove(copa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CopaExists(int id)
        {
            return _context.Copa.Any(e => e.CopaId == id);
        }
    }
}
