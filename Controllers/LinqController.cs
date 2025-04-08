using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

            //查詢語法LINQ Query Syntax
            //var categories = from c in _context.Categories
            //                 //where c.CategoryName == "Beverages"
            //                 select c;
            //方法語法LINQ Method Syntax
            //_context.Categories.Where(c=>c.CategoryName== "Beverages").ToList();
            //var categories = _context.Categories.ToList();

            //關鍵字搜尋，相似度搜尋 where CategoryName like '%e%'
            var categories = _context.Categories.Where(c => c.CategoryName.Contains("ea")).ToList();

            //查到的資料要傳給View
            return View(categories);

            // return View();
        }
    
    
        public IActionResult Search()
        {
            //todo1 查詢商品最高價格(UnitPrice)的前五筆資料
            //var products = _context.Products
            //                .OrderByDescending(p => p.UnitPrice)
            //                .Take(5)
            //                .ToList();

            //todo2 查詢庫存量(UnitsInStock)低於安全存量(ReorderLevel)的商品
            //var products = _context.Products
            //                .Where(p => p.UnitsInStock < p.ReorderLevel)                            
            //                .ToList();


            //先做 todo1 跟 todo2，todo3 當課後練習
            //todo3 根據關鍵字、分類編號及價格區間來查詢商品
            //string keyword = "ch";
            //int? categoryId = 1;
            //decimal? minPrice = 10;
            //decimal? maxPrice = 100;



            //int pageSize = 10; //每頁顯示10筆資料
            //int page = 5; //目前在第一頁
            ////page = 1 => Skip(0) => 取得第1-10筆資料
            ////page = 2 => Skip(10) => 取得第11-20筆資料
            ////page = 3 => Skip(20) => 取得第21-30筆資料
            //var products = _context.Products
            //                .OrderByDescending(p => p.UnitPrice)
            //                .Skip((page-1)*pageSize)
            //               .Take(pageSize)
            //               .ToList();


            //前十個熱銷商品
            var products = _context.Products.OrderByDescending(p=>p.OrderDetails.Sum(od => od.Quantity))
                .Take(10)
                .ToList();

            return View(products);
        }


        public IActionResult MultipleTables()
        {
            var orders = _context.Orders
                               .Include(o => o.Customer)
                               .Include(o => o.Employee).Take(10).ToList();
            return View(orders);
        }
    }
}
