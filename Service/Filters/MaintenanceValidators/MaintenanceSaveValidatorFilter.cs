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
    public class MaintenanceSaveValidatorFilter : Validator
    {
        public MaintenanceSaveValidatorFilter(AppDbContext appDbContext) : base(appDbContext)
        {
            AddAvailableFilter<User, MaintenanceSaveDto>("ID", "CreatedBy");
            AddAvailableFilter<User, MaintenanceSaveDto>("ID", "UserID");
            AddAvailableFilter<User, MaintenanceSaveDto>("ID", "ResponsibleUserID");
            AddAvailableFilter<PictureGroup, MaintenanceSaveDto>("ID", "PictureGroupID");
            AddAvailableFilter<Status, MaintenanceSaveDto>("ID", "StatusID");
            AddAvailableFilter<Vehicle, MaintenanceSaveDto>("ID", "VehicleID");


        }
    }
}
