using Microsoft.AspNetCore.Mvc;

namespace GenSoftDemoApp.UI.ViewComponents.PanelLayout
{
    public class _PanelNavbarComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}