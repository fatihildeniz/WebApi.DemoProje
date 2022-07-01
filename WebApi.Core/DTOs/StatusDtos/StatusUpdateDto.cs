using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Core.DTOs.StatusDtos
{
    public class StatusUpdateDto
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ModifiedBy { get; set; }
    }
}
