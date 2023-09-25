using Academico.Data;
using Academico.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Academico.Controllers
{
    public class PassageiroController : Controller
    {
        private readonly AcademicoContext _context;

        public PassageiroController(AcademicoContext context)
        {
            _context = context;
        }

        // GET: PassageiroController
        public async Task<IActionResult> Index()
        {
            var academicoContext = _context.Passageiros.Include(d => d.Instituicao);
            return View(await academicoContext.ToListAsync());
        }

        // GET: PassageiroController/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Passageiros == null)
            {
                return NotFound();
            }

            var passageiro = await _context.Passageiros
                .Include(d => d.Instituicao)
                .FirstOrDefaultAsync(m => m.PassageiroID == id);
            if (passageiro == null)
            {
                return NotFound();
            }

            return View(passageiro);
        }

        // GET: PassageiroController/Create
        public IActionResult Create()
        {
            ViewData["InstituicaoID"] = new SelectList(_context.Instituicoes, "InstituicaoID", "InstituicaoID");
            return View();
        }

        // POST: PassageiroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PassageiroID,Nome,InstituicaoID")] Passageiro passageiro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(passageiro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InstituicaoID"] = new SelectList(_context.Instituicoes, "InstituicaoID", "InstituicaoID", passageiro.InstituicaoID);
            return View(passageiro);
        }

        // GET: PassageiroController/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Passageiros == null)
            {
                return NotFound();
            }

            var passageiro = await _context.Passageiros.FindAsync(id);
            if (passageiro == null)
            {
                return NotFound();
            }
            ViewData["InstituicaoID"] = new SelectList(_context.Instituicoes, "InstituicaoID", "InstituicaoID", passageiro.InstituicaoID);
            return View(passageiro);
        }

        // POST: PassageiroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("PassageiroID,Nome,InstituicaoID")] Passageiro passageiro)
        {
            if (id != passageiro.PassageiroID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(passageiro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PassageiroExists(passageiro.PassageiroID))
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
            ViewData["InstituicaoID"] = new SelectList(_context.Instituicoes, "InstituicaoID", "InstituicaoID", passageiro.InstituicaoID);
            return View(passageiro);
        }

        // GET: PassageiroController/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Passageiros == null)
            {
                return NotFound();
            }

            var passageiro = await _context.Passageiros
                .Include(d => d.Instituicao)
                .FirstOrDefaultAsync(m => m.PassageiroID == id);
            if (passageiro == null)
            {
                return NotFound();
            }

            return View(passageiro);
        }

        // POST: PassageiroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            if (_context.Passageiros == null)
            {
                return Problem("Entity set 'AcademicoContext.Passageiros'  is null.");
            }
            var passageiro = await _context.Passageiros.FindAsync(id);
            if (passageiro != null)
            {
                _context.Passageiros.Remove(passageiro);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool PassageiroExists(long? id)
        {
            return (_context.Passageiros?.Any(e => e.PassageiroID == id)).GetValueOrDefault();
        }
    }
}
