using Microsoft.AspNetCore.Identity;

namespace GemSoftDemoApp.UI.Services.UserServices
{
    public interface IUserService
    {
        

        Task<int> GetTeacherCount();

      
    }
}
