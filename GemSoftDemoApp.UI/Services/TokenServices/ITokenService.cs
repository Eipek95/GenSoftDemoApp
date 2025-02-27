namespace GemSoftDemoApp.UI.Services.TokenServices
{
    public class ITokenService
    {
        public string GetUserToken { get; }
        public int GetUserId { get; }
        public string GetUserRole { get; }
        public string GetUserNameSurname { get; }
    }
}
