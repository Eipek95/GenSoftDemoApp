using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenSoftDemoApp.Dto.UserDtos
{
    public class CreateAssignRoleDto
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public bool RoleExist { get; set; }
    }
}
