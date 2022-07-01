using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core.DTOs.ActionTypeDtos;

namespace WebApi.Core.DTOs.MaintenanceHistoryDtos
{
    public class MaintenanceHistoryResponseDto
    {
        public int ID { get; set; }
        public int MaintenanceID { get; set; }
        public int ActionTypeID { get; set; }
        public DateTime CreateDate { get; set; }
        

    }
}
