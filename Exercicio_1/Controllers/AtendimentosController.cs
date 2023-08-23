using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Exercicio_1.Data;
using Exercicio_1.Models;

namespace Exercicio_1.Controllers
{
    public class AtendimentosController : Controller
    {
        private readonly Context _context;

        public AtendimentosController(Context context)
        {
            _context = context;
        }

        // GET: Atendimentos
        public async Task<IActionResult> Index()
        {
            var context = _context.Atendimento.Include(a => a.aluno).Include(a => a.sala);
            return View(await context.ToListAsync());
        }

        // GET: Atendimentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Atendimento == null)
            {
                return NotFound();
            }

            var atendimento = await _context.Atendimento
                .Include(a => a.aluno)
                .Include(a => a.sala)
                .FirstOrDefaultAsync(m => m.id == id);
            if (atendimento == null)
            {
                return NotFound();
            }

            return View(atendimento);
        }

        // GET: Atendimentos/Create
        public IActionResult Create()
        {
            ViewData["alunoID"] = new SelectList(_context.Aluno, "id", "nome");
            ViewData["salaID"] = new SelectList(_context.Sala, "id", "descricao");
            return View();
        }

        // POST: Atendimentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,alunoID,salaID,data,hora")] Atendimento atendimento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(atendimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["alunoID"] = new SelectList(_context.Aluno, "id", "nome", atendimento.alunoID);
            ViewData["salaID"] = new SelectList(_context.Sala, "id", "descricao", atendimento.salaID);
            return View(atendimento);
        }

        // GET: Atendimentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Atendimento == null)
            {
                return NotFound();
            }

            var atendimento = await _context.Atendimento.FindAsync(id);
            if (atendimento == null)
            {
                return NotFound();
            }
            ViewData["alunoID"] = new SelectList(_context.Aluno, "id", "nome", atendimento.alunoID);
            ViewData["salaID"] = new SelectList(_context.Sala, "id", "descricao", atendimento.salaID);
            return View(atendimento);
        }

        // POST: Atendimentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,alunoID,salaID,data,hora")] Atendimento atendimento)
        {
            if (id != atendimento.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(atendimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AtendimentoExists(atendimento.id))
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
            ViewData["alunoID"] = new SelectList(_context.Aluno, "id", "nome", atendimento.alunoID);
            ViewData["salaID"] = new SelectList(_context.Sala, "id", "descricao", atendimento.salaID);
            return View(atendimento);
        }

        // GET: Atendimentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Atendimento == null)
            {
                return NotFound();
            }

            var atendimento = await _context.Atendimento
                .Include(a => a.aluno)
                .Include(a => a.sala)
                .FirstOrDefaultAsync(m => m.id == id);
            if (atendimento == null)
            {
                return NotFound();
            }

            return View(atendimento);
        }

        // POST: Atendimentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Atendimento == null)
            {
                return Problem("Entity set 'Context.Atendimento'  is null.");
            }
            var atendimento = await _context.Atendimento.FindAsync(id);
            if (atendimento != null)
            {
                _context.Atendimento.Remove(atendimento);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AtendimentoExists(int id)
        {
          return (_context.Atendimento?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
