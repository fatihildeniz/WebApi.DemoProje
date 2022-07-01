using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core.DTOs;
using WebApi.Core.DTOs.VehicleTypeDtos;
using WebApi.Core.Entities;
using WebApi.Core.Repository;
using WebApi.Core.Services;
using WebApi.Core.UnitOfWorks;

namespace WebApi.Service.Services
{
    public class VehicleTypeService : GenericService<VehicleType>, IVehicleTypeService
    {
        
        public VehicleTypeService(IGenericRepository<VehicleType> repository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            
        }

        public CustomResponseDto Add(VehicleTypeSaveDto saveDto)
        {
            try
            {
                VehicleType vehicleType = _mapper.Map<VehicleType>(saveDto);
                vehicleType.CreateDate = DateTime.Now;
                if (Add(vehicleType) != null)
                {
                    VehicleTypeResponseDto responseDto = _mapper.Map<VehicleTypeResponseDto>(vehicleType);
                    return new CustomResponseDto() { Data = responseDto, Message = "Success : [Data] contains created VehicleType data", StatusCode = 201 };
                }

                return new CustomResponseDto() { Message = "Fail ", StatusCode = 500 };
            }
            catch (Exception e)
            {

                return new CustomResponseDto() { Message = "Fail " + e.Message, StatusCode = 500 };
            }
        }

        public CustomResponseDto Update(VehicleTypeUpdateDto updateDto)
        {
            try
            {
                VehicleType vehicleType = _mapper.Map<VehicleType>(updateDto);
                vehicleType.ModifyDate = DateTime.Now;
                if (Update(vehicleType) != null)
                {
                    VehicleTypeResponseDto responseDto = _mapper.Map<VehicleTypeResponseDto>(vehicleType);
                    return new CustomResponseDto() { Data = responseDto, Message = "Success : [Data] contains updated VehicleType data", StatusCode = 201 };
                }
                return new CustomResponseDto() { Message = "Fail", StatusCode = 500 };
            }
            catch (Exception e)
            {

                return new CustomResponseDto() { Message = "Fail " + e.Message, StatusCode = 500 };
            }
        }

        //public CustomResponseDto CreateVehicleType(VehicleTypeSaveDto vehicleTypeSaveDto)
        //{
        //    if (IsAvailable(x => x.Name == vehicleTypeSaveDto.Name)) return new CustomResponseDto() { Message = "Fail. VehicleType available." };

        //    VehicleType vehicleType;

        //    if (_userService.GetById(vehicleTypeSaveDto.CreatedBy) != null)
        //    {
        //        try
        //        {
        //            vehicleType = _mapper.Map<VehicleType>(vehicleTypeSaveDto);

        //            vehicleType.CreateDate = DateTime.Now;
        //            vehicleType.ModifyDate = vehicleType.CreateDate;
        //            vehicleType.ModifiedBy = vehicleType.CreatedBy;

        //            if (vehicleType != null)
        //            {
        //                if (Get(x => x.Name == vehicleType.Name).Count == 0)
        //                {
        //                    if (Add(vehicleType) > 0)
        //                    {
        //                        try
        //                        {
        //                            VehicleTypeResponseDto vehicleTypeDto = _mapper.Map<VehicleTypeResponseDto>(vehicleType);
        //                            return new CustomResponseDto() { Data = vehicleTypeDto, Message = "Success. Data contains created VehicleType.", StatusCode = 201 };
        //                        }
        //                        catch (Exception)
        //                        {

        //                            return new CustomResponseDto() { Message = "Success.", StatusCode = 204 };
        //                        }

        //                    }
        //                }
        //                else
        //                {
        //                    return new CustomResponseDto() { Message = "VehicleType is available.", StatusCode = 403 };
        //                }
        //            }
        //        }
        //        catch (Exception e)
        //        {
        //            return new CustomResponseDto() { Message = "Fail."+e.Message, StatusCode = 500 };
        //        }

        //    }

        //    return new CustomResponseDto() { Message = "CreatedBy user not found.", StatusCode = 404 };
        //}

        //public CustomResponseDto DeleteVehicleType(int id)
        //{
        //    if (RemoveById(id) > 0)
        //    {
        //        return new CustomResponseDto() { Message = "Success. Entity data deleted.", StatusCode = 204 };
        //    }
        //    return new CustomResponseDto() { Message = "Fail. Entity data not deleted.", StatusCode = 500 };
        //}

        //public CustomResponseDto GetVehicleType(int id)
        //{
        //    try
        //    {
        //        VehicleType vehicleType = GetById(id);
        //        if (vehicleType != null)
        //        {
        //            try
        //            {
        //                VehicleTypeResponseDto responseDto = _mapper.Map<VehicleTypeResponseDto>(vehicleType);
        //                return new CustomResponseDto() { Data = responseDto, Message = "Success. Data contains user data.", StatusCode = 201 };
        //            }
        //            catch (Exception e)
        //            {
        //                return new CustomResponseDto() { Message = e.Source + " " + e.Message, StatusCode = 500 };
        //            }
        //        }
        //        else
        //        {
        //            return new CustomResponseDto() { Message = "VehicleType not found.", StatusCode = 404 };
        //        }
        //    }
        //    catch (Exception e)
        //    {

        //        return new CustomResponseDto() { Message = e.Source + "\n" + e.Message, StatusCode = 500 };
        //    }
        //}

        //public CustomResponseDto UpdateVehicleType(VehicleTypeUpdateDto vehicleTypeUpdateDto)
        //{
        //    try
        //    {
        //        if (!_userService.IsAvailable(x => x.ModifiedBy == vehicleTypeUpdateDto.ModifiedBy)) return new CustomResponseDto() { Message = "Fail. ModifiedBy User not found.", StatusCode = 404 };
        //        if (!IsAvailable(x => x.ID == vehicleTypeUpdateDto.ID)) return new CustomResponseDto() { Message = "Fail. VehicleType not found.", StatusCode = 404 };
        //        if (IsAvailable(x => x.Name == vehicleTypeUpdateDto.Name)) return new CustomResponseDto() { Message = "Fail. VehicleType available.", StatusCode = 403 };


        //        VehicleType vehicleType = GetById(vehicleTypeUpdateDto.ID);

        //        if (vehicleType != null)
        //        {

        //            vehicleType.Name = vehicleTypeUpdateDto.Name;
        //            vehicleType.ModifiedBy = vehicleTypeUpdateDto.ModifiedBy;
        //            vehicleType.ModifyDate = DateTime.Now;

        //            if (Update(vehicleType) > 0)
        //            {
        //                VehicleTypeResponseDto responseDto = _mapper.Map<VehicleTypeResponseDto>(vehicleType);
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
