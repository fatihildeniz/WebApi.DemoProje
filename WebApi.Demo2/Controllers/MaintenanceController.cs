
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Core.DTOs.ActionTypeDtos;
using WebApi.Core.DTOs.MaintenanceDtos;
using WebApi.Core.DTOs.MaintenanceHistoryDtos;
using WebApi.Core.Entities;
using WebApi.Core.Services;
using WebApi.Service.Filters.MaintenanceValidators;

namespace WebApi.Demo2.Controllers
{
    [Route("api/[controller]")]
    //[Authorize(AuthenticationSchemes = "Basic", Roles = "admin")]
    public class MaintenanceController : AppBaseController
    {
        private readonly IMaintenanceService _service;
        


        public MaintenanceController(IMaintenanceService service)
        {
            _service = service;
        }



        [HttpPost]
        [Route("[action]")]
        [ServiceFilter(typeof(MaintenanceSaveValidatorFilter))]
        public IActionResult Add(MaintenanceSaveDto saveDto)
        {
            return CreateActionResult(_service.Add<MaintenanceSaveDto,MaintenanceResponseDto>(saveDto));
         }




        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            return CreateActionResult(_service.GetById<MaintenanceResponseDto>(id));
        }

        [HttpGet]
        [Route("[Action]/{id}")]
        public IActionResult GetByResponsibleUserId(int id)
        {
            return CreateActionResult(_service.GetMaintenancesByResponsibleUserID(id));
        }


        [HttpPut]
        [Route("[action]")]
        [ServiceFilter(typeof(MaintenanceUpdateValidatorFilter))]
        public IActionResult Update(MaintenanceUpdateDto updateDto)
        {
            return CreateActionResult(_service.Update<MaintenanceUpdateDto,MaintenanceResponseDto>(updateDto));
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Remove(int id)
        {
            return CreateActionResult(_service.RemoveById(id));
        }



    }
}
