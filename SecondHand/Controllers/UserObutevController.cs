using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SecondHand.Data;
using SecondHand.Models;

namespace SecondHand.Controllers
{
    [Authorize]
    public class UserObutevController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _usermanager;
        public UserObutevController(AppDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _usermanager = userManager;
        }

        // GET: UserObutev
        public async Task<IActionResult> Index()
        {
            var currentUser = await _usermanager.GetUserAsync(User);
            string id = currentUser.Id;

            var appDbContext = (_context.Obutevs.Where(o => o.owner.Id == id));
            var kategorije = _context.KategorijeCevljis;
            var podatki = from s in kategorije
                          join st in appDbContext on s.ID equals st.KategorijaId
                          select new skupnimodelcevlji { podatkiobutev = st, podatkikategorijecevlji = s };
            return View(await podatki.ToListAsync());
        }

        // GET: UserObutev/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obutev = await _context.Obutevs
                .Include(o => o.Kategorija)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (obutev == null)
            {
                return NotFound();
            }

            return View(obutev);
        }

        // GET: UserObutev/Create
        public IActionResult Create()
        {
            ViewData["KategorijaId"] = new SelectList(_context.KategorijeCevljis, "ID", "ImeKategorije");
            return View();
        }

        // POST: UserObutev/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ImeCevlja,SlikaCevljaUrl,StCevlja,opis,znamka,cena,KategorijaId")] Obutev obutev)
        {
            var currentUser = await _usermanager.GetUserAsync(User);

            if (ModelState.IsValid)
            {
                obutev.DateCreated = DateTime.Now;
                obutev.owner = currentUser;

                _context.Add(obutev);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KategorijaId"] = new SelectList(_context.KategorijeCevljis, "ID", "ID", obutev.KategorijaId);
            return View(obutev);
        }

        // GET: UserObutev/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var obutev = await _context.Obutevs.FindAsync(id);
            if (obutev == null)
            {
                return NotFound();
            }
            
            ViewData["KategorijaId"] = new SelectList(_context.KategorijeCevljis, "ID", "ImeKategorije", obutev.KategorijaId);
            return View(obutev);
        }

        // POST: UserObutev/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ImeCevlja,SlikaCevljaUrl,StCevlja,opis,znamka,cena,KategorijaId")] Obutev obutev)
        {
            if (id != obutev.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                obutev.DateCreated = DateTime.Now;
                try
                {
                    _context.Update(obutev);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObutevExists(obutev.Id))
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
            ViewData["KategorijaId"] = new SelectList(_context.KategorijeCevljis, "ID", "ID", obutev.KategorijaId);
            return View(obutev);
        }

        // GET: UserObutev/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obutev = await _context.Obutevs
                .Include(o => o.Kategorija)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (obutev == null)
            {
                return NotFound();
            }

            return View(obutev);
        }

        // POST: UserObutev/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var obutev = await _context.Obutevs.FindAsync(id);
            _context.Obutevs.Remove(obutev);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObutevExists(int id)
        {
            return _context.Obutevs.Any(e => e.Id == id);
        }
    }
}
