using System.Collections.Generic;
using SecondHand.Models;

namespace SecondHand.Data.Services
{
	public interface IKategorijeService
	{
		IEnumerable<KategorijeOblacila> GetAll();

		IEnumerable<Oblacila> GetByImeKategorije(int idd);
	}
}
