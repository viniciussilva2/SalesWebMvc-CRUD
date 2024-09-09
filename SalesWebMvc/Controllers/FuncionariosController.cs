using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc.Data;
using SalesWebMvc.Models;

namespace SalesWebMvc.Controllers
{
    public class FuncionariosController : Controller
    {
        private readonly SalesWebMvcContext _context;

        public FuncionariosController(SalesWebMvcContext context)
        {
            _context = context;
        }

        // GET: Funcionarios
        public async Task<IActionResult> Index(string searchString)
        {
            // Define o valor da pesquisa no ViewData
            ViewData["CurrentFilter"] = searchString;

            // Obtém todos os funcionários
            var funcionarios = from f in _context.Funcionarios
                               select f;

            // Se searchString não for nulo ou vazio, filtra os funcionários
            if (!string.IsNullOrEmpty(searchString))
            {
                funcionarios = funcionarios.Where(f => f.Name.Contains(searchString));
            }

            var funcionarioList = await funcionarios.ToListAsync();

            // Define uma mensagem de erro se nenhum funcionário for encontrado
            if (!funcionarioList.Any() && !string.IsNullOrEmpty(searchString))
            {
                ViewData["ErrorMessage"] = "Funcionário inexistente";
            }

            return View(funcionarioList);
        }

        // GET: Funcionarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Funcionarios/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Salary,DateContract")] Funcionarios funcionarios)
        {
            if (ModelState.IsValid)
            {
                _context.Add(funcionarios);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(funcionarios);
        }

        // GET: Funcionarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionarios
                .FirstOrDefaultAsync(m => m.Id == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // POST: Funcionarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var funcionario = await _context.Funcionarios.FindAsync(id);
            if (funcionario != null)
            {
                _context.Funcionarios.Remove(funcionario);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool FuncionarioExists(int id)
        {
            return _context.Funcionarios.Any(e => e.Id == id);
        }

    }
}
