
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Core.DTOs.ActionTypeDtos;
using WebApi.Core.DTOs.MaintenanceDtos;
using WebApi.Core.DTOs.MaintenanceHistoryDtos;
using WebApi.Core.DTOs.PictureGroupDtos;
using WebApi.Core.DTOs.StatusDtos;
using WebApi.Core.Entities;
using WebApi.Core.Services;

using WebApi.Service.Filters.StatusValidators;

namespace WebApi.Demo2.Controllers
{
    [Route("api/[controller]")]
    //[Authorize(AuthenticationSchemes = "Basic", Roles = "admin")]
    public class StatusController : AppBaseController
    {
        private readonly IStatusService _service;
        


        public StatusController(IStatusService service)
        {
            _service = service;
        }



        [HttpPost]
        [Route("[action]")]
        [ServiceFilter(typeof(StatusSaveValidatorFilter))]
        public IActionResult Add(StatusSaveDto saveDto)
        {
            return CreateActionResult(_service.Add<StatusSaveDto,StatusResponseDto>(saveDto));
         }




        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            return CreateActionResult(_service.GetById<StatusResponseDto>(id));
        }



        [HttpPut]
        [Route("[action]")]
        [ServiceFilter(typeof(StatusUpdateValidatorFilter))]
        public IActionResult Update(StatusUpdateDto updateDto)
        {
            return CreateActionResult(_service.Update<StatusUpdateDto,StatusResponseDto>(updateDto));
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Remove(int id)
        {
            return CreateActionResult(_service.RemoveById(id));
        }



    }
}
