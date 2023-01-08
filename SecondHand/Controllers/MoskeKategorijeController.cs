using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SecondHand.Data;
using SecondHand.Data.Services;
using SecondHand.Models;

namespace SecondHand.Controllers
{
    public class MoskeKategorijeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _usermanager;

        public MoskeKategorijeController(AppDbContext context, UserManager<ApplicationUser> usermanager)
		{
			_context = context;
            _usermanager = usermanager;
        }
		public IActionResult Index()
        {

            var data = _context.KategorijeOblacilas.Where(p => p.Spol.Equals('M')).ToList();
            return View(data);
        }
        public async Task<IActionResult> Details(int id) {
            var uporabnik = _usermanager.Users;
            var oblacila = _context.Oblacilas.Where(p => p.KategorijaId == id);
            if (oblacila == null)  return View("Empty");
            var podatki = from s in oblacila
                          let st = uporabnik.Where(u => u.Id == s.owner.Id).SingleOrDefault()
                          select new moskioblacilaskupnimodel
                          {
                              uporabnikpodatki = st,
                              oblacilapodatki = s
                          };
            return View(podatki);
        }
        public async Task<IActionResult> DetailsProdukta(int id)
        {
           
            var oblacila = _context.Oblacilas.Where(p => p.Id == id);
            var uporabnik = _usermanager.Users;
            if (oblacila == null) return View("Empty");
            var podatki = from s in oblacila
                          let st = uporabnik.Where(u => u.Id == s.owner.Id).SingleOrDefault()
                          select new moskioblacilaskupnimodel
                          {
                              uporabnikpodatki = st,
                              oblacilapodatki = s
                          };
            return View(podatki);
        }
    }
}
