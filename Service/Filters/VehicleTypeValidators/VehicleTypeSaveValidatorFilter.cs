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
    public class VehicleTypeSaveValidatorFilter : Validator
    {
        public VehicleTypeSaveValidatorFilter(AppDbContext appDbContext) : base(appDbContext)
        {
            AddNotAvailableFilter<VehicleType, VehicleTypeSaveDto>("Name", "Name");
            AddAvailableFilter<User, VehicleTypeSaveDto>("ID", "CreatedBy");
        }
    }
}
