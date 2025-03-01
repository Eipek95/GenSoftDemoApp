using GenSoftDemoApp.UI.Models;
using GenSoftDemoApp.UI.ViewModels.CategoryViewModels;
using Microsoft.AspNetCore.Mvc;

namespace GenSoftDemoApp.UI.ViewComponents.UILayout
{
    public class _UILayoutHeader : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
