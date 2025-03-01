using GemSoftDemoApp.UI.Models;
using GemSoftDemoApp.UI.ViewModels.CategoryViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GemSoftDemoApp.UI.ViewComponents.UILayout
{
    public class _UILayoutHeader : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
