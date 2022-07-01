using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core.DTOs.VehicleTypeDtos;
using WebApi.Core.Entities;
using WebApi.Repository;
using WebApi.Validation.Abstract;

namespace WebApi.Service.Filters.VehicleTypeValidators
{
    public class VehicleTypeUpdateValidatorFilter : Validator
    {
        public VehicleTypeUpdateValidatorFilter(AppDbContext appDbContext) : base(appDbContext)
        {
            AddAvailableFilter<VehicleType, VehicleTypeUpdateDto>("ID", "ID");
            AddNotAvailableFilter<VehicleType, VehicleTypeUpdateDto>("Name", "Name");
            AddAvailableFilter<User, VehicleTypeUpdateDto>("ID", "ModifiedBy");
        }
    }
}
