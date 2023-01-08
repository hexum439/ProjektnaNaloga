using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using SecondHand.Models;

namespace SecondHand.Data.Services
{
	public class KategorijeService : IKategorijeService
	{
		private readonly AppDbContext _context;
        private readonly UserManager<ApplicationUser> _usermanager;
        public KategorijeService(AppDbContext context, UserManager<ApplicationUser> usermanager)
		{
			_context = context;
            _usermanager = usermanager;
        }
		public IEnumerable<KategorijeOblacila> GetAll()
		{
			var result = _context.KategorijeOblacilas.Where(p => p.Spol.Equals('M')).ToList();
			return result;
		}

		public IEnumerable<Oblacila> GetByImeKategorije(int idd)
		{
			var data = _context.Oblacilas.Where(p => p.KategorijaId == idd).ToList();
			return data;
		}
	}
}
