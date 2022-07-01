using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Core.DTOs.ActionTypeDtos
{
    public class ActionTypeUpdateDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ModifiedBy { get; set; }
        
    }
}
