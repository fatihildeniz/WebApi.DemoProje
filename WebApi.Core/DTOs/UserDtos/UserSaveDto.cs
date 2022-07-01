using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Core.DTOs.UserDtos
{
    public class UserSaveDto
    {
        public UserAuthenticationSaveDto UserAuthenticationSaveDto { get; set; }
        public int CreatedBy { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string ProfilePicture { get; set; }
        public string Address { get; set; }
    }
}
