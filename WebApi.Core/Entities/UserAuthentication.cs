using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebApi.Core.Entities
{
    public class UserAuthentication
    {
        public int ID { get; set; }
        
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserRole { get; set; }

        public User User { get; set; }
    }
}
