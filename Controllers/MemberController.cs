using Microsoft.AspNetCore.Mvc;

namespace OJTMApp.Controllers
{
    public class MemberController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetImageFile(string file)
        {
            //?file=cat2.jpg  key=value
            //傳統寫法
            //return Content(Request.Query["file"].ToString());

            //return Content(file);
            return File($"~/images/{file}", "image/jpeg");
        }
    }
}
