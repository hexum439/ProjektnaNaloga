using SecondHand.Models;
using System.Collections.Generic;
using System.Linq;

namespace SecondHand.Data.Services
{
    public class ZenskaOblacilaService : IZenskaOblacilaService
    {
        private readonly AppDbContext _context;
        public ZenskaOblacilaService(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<KategorijeOblacila> GetAll()
        {
            var result = _context.KategorijeOblacilas.Where(p => p.Spol.Equals('Ž')).ToList();
            return result;
        }

        public IEnumerable<Oblacila> GetByImeKategorije(int idd)
        {
            var data = _context.Oblacilas.Where(p => p.KategorijaId == idd).ToList();
            return data;
        }
    }
}
