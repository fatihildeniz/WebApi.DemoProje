using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Core.DTOs.MaintenanceHistoryDtos
{
    public class MaintenanceHistorySaveDto
    {
        public int MaintenanceID { get; set; }
        public int ActionTypeID { get; set; }
        public int CreatedBy { get; set; }
    }
}
