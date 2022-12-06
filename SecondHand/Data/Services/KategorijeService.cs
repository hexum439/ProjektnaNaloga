using System.Collections.Generic;
using System.Linq;
using SecondHand.Models;

namespace SecondHand.Data.Services
{
	public class KategorijeService : IKategorijeService
	{
		private readonly AppDbContext _context;
		public KategorijeService(AppDbContext context)
		{
			_context = context;
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
