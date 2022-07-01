using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core.DTOs;
using WebApi.Core.DTOs.PictureGroupDtos;
using WebApi.Core.Entities;

namespace WebApi.Core.Services
{
    public interface IPictureGroupService : IGenericService<PictureGroup>
    {
        CustomResponseDto Add(PictureGroupSaveDto saveDto);
        CustomResponseDto Update(PictureGroupUpdateDto updateDto);
    }
}
