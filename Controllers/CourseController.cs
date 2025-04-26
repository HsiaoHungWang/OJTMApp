using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using OJTMApp.Models.ClassDB;
using OJTMApp.Models.ViewModel;
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
        public async Task<IActionResult> Index()
        {
            //讀取所有課程資料
            var courses = await db.Courses.ToListAsync();
            return View(courses);
        }

        public IActionResult GetImageFile(string file)
        {
            //return Content(file);
            return File($"~/courses/{file}", "image/webp");
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
        public async Task<IActionResult> Create(CourseViewModel course)
        {
            if (course.CourseImage != null)
            {
              
                //檔案上傳的路徑
                 var filePath = Path.Combine(_hostEnvironment.WebRootPath, "courses", course.CourseImage.FileName);
            //檔案上傳
                        using (var stram = new FileStream(filePath, FileMode.Create))
                        {
                    await course.CourseImage.CopyToAsync(stram);
                        }
            }
           


            //透過ViewModel收到資料後
            //將資料轉換成Course物件
            //才能新增
            Course _course = new Course()
            {
                CategoryId = course.CategoryId,
                CourseName = course.CourseName,
                CourseImage = course.CourseImage?.FileName,
                CoursePrice = course.CoursePrice,
                CourseHour = course.CourseHour,
                Description = course.Description,
                Objectives = course.Objectives,
                Suitable = course.Suitable,
                StartDate = course.StartDate,
                EndDate = course.EndDate,
                DaysOfWeek = course.DaysOfWeek != null ? string.Join("、", course.DaysOfWeek) : "",
                TimePeriods = course.TimePeriods,
                Location = course.Location
            };

            await db.Courses.AddAsync(_course);
            await db.SaveChangesAsync();
            // await Task.Delay(1000);

            return RedirectToAction("Create");
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
