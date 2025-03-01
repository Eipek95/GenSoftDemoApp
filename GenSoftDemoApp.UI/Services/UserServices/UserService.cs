
namespace GenSoftDemoApp.UI.Services.UserServices
{
    public class UserService:IUserService
    {
        private readonly HttpClient _client;

        public UserService(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("GemSoftAppClient");
        }

        public Task<int> GetTeacherCount()
        {
            throw new NotImplementedException();
        }
    }
}
