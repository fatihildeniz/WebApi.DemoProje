using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Core.DTOs.VehicleDtos
{
    public class VehicleUpdateDto
    {
        public int ID { get; set; }
        public string PlateNo { get; set; }
        public int VehicleTypeID { get; set; }
        public int UserID { get; set; }
        public int ModifiedBy { get; set; }
    }
}
