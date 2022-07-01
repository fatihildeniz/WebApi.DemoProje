
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Core.DTOs.ActionTypeDtos;
using WebApi.Core.DTOs.MaintenanceHistoryDtos;
using WebApi.Core.Entities;
using WebApi.Core.Services;
using WebApi.Service.Filters.MaintenanceHistoryValidators;

namespace WebApi.Demo2.Controllers
{
    [Route("api/[controller]")]
    //[Authorize(AuthenticationSchemes = "Basic", Roles = "admin")]
    public class MaintenanceHistoryController : AppBaseController
    {
        private readonly IMaintenanceHistoryService _service;
        


        public MaintenanceHistoryController(IMaintenanceHistoryService service)
        {
            _service = service;
        }



        [HttpPost]
        [Route("[action]")]
        [ServiceFilter(typeof(MaintenanceHistorySaveValidatorFilter))]
        public IActionResult Add(MaintenanceHistorySaveDto saveDto)
        {
            return CreateActionResult(_service.Add<MaintenanceHistorySaveDto,MaintenanceHistoryResponseDto>(saveDto));
         }




        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            return CreateActionResult(_service.GetById<MaintenanceHistoryResponseDto>(id));
        }



        [HttpPut]
        [Route("[action]")]
        [ServiceFilter(typeof(MaintenanceHistoryUpdateValidatorFilter))]
        public IActionResult Update(MaintenanceHistoryUpdateDto updateDto)
        {
            return CreateActionResult(_service.Update<MaintenanceHistoryUpdateDto,MaintenanceHistoryResponseDto>(updateDto));
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Remove(int id)
        {
            return CreateActionResult(_service.RemoveById(id));
        }



    }
}
