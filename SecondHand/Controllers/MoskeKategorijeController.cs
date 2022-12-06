using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SecondHand.Data;
using SecondHand.Data.Services;

namespace SecondHand.Controllers
{
    public class MoskeKategorijeController : Controller
    {
		private readonly IKategorijeService _service;

		public MoskeKategorijeController(IKategorijeService service)
		{
			_service = service;
		}
		public IActionResult Index()
        {
            var data = _service.GetAll();
            return View(data);
        }
        public IActionResult Details(int id) {
            var kategorija = _service.GetByImeKategorije(id);
            if (kategorija == null)  return View("Empty");
            return View(kategorija);
        }
    }
}
