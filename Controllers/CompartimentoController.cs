using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BeachSys.Models;
using BeachSys.Models.ViewModels;

namespace BeachSys.Controllers
{
    public class CompartimentoController : Controller
    {
        private readonly BeachSysContext _context;

        private Usuario _user;
        public CompartimentoController(BeachSysContext context)
        {
            _context = context;
        }

        // GET: Compartimento
        [HttpPost]
        public async Task<IActionResult> Index(int idusuario, int? id)
        {

            Usuario usuario = await _context.Usuario.FindAsync(idusuario);
            if(usuario == null){
                return RedirectToAction(nameof(Index),"Home");
            }
            var beachSysContext = _context.Compartimento.Include(c => c.Armario).Include(c => c.Usuario);
            if (id == null) {
                UsuarioCompartimentoViewModel ucvm = new UsuarioCompartimentoViewModel{Usuario=usuario, Compartimentos= await beachSysContext.ToListAsync()};
                return View(ucvm);
            }
            else{
                List<Compartimento> compartimentos = new List<Compartimento>();
                foreach (Compartimento compartimento in await beachSysContext.ToListAsync()){
                    if(compartimento.ArmarioId == id){
                        compartimentos.Add(compartimento);
                    }
                }
                UsuarioCompartimentoViewModel ucvm = new UsuarioCompartimentoViewModel{Usuario=usuario, Compartimentos=compartimentos};
                return View(ucvm);
            }
        }

        // GET: Compartimento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compartimento = await _context.Compartimento
                .Include(c => c.Armario)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.CompartimentoId == id);
            if (compartimento == null)
            {
                return NotFound();
            }

            return View(compartimento);
        }

        // GET: Compartimento/Create
        public IActionResult Create()
        {
            ViewData["ArmarioId"] = new SelectList(_context.Armario, "ArmarioId", "Nome");
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "Nome");
            return View();
        }

        // POST: Compartimento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CompartimentoId,Numero,Tamanho,IsDisponivel,ArmarioId,UsuarioId")] Compartimento compartimento)
        {
            if (ModelState.IsValid)
            {
                compartimento.UsuarioId = null;
                _context.Add(compartimento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArmarioId"] = new SelectList(_context.Armario, "ArmarioId", "Nome", compartimento.ArmarioId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "Cpf", compartimento.UsuarioId);
            return View(compartimento);
        }

        // GET: Compartimento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compartimento = await _context.Compartimento.FindAsync(id);
            if (compartimento == null)
            {
                return NotFound();
            }
            ViewData["ArmarioId"] = new SelectList(_context.Armario, "ArmarioId", "Nome", compartimento.ArmarioId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "Cpf", compartimento.UsuarioId);
            return View(compartimento);
        }

        // POST: Compartimento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CompartimentoId,Numero,Tamanho,IsDisponivel,ArmarioId,UsuarioId")] Compartimento compartimento)
        {
            if (id != compartimento.CompartimentoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(compartimento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompartimentoExists(compartimento.CompartimentoId))
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
            ViewData["ArmarioId"] = new SelectList(_context.Armario, "ArmarioId", "Nome", compartimento.ArmarioId);
            ViewData["UsuarioId"] = new SelectList(_context.Usuario, "UsuarioId", "Cpf", compartimento.UsuarioId);
            return View(compartimento);
        }

        public async Task<IActionResult> Alugar(int idusuario, int id)
        {
            Usuario usuario = await _context.Usuario.FindAsync(idusuario);
            Compartimento compartimento = await _context.Compartimento.FindAsync(id);
            compartimento.UsuarioId = idusuario;
            compartimento.Usuario = usuario;
            _context.Update(compartimento);
            await _context.SaveChangesAsync();
            Dictionary<string, int> ids = new Dictionary<string, int>();
            ids.Add("id", id);
            return RedirectToAction(nameof(Details), "Compartimento", new{id=id});
        }
        // GET: Compartimento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var compartimento = await _context.Compartimento
                .Include(c => c.Armario)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.CompartimentoId == id);
            if (compartimento == null)
            {
                return NotFound();
            }

            return View(compartimento);
        }

        // POST: Compartimento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var compartimento = await _context.Compartimento.FindAsync(id);
            _context.Compartimento.Remove(compartimento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompartimentoExists(int id)
        {
            return _context.Compartimento.Any(e => e.CompartimentoId == id);
        }
    }
}
