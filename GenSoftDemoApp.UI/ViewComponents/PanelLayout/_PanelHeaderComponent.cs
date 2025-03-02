using Microsoft.AspNetCore.Mvc;

namespace GenSoftDemoApp.UI.ViewComponents.PanelLayout
{
    public class _PanelHeaderComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
