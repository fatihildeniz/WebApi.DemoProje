using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core.DTOs.MaintenanceDtos;
using WebApi.Core.Entities;
using WebApi.Repository;
using WebApi.Validation.Abstract;

namespace WebApi.Service.Filters.MaintenanceValidators
{
    public class MaintenanceUpdateValidatorFilter : Validator
    {
        public MaintenanceUpdateValidatorFilter(AppDbContext appDbContext) : base(appDbContext)
        {
            AddAvailableFilter<Maintenance, MaintenanceUpdateDto>("ID", "ID");
            AddAvailableFilter<User, MaintenanceUpdateDto>("ID", "ModifiedBy");
            AddAvailableFilter<User, MaintenanceUpdateDto>("ID", "UserID");
            AddAvailableFilter<User, MaintenanceUpdateDto>("ID", "ResponsibleUserID");
            AddAvailableFilter<PictureGroup, MaintenanceUpdateDto>("ID", "PictureGroupID");
            AddAvailableFilter<Status, MaintenanceUpdateDto>("ID", "StatusID");
            AddAvailableFilter<Vehicle, MaintenanceUpdateDto>("ID", "VehicleID");
        }
    }
}
