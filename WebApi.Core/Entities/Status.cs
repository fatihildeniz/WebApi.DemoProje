using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Core.Entities
{
    public class Status :Base
    {
        public string Name { get; set; }

        public List<Maintenance> Maintenances { get; set; }
    }
}
