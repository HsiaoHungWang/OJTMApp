using Microsoft.AspNetCore.Mvc;

namespace OJTMApp.ViewComponents
{
    public class FirstViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(int count = 0)
        {    
            //.....

            return View("Default", $"Hello from FirstViewComponent {count}");
        }
    }
}
