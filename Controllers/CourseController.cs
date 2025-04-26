using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OJTMApp.Models.ClassDB;

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
            ViewBag.categories = new SelectList(db.Categories, "CategoryId", "CategoryName");
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
    }
}
