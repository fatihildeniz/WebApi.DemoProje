using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core.DTOs;
using WebApi.Core.DTOs.VehicleDtos;
using WebApi.Core.DTOs.VehicleTypeDtos;
using WebApi.Core.Entities;
using WebApi.Core.Repository;
using WebApi.Core.Services;
using WebApi.Core.UnitOfWorks;

namespace WebApi.Service.Services
{
    public class VehicleService : GenericService<Vehicle>, IVehicleService
    {
        
        public VehicleService(IGenericRepository<Vehicle> repository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            
        }

        public CustomResponseDto Add(VehicleSaveDto saveDto)
        {
            try
            {
                Vehicle vehicle = _mapper.Map<Vehicle>(saveDto);
                vehicle.CreateDate = DateTime.Now;
                if (Add(vehicle) != null)
                {
                    VehicleResponseDto responseDto = _mapper.Map<VehicleResponseDto>(vehicle);
                    return new CustomResponseDto() { Data = responseDto, Message = "Success : [Data] contains created Vehicle data", StatusCode = 201 };
                }

                return new CustomResponseDto() { Message = "Fail ", StatusCode = 500 };
            }
            catch (Exception e)
            {

                return new CustomResponseDto() { Message = "Fail " + e.Message, StatusCode = 500 };
            }
        }

        public CustomResponseDto Update(VehicleUpdateDto updateDto)
        {
            try
            {
                Vehicle vehicle = _mapper.Map<Vehicle>(updateDto);
                vehicle.ModifyDate = DateTime.Now;
                if (Update(vehicle) != null)
                {
                    VehicleResponseDto responseDto = _mapper.Map<VehicleResponseDto>(vehicle);
                    return new CustomResponseDto() { Data = responseDto, Message = "Success : [Data] contains updated Vehicle data", StatusCode = 201 };
                }
                return new CustomResponseDto() { Message = "Fail", StatusCode = 500 };
            }
            catch (Exception e)
            {

                return new CustomResponseDto() { Message = "Fail " + e.Message, StatusCode = 500 };
            }
        }

        //public CustomResponseDto CreateVehicle(VehicleSaveDto vehicleSaveDto)
        //{
        //    try
        //    {
        //        if (!_userService.IsAvailable(x => x.ID == vehicleSaveDto.UserID)) return new CustomResponseDto() { Message = "Fail. User not found." };
        //        if (!_userService.IsAvailable(x => x.ID == vehicleSaveDto.CreatedBy)) return new CustomResponseDto() { Message = "Fail. CreatedBy User not found." };
        //        if (!_vehicleTypeService.IsAvailable(x => x.ID == vehicleSaveDto.VehicleTypeID)) return new CustomResponseDto() { Message = "Fail. VehicleType not found." };
        //        if (IsAvailable(x => x.PlateNo == vehicleSaveDto.PlateNo)) return new CustomResponseDto() { Message = "Fail. PlateNo available." };

        //        Vehicle vehicle = _mapper.Map<Vehicle>(vehicleSaveDto);
        //        if (vehicle != null)
        //        {
        //            vehicle.CreateDate = DateTime.Now;
        //            vehicle.ModifiedBy = vehicle.CreatedBy;
        //            vehicle.ModifyDate = vehicle.CreateDate;

        //            if (Add(vehicle) > 0)
        //            {
        //                try
        //                {
        //                    VehicleResponseDto responseDto = _mapper.Map<VehicleResponseDto>(vehicle);
        //                    return new CustomResponseDto() { Data = responseDto, Message = "Succes. Data contains created Vehicle", StatusCode = 201 };

        //                }
        //                catch (Exception e)
        //                {
        //                    return new CustomResponseDto() { Message = "Success. " + e.Message, StatusCode = 204 };
        //                }
        //            }
        //        }

        //        return new CustomResponseDto() { Message = "Fail. Mapping error.", StatusCode = 500 };
        //    }
        //    catch (Exception e)
        //    {

        //        return new CustomResponseDto() { Message = "Fail." + e.Message, StatusCode = 500 };
        //    }



        //}

        //public CustomResponseDto DeleteVehicle(int id)
        //{
        //    try
        //    {
        //        if (RemoveById(id) > 0)
        //        {
        //            return new CustomResponseDto() { Message = "Success. Entity data deleted.", StatusCode = 204 };
        //        }
        //        return new CustomResponseDto() { Message = "Fail. Entity data not deleted.", StatusCode = 500 };
        //    }
        //    catch (Exception e)
        //    {
        //        return new CustomResponseDto() { Message = "Fail. "+e.Message, StatusCode = 500 };
        //    }


        //}

        //public CustomResponseDto GetVehicle(int id)
        //{
        //    try
        //    {
        //        Vehicle vehicle = GetById(id);
        //        if (vehicle != null)
        //        {
        //            try
        //            {
        //                VehicleResponseDto responseDto = _mapper.Map<VehicleResponseDto>(vehicle);
        //                return new CustomResponseDto() { Data = responseDto, Message = "Success. Data contains Vehicle data.", StatusCode = 201 };
        //            }
        //            catch (Exception e)
        //            {
        //                return new CustomResponseDto() { Message = e.Source + " " + e.Message, StatusCode = 500 };
        //            }
        //        }
        //        else
        //        {
        //            return new CustomResponseDto() { Message = "Vehicle not found.", StatusCode = 404 };
        //        }
        //    }
        //    catch (Exception e)
        //    {

        //        return new CustomResponseDto() { Message = e.Source + " " + e.Message, StatusCode = 500 };
        //    }
        //}

        //public CustomResponseDto UpdateVehicle(VehicleUpdateDto vehicleUpdateDto)
        //{
        //    try
        //    {
        //        if (!IsAvailable(x => x.ID == vehicleUpdateDto.ID)) return new CustomResponseDto() { Message = "Fail. Vehicle not found.", StatusCode = 404 };
        //        if (!_userService.IsAvailable(x => x.ModifiedBy == vehicleUpdateDto.ModifiedBy)) return new CustomResponseDto() { Message = "Fail. ModifiedBy User not found.", StatusCode = 404 };
        //        if (IsAvailable(x => x.PlateNo == vehicleUpdateDto.PlateNo)) return new CustomResponseDto() { Message = "Fail. PlateNo available.", StatusCode = 403 };
        //        if (!IsAvailable(x => x.VehicleTypeID == vehicleUpdateDto.VehicleTypeID)) return new CustomResponseDto() { Message = "Fail. VehicleType not found.", StatusCode = 404 };
        //        if (!IsAvailable(x => x.UserID == vehicleUpdateDto.UserID)) return new CustomResponseDto() { Message = "Fail. User not found.", StatusCode = 404 };

        //        Vehicle vehicle = GetById(vehicleUpdateDto.ID);

        //        if (vehicle != null)
        //        {
        //            vehicle.PlateNo = vehicleUpdateDto.PlateNo;
        //            vehicle.VehicleTypeID = vehicleUpdateDto.VehicleTypeID;
        //            vehicle.UserID = vehicleUpdateDto.UserID;
        //            vehicle.ModifiedBy = vehicleUpdateDto.ModifiedBy;
        //            vehicle.ModifyDate = DateTime.Now;


        //            if (Update(vehicle) > 0)
        //            {
        //                VehicleResponseDto responseDto = _mapper.Map<VehicleResponseDto>(vehicle);
        //                return new CustomResponseDto() { Data = responseDto, Message = "Success. Data contains new values", StatusCode = 201 };

        //            }
        //            else
        //            {
        //                return new CustomResponseDto() { Message = "Fail. Property or properties not correct.", StatusCode = 400 };
        //            }
        //        }
        //        return new CustomResponseDto() { Message = "Server Error.", StatusCode = 500 };

        //    }
        //    catch (Exception e)
        //    {

        //        return new CustomResponseDto() { Message = e.Source + " " + e.Message, StatusCode = 500 };
        //    }
        //}
    }
}
