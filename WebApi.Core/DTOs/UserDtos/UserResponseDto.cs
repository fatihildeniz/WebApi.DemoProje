using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Core.DTOs.UserDtos
{
    public class UserResponseDto
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string ProfilePicture { get; set; }
        public string Address { get; set; }
        
    }
}
