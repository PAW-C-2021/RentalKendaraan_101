using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RentalKendaraan_101.Models;

namespace RentalKendaraan_101.Controllers
{
    public class CustumersController : Controller
    {
        private readonly RentKendaraanContext _context;

        public CustumersController(RentKendaraanContext context)
        {
            _context = context;
        }

        // GET: Custumers
        public async Task<IActionResult> Index(string ktsd, string searchString, string sortOrder, string currentFilter, int? pageNumber)
        {
            var ktsdList = new List<string>();
            var ktsdQuery = from d in _context.Custumers orderby d.NamaCutumer select d.NamaCutumer;

            ktsdList.AddRange(ktsdQuery.Distinct());
            ViewBag.ktsd = new SelectList(ktsdList);

            var menu = from m in _context.Custumers.Include(k => k.IdGenderNavigation) select m;

            if (!string.IsNullOrEmpty(ktsd))
            {
                menu = menu.Where(x => x.NamaCutumer == ktsd);
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                menu = menu.Where(s => s.NamaCutumer.Contains(searchString) || s.Nik.Contains(searchString) || s.Alamat.Contains(searchString) ||
                s.NoHp.Contains(searchString) || s.IdGenderNavigation.NamaGender.Contains(searchString));
            }
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "name_decs" : "";

            switch (sortOrder)
            {
                case "name_decs":
                    menu = menu.OrderByDescending(s => s.NamaCutumer);
                    break;
                default:
                    menu = menu.OrderBy(s => s.NamaCutumer);
                    break;
            }
            //membuat pagedList
            ViewData["CurrentSort"] = sortOrder;
            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewData["CurrentFilter"] = searchString;

            //definisi jumlah data pada halaman
            int pageSize = 5;

            return View(await PaginatedList<Custumer>.CreateAsync(menu.AsNoTracking(), pageNumber ?? 1, pageSize));
            //return View(await menu.ToListAsync());
        }
        // GET: Custumers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var custumer = await _context.Custumers
                .Include(c => c.IdGenderNavigation)
                .FirstOrDefaultAsync(m => m.IdCustumer == id);
            if (custumer == null)
            {
                return NotFound();
            }

            return View(custumer);
        }

        // GET: Custumers/Create
        public IActionResult Create()
        {
            ViewData["IdGender"] = new SelectList(_context.Genders, "IdGender", "IdGender");
            return View();
        }

        // POST: Custumers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCustumer,NamaCutumer,Nik,Alamat,NoHp,IdGender")] Custumer custumer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(custumer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdGender"] = new SelectList(_context.Genders, "IdGender", "IdGender", custumer.IdGender);
            return View(custumer);
        }

        // GET: Custumers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var custumer = await _context.Custumers.FindAsync(id);
            if (custumer == null)
            {
                return NotFound();
            }
            ViewData["IdGender"] = new SelectList(_context.Genders, "IdGender", "IdGender", custumer.IdGender);
            return View(custumer);
        }

        // POST: Custumers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCustumer,NamaCutumer,Nik,Alamat,NoHp,IdGender")] Custumer custumer)
        {
            if (id != custumer.IdCustumer)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(custumer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustumerExists(custumer.IdCustumer))
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
            ViewData["IdGender"] = new SelectList(_context.Genders, "IdGender", "IdGender", custumer.IdGender);
            return View(custumer);
        }

        // GET: Custumers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var custumer = await _context.Custumers
                .Include(c => c.IdGenderNavigation)
                .FirstOrDefaultAsync(m => m.IdCustumer == id);
            if (custumer == null)
            {
                return NotFound();
            }

            return View(custumer);
        }

        // POST: Custumers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var custumer = await _context.Custumers.FindAsync(id);
            _context.Custumers.Remove(custumer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustumerExists(int id)
        {
            return _context.Custumers.Any(e => e.IdCustumer == id);
        }
    }
}
