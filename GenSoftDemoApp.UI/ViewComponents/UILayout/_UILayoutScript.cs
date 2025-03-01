using Microsoft.AspNetCore.Mvc;

namespace GenSoftDemoApp.UI.ViewComponents.UILayout
{
    public class _UILayoutScript: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
