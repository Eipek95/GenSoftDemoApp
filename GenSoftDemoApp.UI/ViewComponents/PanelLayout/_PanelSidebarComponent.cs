using Microsoft.AspNetCore.Mvc;

namespace GenSoftDemoApp.UI.ViewComponents.PanelLayout
{
    public class _PanelSidebarComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}