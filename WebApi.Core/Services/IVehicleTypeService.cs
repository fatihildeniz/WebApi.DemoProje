using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core.DTOs;
using WebApi.Core.DTOs.VehicleTypeDtos;
using WebApi.Core.Entities;

namespace WebApi.Core.Services
{
    public interface IVehicleTypeService : IGenericService<VehicleType>
    {
        CustomResponseDto Add(VehicleTypeSaveDto saveDto);
        CustomResponseDto Update(VehicleTypeUpdateDto updateDto);
        
        
        //CustomResponseDto DeleteVehicleType(int id);
        //CustomResponseDto GetVehicleType(int id);
    }
}
