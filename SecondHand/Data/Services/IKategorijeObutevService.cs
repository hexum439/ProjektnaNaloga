using SecondHand.Models;
using System.Collections.Generic;

namespace SecondHand.Data.Services
{
	public interface IKategorijeObutevService
	{
		IEnumerable<KategorijeCevlji> GetAll();

		IEnumerable<Obutev> GetByImeKategorije(int idd);
	}
}
