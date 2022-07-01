using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core.DTOs;
using WebApi.Core.DTOs.StatusDtos;
using WebApi.Core.Entities;
using WebApi.Core.Repository;
using WebApi.Core.Services;
using WebApi.Core.UnitOfWorks;

namespace WebApi.Service.Services
{
    public class StatusService : GenericService<Status>, IStatusService
    {
        public StatusService(IGenericRepository<Status> repository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
        }

        public CustomResponseDto Add(StatusSaveDto saveDto)
        {
            try
            {
                Status status = _mapper.Map<Status>(saveDto);
                status.CreateDate = DateTime.Now;
                if (Add(status) != null)
                {
                    StatusResponseDto responseDto = _mapper.Map<StatusResponseDto>(status);
                    return new CustomResponseDto() { Data = responseDto, Message = "Success : [Data] contains created Status data", StatusCode = 201 };
                }

                return new CustomResponseDto() { Message = "Fail ", StatusCode = 500 };
            }
            catch (Exception e)
            {

                return new CustomResponseDto() { Message = "Fail " + e.Message, StatusCode = 500 };
            }
        }

        public CustomResponseDto Update(StatusUpdateDto updateDto)
        {
            try
            {
                Status status = _mapper.Map<Status>(updateDto);
                status.ModifyDate = DateTime.Now;
                if (Update(status) != null)
                {
                    StatusResponseDto responseDto = _mapper.Map<StatusResponseDto>(status);
                    return new CustomResponseDto() { Data = responseDto, Message = "Success : [Data] contains updated Status data", StatusCode = 201 };
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
