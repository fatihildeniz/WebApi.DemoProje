using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApi.Core.DTOs.UserDtos;
using WebApi.Core.DTOs.VehicleTypeDtos;
using WebApi.Core.Entities;
using WebApi.Core.Services;
using WebApi.Demo2.Filters;
using WebApi.Service.Filters.VehicleTypeValidators;

namespace WebApi.Demo2.Controllers
{
    [Route("api/[controller]")]
    //[Authorize(AuthenticationSchemes = "Basic", Roles = "admin")]
    public class VehicleTypeController : AppBaseController
    {
        private readonly IVehicleTypeService _service;
        


        public VehicleTypeController(IVehicleTypeService service)
        {
            _service = service;
        }



        [HttpPost]
        [Route("[action]")]
        [ServiceFilter(typeof(VehicleTypeSaveValidatorFilter))]
        public IActionResult Add(VehicleTypeSaveDto saveDto)
        {
            return CreateActionResult(_service.Add<VehicleTypeSaveDto,VehicleTypeResponseDto>(saveDto));
         }




        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            return CreateActionResult(_service.GetById<VehicleTypeResponseDto>(id));
        }



        [HttpPut]
        [Route("[action]")]
        [ServiceFilter(typeof(VehicleTypeUpdateValidatorFilter))]
        public IActionResult Update(VehicleTypeUpdateDto updateDto)
        {
            return CreateActionResult(_service.Update<VehicleTypeUpdateDto,VehicleTypeResponseDto>(updateDto));
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Remove(int id)
        {
            return CreateActionResult(_service.RemoveById(id));
        }



    }
}
