using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Core.DTOs.MaintenanceHistoryDtos
{
    public class MaintenanceHistoryUpdateDto
    {
        public int ID { get; set; }
        public int ActionTypeID { get; set; }
        public int ModifiedBy { get; set; }
        public int MaintenanceID { get; set; }
    }
}
