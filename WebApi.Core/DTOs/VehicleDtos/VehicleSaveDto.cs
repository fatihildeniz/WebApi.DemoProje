using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core.DTOs.UserDtos;
using WebApi.Core.DTOs.VehicleTypeDtos;

namespace WebApi.Core.DTOs.VehicleDtos
{
    public class VehicleSaveDto
    {
        
        public string PlateNo { get; set; }
        public int VehicleTypeID { get; set; }
        public int UserID { get; set; }
        public int CreatedBy { get; set; }

    }
}
