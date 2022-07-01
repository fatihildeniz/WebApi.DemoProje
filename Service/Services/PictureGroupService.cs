using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core.DTOs;
using WebApi.Core.DTOs.PictureGroupDtos;
using WebApi.Core.Entities;
using WebApi.Core.Repository;
using WebApi.Core.Services;
using WebApi.Core.UnitOfWorks;

namespace WebApi.Service.Services
{
    public class PictureGroupService : GenericService<PictureGroup>, IPictureGroupService
    {
        public PictureGroupService(IGenericRepository<PictureGroup> repository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
        }

        public CustomResponseDto Add(PictureGroupSaveDto saveDto)
        {
            try
            {
                PictureGroup pictureGroup = _mapper.Map<PictureGroup>(saveDto);
                pictureGroup.CreateDate = DateTime.Now;
                if (Add(pictureGroup) != null)
                {
                    PictureGroupResponseDto responseDto = _mapper.Map<PictureGroupResponseDto>(pictureGroup);
                    return new CustomResponseDto() { Data = responseDto, Message = "Success : [Data] contains created PictureGroup data", StatusCode = 201 };
                }

                return new CustomResponseDto() { Message = "Fail ", StatusCode = 500 };
            }
            catch (Exception e)
            {

                return new CustomResponseDto() { Message = "Fail " + e.Message, StatusCode = 500 };
            }
        }

        public CustomResponseDto Update(PictureGroupUpdateDto updateDto)
        {
            try
            {
                PictureGroup pictureGroup = _mapper.Map<PictureGroup>(updateDto);
                pictureGroup.ModifyDate = DateTime.Now;
                if (Update(pictureGroup) != null)
                {
                    PictureGroupResponseDto responseDto = _mapper.Map<PictureGroupResponseDto>(pictureGroup);
                    return new CustomResponseDto() { Data = responseDto, Message = "Success : [Data] contains updated PictureGroup data", StatusCode = 201 };
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
