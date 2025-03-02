using Microsoft.AspNetCore.Mvc;

namespace GenSoftDemoApp.UI.Areas.Panel.Controllers
{
    [Area("Panel")]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
