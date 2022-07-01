using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core.DTOs;
using WebApi.Core.DTOs.MaintenanceHistoryDtos;
using WebApi.Core.Entities;
using WebApi.Core.Repository;
using WebApi.Core.Services;
using WebApi.Core.UnitOfWorks;

namespace WebApi.Service.Services
{
    public class MaintenanceHistoryService : GenericService<MaintenanceHistory>, IMaintenanceHistoryService
    {
        public MaintenanceHistoryService(IGenericRepository<MaintenanceHistory> repository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {

        }

        public CustomResponseDto Add(MaintenanceHistorySaveDto saveDto)
        {
            try
            {
                MaintenanceHistory maintenanceHistory = _mapper.Map<MaintenanceHistory>(saveDto);
                maintenanceHistory.CreateDate = DateTime.Now;
                if (Add(maintenanceHistory) != null)
                {
                    MaintenanceHistoryResponseDto responseDto = _mapper.Map<MaintenanceHistoryResponseDto>(maintenanceHistory);
                    return new CustomResponseDto() { Data = responseDto, Message = "Success : [Data] contains created MaintenanceHistory data", StatusCode = 201 };
                }

                return new CustomResponseDto() { Message = "Fail ", StatusCode = 500 };
            }
            catch (Exception e)
            {

                return new CustomResponseDto() { Message = "Fail " + e.Message, StatusCode = 500 };
            }
        }

        public CustomResponseDto Update(MaintenanceHistoryUpdateDto updateDto)
        {
            try
            {
                MaintenanceHistory maintenanceHistory = _mapper.Map<MaintenanceHistory>(updateDto);
                maintenanceHistory.ModifyDate = DateTime.Now;
                if (Update(maintenanceHistory) != null)
                {
                    MaintenanceHistoryResponseDto responseDto = _mapper.Map<MaintenanceHistoryResponseDto>(maintenanceHistory);
                    return new CustomResponseDto() { Data = responseDto, Message = "Success : [Data] contains updated MaintenanceHistory data", StatusCode = 201 };
                }
                return new CustomResponseDto() { Message = "Fail", StatusCode = 500 };
            }
            catch (Exception e)
            {

                return new CustomResponseDto() { Message = "Fail " + e.Message, StatusCode = 500 };
            }
        }
    }
}
