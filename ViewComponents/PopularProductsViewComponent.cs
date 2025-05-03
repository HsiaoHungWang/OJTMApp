using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OJTMApp.Models;

namespace OJTMApp.ViewComponents
{
    public class PopularProductsViewComponent : ViewComponent
    {
        private readonly NorthwindContext _context;
        public PopularProductsViewComponent(NorthwindContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int top = 3)
        {

            var products = await _context.Products.OrderByDescending(p => p.OrderDetails.Sum(od => od.Quantity))
                .Take(top).ToListAsync();

            return View("Default", products);
        }
    }
}
