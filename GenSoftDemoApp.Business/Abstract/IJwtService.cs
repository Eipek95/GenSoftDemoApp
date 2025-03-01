using GemSoftDemoApp.Dto.LoginDtos;
using GemSoftDemoApp.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GemSoftDemoApp.Business.Abstract
{
    public interface IJwtService
    {
        Task<LoginResponseDto> CreateTokenAsync(AppUser user);

    }
}
