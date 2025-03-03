using GenSoftDemoApp.UI.Services.TokenServices;
using Microsoft.AspNetCore.Mvc;

namespace GenSoftDemoApp.UI.ViewComponents.PanelLayout
{
    public class _PanelSidebarComponent : ViewComponent
    {
        private readonly ITokenService _tokenService;

        public _PanelSidebarComponent(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }
        public IViewComponentResult Invoke()
        {
            ViewBag.userName = _tokenService.GetUsername;
            ViewBag.isInAdminRole = _tokenService.IsInAdminRole;
            return View();
        }
    }
}