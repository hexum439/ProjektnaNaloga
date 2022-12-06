using SecondHand.Models;
using System.Collections.Generic;

namespace SecondHand.Data.Services
{
    public interface IZenskaOblacilaService
    {
        IEnumerable<KategorijeOblacila> GetAll();

        IEnumerable<Oblacila> GetByImeKategorije(int idd);
    }
}
