using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace OJTMApp.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
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
           if(userAgent.Contains("Mobile", StringComparison.OrdinalIgnoreCase))
            {
                return Content("行動裝置");
            }
            else
            {
                return Content("桌面裝置");
            }




            //return View();
        }
    }
}
