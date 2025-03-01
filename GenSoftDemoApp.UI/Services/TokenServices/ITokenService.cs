namespace GemSoftDemoApp.UI.Services.TokenServices
{
    public interface ITokenService
    {
        string GetUserToken { get; }
        int GetUserId { get; } 
        string GetUserRole { get; }
    }
}
