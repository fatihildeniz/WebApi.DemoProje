using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core.DTOs.ActionTypeDtos;
using WebApi.Core.DTOs.MaintenanceDtos;
using WebApi.Core.DTOs.MaintenanceHistoryDtos;
using WebApi.Core.DTOs.PictureGroupDtos;
using WebApi.Core.DTOs.StatusDtos;
using WebApi.Core.DTOs.UserDtos;
using WebApi.Core.DTOs.VehicleDtos;
using WebApi.Core.DTOs.VehicleTypeDtos;
using WebApi.Core.Entities;

namespace WebApi.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {

            CreateMap<UserSaveDto, User>().ForMember(x => x.UserAuthentication, o => o.MapFrom(c=>c.UserAuthenticationSaveDto));
                
                
                
            

            
            CreateMap<UserAuthenticationSaveDto, User>().ReverseMap();
            CreateMap<UserAuthenticationSaveDto, UserAuthentication>().ReverseMap();

            CreateMap<User, UserUpdateDto>().ReverseMap();
            CreateMap<UserResponseDto, User>().ReverseMap();
            //CreateMap<UserSaveDto, UserAuthentication>().ReverseMap();


            CreateMap<VehicleType, VehicleTypeResponseDto>().ReverseMap();
            CreateMap<VehicleType, VehicleTypeSaveDto>().ReverseMap();
            CreateMap<VehicleType, VehicleTypeUpdateDto>().ReverseMap();

            CreateMap<Vehicle, VehicleResponseDto>().ReverseMap();
            CreateMap<Vehicle, VehicleSaveDto>().ReverseMap();
            CreateMap<Vehicle, VehicleUpdateDto>().ReverseMap();

            CreateMap<ActionType, ActionTypeResponseDto>().ReverseMap();
            CreateMap<ActionType, ActionTypeSaveDto>().ReverseMap();
            CreateMap<ActionType, ActionTypeUpdateDto>().ReverseMap();


            CreateMap<Maintenance, MaintenanceResponseDto>().ReverseMap();
            CreateMap<Maintenance, MaintenanceSaveDto>().ReverseMap();
            CreateMap<Maintenance, MaintenanceUpdateDto>().ReverseMap();

            CreateMap<MaintenanceHistory, MaintenanceHistoryResponseDto>().ReverseMap();
            CreateMap<MaintenanceHistory, MaintenanceHistorySaveDto>().ReverseMap();
            CreateMap<MaintenanceHistory, MaintenanceHistoryUpdateDto>().ReverseMap();

            CreateMap<PictureGroup, PictureGroupResponseDto>().ReverseMap();
            CreateMap<PictureGroup, PictureGroupSaveDto>().ReverseMap();
            CreateMap<PictureGroup, PictureGroupUpdateDto>().ReverseMap();

            CreateMap<Status, StatusResponseDto>().ReverseMap();
            CreateMap<Status, StatusUpdateDto>().ReverseMap();
            CreateMap<Status, StatusSaveDto>().ReverseMap();

        }
    }
}
