using Microsoft.AspNetCore.Mvc;

namespace OJTMApp.Areas.Supplier.Controllers
{
    [Area("Supplier")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
