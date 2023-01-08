using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SecondHand.Data;
using SecondHand.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using SecondHand.Data.Services;

namespace SecondHand.Controllers
{
    public class UserObController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _usermanager;

        public UserObController(AppDbContext context, UserManager<ApplicationUser> usermanager)
        {
            _context = context;
            _usermanager = usermanager;
        }

        // GET: UserOb
        [Authorize]
        public async Task<IActionResult> Index()
        {
            
            var currentUser = await _usermanager.GetUserAsync(User);
            string id = currentUser.Id;
            
            var appDbContext = (_context.Oblacilas.Where(o => o.owner.Id == id));
            var kategorije = _context.KategorijeOblacilas;
            var podatki = from s in kategorije
                          join st in appDbContext on s.ID equals st.KategorijaId
                          select new skupnimodel { oblacilapodatki = st, kategorijapodatki = s };
            return View(await podatki.ToListAsync());
        }

        // GET: UserOb/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oblacila = await _context.Oblacilas
                .Include(o => o.Kategorija)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oblacila == null)
            {
                return NotFound();
            }

            return View(oblacila);
        }

        // GET: UserOb/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["KategorijaId"] = new SelectList(_context.Set<KategorijeOblacila>(), "ID", "ImeKategorije");
            return View();
        }

        // POST: UserOb/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ImeOblacila,SlikaOblekeUrl,opis,owner,cena,KategorijaId")] Oblacila oblacila)
        {
            var currentUser = await _usermanager.GetUserAsync(User);

            if (ModelState.IsValid)
            {
			    oblacila.DateCreated = DateTime.Now;
				oblacila.owner = currentUser;
                _context.Add(oblacila);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KategorijaId"] = new SelectList(_context.Set<KategorijeOblacila>(), "ID", "ID", oblacila.KategorijaId);
            return View(oblacila);
        }

        // GET: UserOb/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oblacila = await _context.Oblacilas.FindAsync(id);
            if (oblacila == null)
            {
                return NotFound();
            }
            ViewData["KategorijaId"] = new SelectList(_context.Set<KategorijeOblacila>(), "ID", "ImeKategorije", oblacila.KategorijaId);
            return View(oblacila);
        }

        // POST: UserOb/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ImeOblacila,SlikaOblekeUrl,opis,cena,KategorijaId")] Oblacila oblacila)
        {
            if (id != oblacila.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
				oblacila.DateCreated = DateTime.Now;
				try
                {
                    _context.Update(oblacila);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OblacilaExists(oblacila.Id))
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
            ViewData["KategorijaId"] = new SelectList(_context.Set<KategorijeOblacila>(), "ID", "ID", oblacila.KategorijaId);
            return View(oblacila);
        }

        // GET: UserOb/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var oblacila = await _context.Oblacilas
                .Include(o => o.Kategorija)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (oblacila == null)
            {
                return NotFound();
            }

            return View(oblacila);
        }

        // POST: UserOb/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var oblacila = await _context.Oblacilas.FindAsync(id);
            _context.Oblacilas.Remove(oblacila);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OblacilaExists(int id)
        {
            return _context.Oblacilas.Any(e => e.Id == id);
        }
    }
}
