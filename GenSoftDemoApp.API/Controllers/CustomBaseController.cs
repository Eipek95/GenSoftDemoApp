
using GenSoftDemoApp.Dto.ResponseDtos;
using Microsoft.AspNetCore.Mvc;
namespace GenSoftDemoApp.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        public IActionResult ActionResultInstance<T>(MyResponse<T> response) where T : class
        {
            return new ObjectResult(response)
            {
                StatusCode = response.StatusCode,
            };
        }
    }
}
