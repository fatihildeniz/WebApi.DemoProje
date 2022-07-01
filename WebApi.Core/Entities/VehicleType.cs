using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Core.Entities
{
    public class VehicleType:Base
    {
        public string Name { get; set; }

        public List<Vehicle> Vehicles { get; set; }
    }
}
