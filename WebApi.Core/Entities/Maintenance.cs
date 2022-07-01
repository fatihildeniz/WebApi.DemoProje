using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebApi.Core.Entities
{
    public class Maintenance : Base
    {
        
        public int VehicleID { get; set; }

        
        public int? UserID { get; set; }
        public string Description { get; set; }

        
        public int? PictureGroupID { get; set; }
        public DateTime ExpectedTimeToFix { get; set; }

        
        public int ResponsibleUserID { get; set; }
        public string LocationLongitude { get; set; }
        public string LocationLatitude { get; set; }

       
        public int? StatusID { get; set; }


        public List<MaintenanceHistory> MaintenanceHistories { get; set; }

        public PictureGroup PictureGroup { get; set; }

        public Status Status { get; set; }

        public User ResponsibleUser { get; set; }

        public User User { get; set; }

        public Vehicle Vehicle { get; set; }
    }
}
