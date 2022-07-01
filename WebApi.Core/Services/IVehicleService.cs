using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core.DTOs;
using WebApi.Core.DTOs.VehicleDtos;
using WebApi.Core.Entities;

namespace WebApi.Core.Services
{
    public interface IVehicleService : IGenericService<Vehicle>
    {
        CustomResponseDto Add(VehicleSaveDto saveDto);
        CustomResponseDto Update(VehicleUpdateDto updateDto);

        //CustomResponseDto DeleteVehicle(int id);
        //CustomResponseDto GetVehicle(int id);
    }


}
