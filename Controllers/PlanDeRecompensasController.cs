using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CisnerosM_ExamenP1.Controllers
{
    public class PlanDeRecompensasController : Controller
    {
        private readonly HotelContext _context;

        public PlanDeRecompensasController(HotelContext context)
        {
            _context = context;
        }

        // GET: PlanDeRecompensas
        public async Task<IActionResult> Index()
        {
            return View(await _context.PlanesDeRecompensas.ToListAsync());
        }

        // GET: PlanDeRecompensas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planDeRecompensasModel = await _context.PlanesDeRecompensas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (planDeRecompensasModel == null)
            {
                return NotFound();
            }

            return View(planDeRecompensasModel);
        }

        // GET: PlanDeRecompensas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PlanDeRecompensas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,FechaInicio,PuntosAcumulados")] PlanDeRecompensasModel planDeRecompensasModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(planDeRecompensasModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(planDeRecompensasModel);
        }

        // GET: PlanDeRecompensas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planDeRecompensasModel = await _context.PlanesDeRecompensas.FindAsync(id);
            if (planDeRecompensasModel == null)
            {
                return NotFound();
            }
            return View(planDeRecompensasModel);
        }

        // POST: PlanDeRecompensas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,FechaInicio,PuntosAcumulados")] PlanDeRecompensasModel planDeRecompensasModel)
        {
            if (id != planDeRecompensasModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(planDeRecompensasModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PlanDeRecompensasModelExists(planDeRecompensasModel.Id))
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
            return View(planDeRecompensasModel);
        }

        // GET: PlanDeRecompensas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var planDeRecompensasModel = await _context.PlanesDeRecompensas
                .FirstOrDefaultAsync(m => m.Id == id);
            if (planDeRecompensasModel == null)
            {
                return NotFound();
            }

            return View(planDeRecompensasModel);
        }

        // POST: PlanDeRecompensas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var planDeRecompensasModel = await _context.PlanesDeRecompensas.FindAsync(id);
            if (planDeRecompensasModel != null)
            {
                _context.PlanesDeRecompensas.Remove(planDeRecompensasModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PlanDeRecompensasModelExists(int id)
        {
            return _context.PlanesDeRecompensas.Any(e => e.Id == id);
        }
    }
}
