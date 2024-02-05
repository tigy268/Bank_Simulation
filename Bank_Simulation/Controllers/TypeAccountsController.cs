using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bank_Simulation.Data;
using Bank_Simulation.Models;

namespace Bank_Simulation.Controllers
{
    public class TypeAccountsController : Controller
    {
        private readonly Bank_SimulationContext _context;

        public TypeAccountsController(Bank_SimulationContext context)
        {
            _context = context;
        }

        // GET: TypeAccounts
        public async Task<IActionResult> Index()
        {
            return View(await _context.AccountsTypes.ToListAsync());
        }

        // GET: TypeAccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeAccount = await _context.AccountsTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeAccount == null)
            {
                return NotFound();
            }

            return View(typeAccount);
        }

        // GET: TypeAccounts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TypeAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Id")] TypeAccount typeAccount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typeAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typeAccount);
        }

        // GET: TypeAccounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeAccount = await _context.AccountsTypes.FindAsync(id);
            if (typeAccount == null)
            {
                return NotFound();
            }
            return View(typeAccount);
        }

        // POST: TypeAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Id")] TypeAccount typeAccount)
        {
            if (id != typeAccount.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typeAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypeAccountExists(typeAccount.Id))
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
            return View(typeAccount);
        }

        // GET: TypeAccounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typeAccount = await _context.AccountsTypes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (typeAccount == null)
            {
                return NotFound();
            }

            return View(typeAccount);
        }

        // POST: TypeAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typeAccount = await _context.AccountsTypes.FindAsync(id);
            if (typeAccount != null)
            {
                _context.AccountsTypes.Remove(typeAccount);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypeAccountExists(int id)
        {
            return _context.AccountsTypes.Any(e => e.Id == id);
        }
    }
}
