using Microsoft.AspNetCore.Mvc;
using OJTMApp.Models;

namespace OJTMApp.Controllers
{
    public class LinqController : Controller
    {
        //起手式：使用NorthwindContext類別存取資料庫的資料
        private readonly NorthwindContext _context;
        public LinqController(NorthwindContext context) {
            _context = context;
        }
        public IActionResult Index()
        {
            //新增
            //準備好要新增的資料
            //Category category = new Category
            //{
            //    CategoryName = "Test",
            //    Description = "TestTestTestTest"
            //};
            ////透過Add()新增資料
            //_context.Categories.Add(category);

            //修改
            //找到你要修改的資料
            //Category? category = _context.Categories.Find(9);
            //if(category != null)
            //{
            //    //修改資料
            //    category.CategoryName = "Test2";
            //    category.Description = "Test2Test2Test2Test2Test2Test2";
            //}

            //刪除
            //找到你要刪除的資料 Find()根據主鍵CategoryID查詢資料表的記錄
            //select * from Categories where CategoryID = 9 
            //Category? category = _context.Categories.Find(9);
            //if (category != null)
            //{
            //    //透過Remove()刪除資料
            //    _context.Categories.Remove(category);
            //}

            //_context.SaveChanges(); //寫入資料庫


            return View();
        }
    }
}
