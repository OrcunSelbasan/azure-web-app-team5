using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Employee.Data;
using Employee.Models;

namespace Employee.Controllers
{
    public class tblEmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public tblEmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: tblEmployees
        public async Task<IActionResult> Index()
        {
              return View(await _context.tblEmployee.ToListAsync());
        }

        // GET: tblEmployees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.tblEmployee == null)
            {
                return NotFound();
            }

            var tblEmployee = await _context.tblEmployee
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblEmployee == null)
            {
                return NotFound();
            }

            return View(tblEmployee);
        }

        // GET: tblEmployees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: tblEmployees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmpName,EmpSurname,EmpAddress,EmpPhone")] tblEmployee tblEmployee)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblEmployee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblEmployee);
        }

        // GET: tblEmployees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.tblEmployee == null)
            {
                return NotFound();
            }

            var tblEmployee = await _context.tblEmployee.FindAsync(id);
            if (tblEmployee == null)
            {
                return NotFound();
            }
            return View(tblEmployee);
        }

        // POST: tblEmployees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmpName,EmpSurname,EmpAddress,EmpPhone")] tblEmployee tblEmployee)
        {
            if (id != tblEmployee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblEmployee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tblEmployeeExists(tblEmployee.Id))
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
            return View(tblEmployee);
        }

        // GET: tblEmployees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.tblEmployee == null)
            {
                return NotFound();
            }

            var tblEmployee = await _context.tblEmployee
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tblEmployee == null)
            {
                return NotFound();
            }

            return View(tblEmployee);
        }

        // POST: tblEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.tblEmployee == null)
            {
                return Problem("Entity set 'ApplicationDbContext.tblEmployee'  is null.");
            }
            var tblEmployee = await _context.tblEmployee.FindAsync(id);
            if (tblEmployee != null)
            {
                _context.tblEmployee.Remove(tblEmployee);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tblEmployeeExists(int id)
        {
          return _context.tblEmployee.Any(e => e.Id == id);
        }
    }
}
