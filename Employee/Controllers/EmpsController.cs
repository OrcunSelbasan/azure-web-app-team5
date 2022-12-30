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
    public class EmpsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmpsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Emps
        public async Task<IActionResult> Index()
        {
              return View(await _context.Emp.ToListAsync());
        }

        // GET: Emps/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Emp == null)
            {
                return NotFound();
            }

            var emp = await _context.Emp
                .FirstOrDefaultAsync(m => m.EmpPhone == id);
            if (emp == null)
            {
                return NotFound();
            }

            return View(emp);
        }

        // GET: Emps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Emps/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpName,EmpSurname,EmpAddress,EmpPhone")] Emp emp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emp);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(emp);
        }

        // GET: Emps/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Emp == null)
            {
                return NotFound();
            }

            var emp = await _context.Emp.FindAsync(id);
            if (emp == null)
            {
                return NotFound();
            }
            return View(emp);
        }

        // POST: Emps/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("EmpName,EmpSurname,EmpAddress,EmpPhone")] Emp emp)
        {
            if (id != emp.EmpPhone)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emp);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpExists(emp.EmpPhone))
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
            return View(emp);
        }

        // GET: Emps/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Emp == null)
            {
                return NotFound();
            }

            var emp = await _context.Emp
                .FirstOrDefaultAsync(m => m.EmpPhone == id);
            if (emp == null)
            {
                return NotFound();
            }

            return View(emp);
        }

        // POST: Emps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Emp == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Emp'  is null.");
            }
            var emp = await _context.Emp.FindAsync(id);
            if (emp != null)
            {
                _context.Emp.Remove(emp);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpExists(string id)
        {
          return _context.Emp.Any(e => e.EmpPhone == id);
        }
    }
}
