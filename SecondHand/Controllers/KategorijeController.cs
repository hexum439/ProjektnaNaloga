using Microsoft.AspNetCore.Mvc;
using SecondHand.Data;
using SecondHand.Data.Services;

namespace SecondHand.Controllers
{
    public class KategorijeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
        
    }
}
