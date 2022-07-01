using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebApi.Core.Entities
{
    public class Vehicle:Base
    {
        public string PlateNo { get; set; }

        
        public int VehicleTypeID { get; set; }

        
        public int? UserID { get; set; }

        public List<Maintenance> Maintenances { get; set; }

        public VehicleType VehicleType { get; set; }

        public User User { get; set; }
    }
}
