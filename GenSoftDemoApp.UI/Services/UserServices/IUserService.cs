using Microsoft.AspNetCore.Identity;

namespace GenSoftDemoApp.UI.Services.UserServices
{
    public interface IUserService
    {
        

        Task<int> GetTeacherCount();

      
    }
}
