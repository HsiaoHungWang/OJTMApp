using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OJTMApp.Models.ClassDB;
using OJTMApp.Models.ViewModel;

namespace OJTMApp.Controllers
{
    public class MemberController : Controller
    {
        private readonly ClassDbContext db;
        public MemberController(ClassDbContext classDbContext) {
            db = classDbContext;
        }
        public IActionResult Index()
        {
            //讀取Cookies
            string? name = Request.Cookies["name"];
            if(name == null)
            {
               ViewData["name"] = "訪客";
            }
            else
            {
                ViewData["name"] = name;
            }

            //Session讀取
            string? userName = HttpContext.Session.GetString("name");
            string? userAge = HttpContext.Session.GetInt32("Age").ToString();
            ViewData["userData"] = $"UserName:{userName}，UserAge:{userAge}";



            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        //怎麼接收表單送過來的資料 不管是GET還是POST
        //?userName=abc&userPassword=123
        [HttpPost]
     //   public IActionResult Login(string userName, string userPassword)
         public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            string email = loginVM.userEmail ?? string.Empty;
            string password = loginVM.userPassword ?? string.Empty  ;
            string rememberMe = loginVM.rememberMe ?? string.Empty;

            //todo 去資料庫比對帳號密碼是否正確
            Member? member = await db.Members.FirstOrDefaultAsync(m =>m.Email!= null && m.Email.Equals(email));
            if(member == null)
            {
                ViewBag.Message = "查無此帳號";

            }
            else
            {
                //todo: 密碼比對

                ViewBag.Message = "登入成功";
            }
              ///  ViewBag.Message = $"使用者名稱:{email}，密碼:{password}, 記住我{rememberMe}";

            return View();

            ////Cookie 設定
            //CookieOptions options = new CookieOptions()
            //{
            //    Expires = DateTime.Now.AddMinutes(1), //保留1分鐘
            //    HttpOnly = true, //無法用JavaScript讀取
            //};

            ////將登入帳號寫入Cookie
            //Response.Cookies.Append("name", "Tom", options);

            ////資料寫入Session
            //HttpContext.Session.SetString("name", "Mary");
            //HttpContext.Session.SetInt32("Age", 32);


            //return RedirectToAction("Index");

        }

        public IActionResult DeleteSession()
        {
            HttpContext.Session.Clear();   //清除Session所有資料 
            //HttpContext.Session.Remove("UserName"); //刪除指定的Session資料

            return RedirectToAction("Index");
        }

        public IActionResult GetImageFile(string file)
        {
            //?file=cat2.jpg  key=value
            //傳統寫法
            //return Content(Request.Query["file"].ToString());

            //return Content(file);
            return File($"~/images/{file}", "image/jpeg");
        }

        public async Task<IActionResult> Avatar(int id = 1)
        {
            Member? member = await db.Members.FindAsync(id);
            if(member == null)
            {
                return NotFound();
            }
            //讀取會員的圖像檔名
            //string? file = member.FileName;
            //if (string.IsNullOrEmpty(file))
            //{
            //    return NotFound();
            //}
            //return File($"~/images/{file}", "image/jpeg"); 

            //讀取會員的圖像二進位資料
            byte[]? file = member.FileData;
            if(file == null)
            {
                return NotFound();
            }
            return File(file, "image/jpeg");


        }

    }
}
