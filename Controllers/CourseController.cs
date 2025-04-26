using Microsoft.AspNetCore.Mvc;

namespace OJTMApp.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //新增課程的View
        public IActionResult Create()
        {
            return View();
        }
    }
}
