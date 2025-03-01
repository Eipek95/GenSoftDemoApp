using System.Security.Claims;

namespace GemSoftDemoApp.UI.Services.TokenServices
{
    public class OETokenService : ITokenService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public OETokenService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public string GetUserToken => _contextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == "Token")?.Value;

        public int GetUserId => int.Parse(
            _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value == null ? "0" : _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

        public string GetUserRole => _contextAccessor.HttpContext.User.FindFirst(ClaimTypes.Role)?.Value;


        //public bool IsInAdminRole => _contextAccessor.HttpContext.User.IsInRole("Admin");

        //public bool IsInStudentRole => _contextAccessor.HttpContext.User.IsInRole("Student");
    }
}
