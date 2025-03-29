using Microsoft.AspNetCore.Mvc;
using OJTMApp.Models;

namespace OJTMApp.Controllers
{
    public class AbcController : Controller
    {
        private readonly INotificationService _notificationService;
        public AbcController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public IActionResult Index()
        {
            ViewBag.Message = _notificationService.SendMessage("xyz@company.com", "Hello, DI!!");
            return View();
        }
    }
}
