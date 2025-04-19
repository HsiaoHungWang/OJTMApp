using Microsoft.AspNetCore.Mvc;
using OJTMApp.Models.ClassDB;

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
