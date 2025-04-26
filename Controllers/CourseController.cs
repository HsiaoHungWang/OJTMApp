using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using OJTMApp.Models.ClassDB;
using System;

namespace OJTMApp.Controllers
{
    public class CourseController : Controller
    {
        private readonly ClassDbContext db;
        private readonly IWebHostEnvironment _hostEnvironment;
        public CourseController(ClassDbContext _dbContext, IWebHostEnvironment hostEnvironment)
        {
            db = _dbContext;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        //新增課程的View
        [HttpGet]
        public IActionResult Create()
        {
            //asp-items => SelectList
            ViewBag.Categories = new SelectList(db.Categories, "CategoryId", "CategoryName");
            List<string> DaysOfWeek = new List<string>()
            {
                "一","二", "三", "四", "五", "六", "日"
            };

            ViewBag.DaysOfWeek = DaysOfWeek;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Course course)
        {
            //新增
            await db.Courses.AddAsync(course);
            await db.SaveChangesAsync();
            return View();
        }

        public IActionResult CheckBox()
        {
            List<string> DaysOfWeek = new List<string>()
            {
                "一","二", "三", "四", "五", "六", "日"
            };

            ViewBag.DaysOfWeek = DaysOfWeek;

            return View();
        }

        [HttpPost]
        public IActionResult CheckBox(List<string> daysOfWeek)
        {
            List<string> DaysOfWeek = new List<string>()
            {
                "一","二", "三", "四", "五", "六", "日"
            };

            ViewBag.DaysOfWeek = DaysOfWeek;
            ViewBag.Message = $"選擇的是 {string.Join(",", daysOfWeek)}";
            return View();
        }

        public IActionResult Upload()
        {
            ViewBag.Message = $"{_hostEnvironment.WebRootPath}";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile formFile)
        {
            //formFile.FileName
            //C:\工作區\workspace\OJTMApp\wwwroot\courses\
            //WebRootPath => C:\工作區\workspace\OJTMApp\wwwroot
            //ContentRootPath => C:\工作區\workspace\OJTMApp

            //檔案上傳的路徑
            var filePath = Path.Combine(_hostEnvironment.WebRootPath, "courses", formFile.FileName);

            //檔案上傳
            using (var stram = new FileStream(filePath, FileMode.Create))
            {
                await formFile.CopyToAsync(stram);
            }
                ViewBag.Message = $"檔案上傳成功：{filePath}"; // $"{formFile.FileName} - {formFile.Length} - {formFile.ContentType}";
            return View();
        }
    }
}
