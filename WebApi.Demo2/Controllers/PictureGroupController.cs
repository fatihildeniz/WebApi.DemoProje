
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Core.DTOs.ActionTypeDtos;
using WebApi.Core.DTOs.MaintenanceDtos;
using WebApi.Core.DTOs.MaintenanceHistoryDtos;
using WebApi.Core.DTOs.PictureGroupDtos;
using WebApi.Core.Entities;
using WebApi.Core.Services;
using WebApi.Service.Filters.PictureGroupValidators;

namespace WebApi.Demo2.Controllers
{
    [Route("api/[controller]")]
    //[Authorize(AuthenticationSchemes = "Basic", Roles = "admin")]
    public class PictureGroupController : AppBaseController
    {
        private readonly IPictureGroupService _service;
        


        public PictureGroupController(IPictureGroupService service)
        {
            _service = service;
        }



        [HttpPost]
        [Route("[action]")]
        [ServiceFilter(typeof(PictureGroupSaveValidatorFilter))]
        public IActionResult Add(PictureGroupSaveDto saveDto)
        {
            return CreateActionResult(_service.Add<PictureGroupSaveDto,PictureGroupResponseDto>(saveDto));
         }




        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            return CreateActionResult(_service.GetById<PictureGroupResponseDto>(id));
        }



        [HttpPut]
        [Route("[action]")]
        [ServiceFilter(typeof(PictureGroupUpdateValidatorFilter))]
        public IActionResult Update(PictureGroupUpdateDto updateDto)
        {
            return CreateActionResult(_service.Update<PictureGroupUpdateDto,PictureGroupResponseDto>(updateDto));
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Remove(int id)
        {
            return CreateActionResult(_service.RemoveById(id));
        }



    }
}
