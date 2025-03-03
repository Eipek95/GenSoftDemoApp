namespace GenSoftDemoApp.UI.Services.TokenServices
{
    public interface ITokenService
    {
        string GetUserToken { get; }
        string GetUsername { get; }
        int GetUserId { get; } 
        string GetUserRole { get; }

        bool IsInAdminRole { get; }
    }
}
