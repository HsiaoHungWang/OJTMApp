using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace OJTMApp.Controllers
{
    public class DemoController : Controller
    {
        // public async Task<IActionResult> Index()
        public IActionResult Index()
        {
            // await Task.Delay(1000); //模擬非同步的工作

            // HTTPContext => HTTP 協定的相關資訊  Request/Response
            //HttpContext.Request => HttpRequest

            //路徑
            //return Content(Request.Path.ToString());  // http://..../demo/index

            //Method GET、POST
            //return Content(Request.Method.ToString()); // GET

            //讀取 Request Headers 中的資料
            //var headers = Request.Headers;

            //var message = new StringBuilder();
            //foreach(var header in headers)
            //{
            //    //key:value
            //    //accept-language:zh-TW,zh;q=0.9,en-US;q=0.8,en;q=0.7
            //    message.AppendLine($"{header.Key}:{header.Value}");

            //}

            //return Content(message.ToString());

            //使用者使用的瀏覽器語言 Headers["Key"] => Value
            //var language = Request.Headers["Accept-Language"].ToString();
            //if (language.StartsWith("zh"))
            //{
            //    return Content("顯示中文");

            //}
            //else
            //{
            //    return Content("Display English");
            //}

            //User-Agent
            var userAgent = Request.Headers["User-Agent"].ToString();
            // return Content(userAgent);
            //判斷是否是行動裝置
            if (userAgent.Contains("Mobile", StringComparison.OrdinalIgnoreCase))
            {
                return Content("行動裝置");
            }
            else
            {
                return Content("桌面裝置");
            }

            //return NotFound();




            //return View();
        }
    
       public IActionResult About()
        {
            //ViewData跟ViewBag共用的是同一個字典物件key=value
            ViewData["currentTime"] = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
            ViewBag.currentTime = DateTime.Now.AddHours(1).ToString("yyyy/MM/dd HH:mm:ss");
            //TempData 搭配 RedirctToAction 來使用
            TempData["currentTime"] = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");

            return View(); //回應的是About.cshtml
            //return RedirectToAction("Contact");

            // return View("Index"); //回應的是Index.cshtml

            //return RedirectToAction("Index"); //先回到瀏覽器，再從瀏覽器Request Demo/Index
            //return RedirectToAction("Index","Member");

            //return Redirect("~/demo/index");
            //return Redirect("~/member/index");
            //return Redirect("https://www.ispan.com.tw");
        }
        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult DayAndNight()
        {
            //todo4 讀取Cookies theme 資料
            //todo5 將資料傳給View
            

            return View();
        }
        public IActionResult SetTheme()
        {
            //todo1 要能夠取的使用者選擇的 theme Day/Night
            //todo2 day/nigth寫進cookies
            //todo3 轉到DayAndNight的Action

            return View();
        }
    }

}
