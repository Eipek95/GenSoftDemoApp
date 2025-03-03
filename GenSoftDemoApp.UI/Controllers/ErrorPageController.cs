using Microsoft.AspNetCore.Mvc;

namespace GenSoftDemoApp.UI.Controllers
{
    public class ErrorPageController : Controller
    {
        [Route("/accessdenied")]
        public IActionResult AccessDenied()
        {
            return View();
        } 
        [Route("/notfound404")]
        public IActionResult NotFound404()
        {
            return View();
        }
    }
}
