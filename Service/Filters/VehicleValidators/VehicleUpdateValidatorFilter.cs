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
    public class VehicleUpdateValidatorFilter : Validator
    {
        public VehicleUpdateValidatorFilter(AppDbContext appDbContext) : base(appDbContext)
        {
            AddAvailableFilter<Vehicle, VehicleUpdateDto>("ID", "ID");
            AddNotAvailableFilter<Vehicle, VehicleUpdateDto>("PlateNo", "PlateNo");
            AddAvailableFilter<VehicleType, VehicleUpdateDto>("ID", "VehicleTypeID");
            AddAvailableFilter<User, VehicleUpdateDto>("ID", "ModifiedBy");
            AddAvailableFilter<User, VehicleUpdateDto>("ID", "UserID");
        }
    }
}
