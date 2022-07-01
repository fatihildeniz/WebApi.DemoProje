using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core.DTOs.VehicleDtos;
using WebApi.Core.Entities;
using WebApi.Repository;
using WebApi.Validation.Abstract;

namespace WebApi.Service.Filters.VehicleValidators
{
    public class VehicleSaveValidatorFilter : Validator
    {
        public VehicleSaveValidatorFilter(AppDbContext appDbContext) : base(appDbContext)
        {
            AddNotAvailableFilter<Vehicle, VehicleSaveDto>("PlateNo", "PlateNo");
            AddAvailableFilter<VehicleType, VehicleSaveDto>("ID", "VehicleTypeID");
            AddAvailableFilter<User, VehicleSaveDto>("ID", "CreatedBy");
            AddAvailableFilter<User, VehicleSaveDto>("ID", "UserID");
        }
    }
}
