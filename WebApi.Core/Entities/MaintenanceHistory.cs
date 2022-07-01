using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebApi.Core.Entities
{
    public class MaintenanceHistory:Base
    {
       
        public int MaintenanceID { get; set; }

       
        public int ActionTypeID { get; set; }


        public ActionType ActionType { get; set; }

        public Maintenance Maintenance { get; set; }
    }
}
