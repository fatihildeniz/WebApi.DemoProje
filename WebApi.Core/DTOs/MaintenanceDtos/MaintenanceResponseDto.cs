using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core.DTOs.MaintenanceHistoryDtos;
using WebApi.Core.DTOs.PictureGroupDtos;
using WebApi.Core.DTOs.StatusDtos;
using WebApi.Core.DTOs.UserDtos;

namespace WebApi.Core.DTOs.MaintenanceDtos
{
    public class MaintenanceResponseDto
    {
        public int ID { get; set; }
        public int VehicleID { get; set; }
        public int UserID { get; set; }
        public string Description { get; set; }
        public int PictureGroupID { get; set; }
        public DateTime ExpectedTimeToFix { get; set; }
        public int ResponsibleUserID { get; set; }
        public string LocationLongitude { get; set; }
        public string LocationLatitude { get; set; }
        public int StatusID { get; set; }



    }
}
