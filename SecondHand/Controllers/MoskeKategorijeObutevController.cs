using Microsoft.AspNetCore.Mvc;
using SecondHand.Data.Services;

namespace SecondHand.Controllers
{
	public class MoskeKategorijeObutevController : Controller
	{
		private readonly IKategorijeObutevService _service;

		public MoskeKategorijeObutevController(IKategorijeObutevService service)
		{
			_service = service;
		}
		public IActionResult Index()
		{
			var data = _service.GetAll();
			return View(data);
		}
		public IActionResult Details(int id)
		{
			var kategorija = _service.GetByImeKategorije(id);
			if (kategorija == null) return View("Empty");
			return View(kategorija);
		}
	}
}
