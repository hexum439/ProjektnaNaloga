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
	public class ZenskaObutevController : Controller
	{
		private readonly AppDbContext _context;
		private readonly UserManager<ApplicationUser> _usermanager;

		public ZenskaObutevController(AppDbContext context, UserManager<ApplicationUser> usermanager)
		{
			_context = context;
			_usermanager = usermanager;
		}
		public IActionResult Index()
		{

			var data = _context.KategorijeCevljis.Where(p => p.Spol.Equals('Ž')).ToList();
			return View(data);
		}
		public async Task<IActionResult> Details(int id)
		{
			var uporabnik = _usermanager.Users;
			var obutve = _context.Obutevs.Where(p => p.KategorijaId == id);
			if (obutve == null) return View("Empty");
			var podatki = from s in obutve
						  let st = uporabnik.Where(u => u.Id == s.owner.Id).SingleOrDefault()
						  select new moskiobutveskupnimodel
						  {
							  uporabnikpodatki = st,
							  obutvepodatki = s
						  };
			return View(podatki);
		}
		public async Task<IActionResult> DetailsProdukta(int id)
		{

			var obutve = _context.Obutevs.Where(p => p.Id == id);
			var uporabnik = _usermanager.Users;
			if (obutve == null) return View("Empty");
			var podatki = from s in obutve
						  let st = uporabnik.Where(u => u.Id == s.owner.Id).SingleOrDefault()
						  select new moskiobutveskupnimodel
						  {
							  uporabnikpodatki = st,
							  obutvepodatki = s
						  };
			return View(podatki);
		}
	}
}
