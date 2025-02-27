using Microsoft.AspNetCore.Mvc;

namespace GemSoftDemoApp.UI.ViewComponents.UILayout
{
    public class _UILayoutScript: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
