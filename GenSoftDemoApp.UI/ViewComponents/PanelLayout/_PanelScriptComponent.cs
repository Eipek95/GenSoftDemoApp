using Microsoft.AspNetCore.Mvc;

namespace GenSoftDemoApp.UI.ViewComponents.PanelLayout
{
    public class _PanelScriptComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}