using SecondHand.Models;
using System.Collections.Generic;
using System.Linq;

namespace SecondHand.Data.Services
{
	public class KategorijeObutevService : IKategorijeObutevService
	{
		private readonly AppDbContext _context;
		public KategorijeObutevService(AppDbContext context)
		{
			_context = context;
		}
		public IEnumerable<KategorijeCevlji> GetAll()
		{
			var result = _context.KategorijeCevljis.Where(p => p.Spol.Equals('M')).ToList();
			return result;
		}

		public IEnumerable<Obutev> GetByImeKategorije(int idd)
		{
			var data = _context.Obutevs.Where(p => p.KategorijaId == idd).ToList();
			return data;
		}
	}
}
