using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OJTMApp.Models;
using OJTMApp.Models.ViewModel;
using System.Transactions;

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


        //Transaction(交易)
        public IActionResult Index1()
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                //新增一筆訂單資料
                var newOrder = new Order
                {
                    CustomerId = "PERIC",
                    OrderDate = DateTime.Now,
                    EmployeeId = 5
                };

                _context.Orders.Add(newOrder);//新增一筆資料
                _context.SaveChanges();

                //再新增量兩筆訂單明細資料
                var orderDetail1 = new List<OrderDetail>
                {
                    new OrderDetail
                    {
                        OrderId = newOrder.OrderId,
                        ProductId = 1234,
                        UnitPrice = 10,
                        Quantity = 2
                    },
                    new OrderDetail
                    {
                        OrderId = newOrder.OrderId,
                        ProductId = 2,
                        UnitPrice = 20,
                        Quantity = 3
                    }
                };
                _context.OrderDetails.AddRange(orderDetail1);//新增多筆資料
                _context.SaveChanges(); 


                //確認這次的異動成功
                transaction.Commit();
            }
            catch (Exception)
            {
                //還原回異動前的狀態
                transaction.Rollback();
                throw;
            }
            
               
           

            
               



                return View();
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
            string keyword = "ch";
            int? categoryId = 1;
            decimal? minPrice = 10;
            decimal? maxPrice = 100;
            var products = _context.Products
                .Where(p => p.ProductName.Contains(keyword) &&
                p.CategoryId == categoryId &&
                p.UnitPrice >= minPrice && p.UnitPrice <= maxPrice)
                .ToList();




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
            //var products = _context.Products.OrderByDescending(p => p.OrderDetails.Sum(od => od.Quantity))
            //    .Take(10)
            //    .ToList();

           


            return View(products);
        }


        public IActionResult MultipleTables()
        {
            var orders = _context.Orders
                               .Include(o => o.Customer)
                               .Include(o => o.Employee).Take(10).ToList();
            return View(orders);
        }
    
    
        public IActionResult Query1()
        {
            //讀取特定欄位的資料
            //var top10Products = _context.Products.OrderByDescending(p => p.OrderDetails.Sum(od => od.Quantity))
            //    .Select(p => new
            //    {
            //        p.ProductId,
            //        p.ProductName,
            //        p.UnitPrice                   
            //    })
            //    .Take(10)
            //    .ToList();

            //使用ViewModel
            var top10Products = _context.Products.OrderByDescending(p => p.OrderDetails.Sum(od => od.Quantity))
                .Select(p => new Top10ProductViewModel
                {
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    UnitPrice = p.UnitPrice
                })
               .Take(10)
                .ToList();

            return View(top10Products);
        }


        //GroupBy()
        //統計客戶訂單數量及總金額
        public IActionResult Query2()
        {
            //var customerOrders = _context.Orders.GroupBy(o => o.CustomerId)
            //    .Select(g => new
            //    {
            //        CustomerId = g.Key,
            //        CompanyName = g.FirstOrDefault().Customer.CompanyName,  
            //        TotalOrders = g.Count(),
            //        TotalAmount = g.Sum(o => o.OrderDetails.Sum(od=>od.Quantity * od.UnitPrice))
            //    })
            //    .OrderByDescending(g => g.TotalAmount)
            //    .Take(10)
            //    .ToList();

            //使用ViewModel
            var customerOrders = _context.Orders.GroupBy(o => o.CustomerId)
                .Select(g => new CustomerOrdersViewModel
                {
                    CustomerId = g.Key ?? string.Empty ,
                    //CompanyName = g.FirstOrDefault().Customer.CompanyName,
                    CompanyName = g.Select(o => o.Customer != null ? o.Customer.CompanyName : "").FirstOrDefault(),
                    TotalOrders = g.Count(),
                    TotalAmount = g.Sum(o => o.OrderDetails.Sum(od => od.Quantity * od.UnitPrice))
                })
                .OrderByDescending(g => g.TotalAmount)
                .Take(10)
                .ToList();



            return View(customerOrders);
        }
    
    
        //統計商品的銷售數量及總銷售額，顯示商品編號及名稱，Supplier CompanyName
        //GroupBy() + ViewModel
        public IActionResult TodoGroupBy()
        {
            var productOrders = _context.OrderDetails.GroupBy(od => od.Product.ProductName)
                .Select(g => new ProductOrdersViewModel
                {
                    ProductName = g.Key,
                    SupplierName = g.Select(od => od.Product.Supplier != null ? od.Product.Supplier.CompanyName : "").FirstOrDefault(),
                    TotalQuantity = g.Sum(od => od.Quantity),
                    TotalPrice = g.Sum(od => od.Quantity * od.UnitPrice)
                }).ToList();
               
            return View(productOrders);
        }
    }
}
