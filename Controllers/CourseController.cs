using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OJTMApp.Models.ClassDB;
using System;

namespace OJTMApp.Controllers
{
    public class CourseController : Controller
    {
        private readonly ClassDbContext db;
        public CourseController(ClassDbContext _dbContext) {
            db = _dbContext;
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
        }
}
