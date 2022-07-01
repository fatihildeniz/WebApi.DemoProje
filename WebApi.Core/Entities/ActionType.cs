using System;
using System.Collections.Generic;
using System.Text;

namespace WebApi.Core.Entities
{
    public class ActionType:Base
    {
        public string Name { get; set; }

        public ICollection<MaintenanceHistory> MaintenanceHistories { get; set; }
    }
}
