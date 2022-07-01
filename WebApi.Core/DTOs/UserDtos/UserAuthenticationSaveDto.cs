using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Core.DTOs.UserDtos
{
    public class UserAuthenticationSaveDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }
    }
}
