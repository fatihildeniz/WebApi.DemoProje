using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApi.Core.DTOs.UserDtos;
using WebApi.Core.DTOs.VehicleDtos;
using WebApi.Core.DTOs.VehicleTypeDtos;
using WebApi.Core.Entities;
using WebApi.Core.Services;
using WebApi.Demo2.Filters;
using WebApi.Service.Filters.VehicleValidators;

namespace WebApi.Demo2.Controllers
{
    [Route("api/[controller]")]
    //[Authorize(AuthenticationSchemes = "Basic", Roles = "admin")]
    public class VehicleController : AppBaseController
    {
        private readonly IVehicleService _service;
        


        public VehicleController(IVehicleService service)
        {
            _service = service;
        }



        [HttpPost]
        [Route("[action]")]
        [ServiceFilter(typeof(VehicleSaveValidatorFilter))]
        public IActionResult Add(VehicleSaveDto saveDto)
        {
            return CreateActionResult(_service.Add<VehicleSaveDto,VehicleResponseDto>(saveDto));
         }




        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            return CreateActionResult(_service.GetById<VehicleResponseDto>(id));
        }



        [HttpPut]
        [Route("[action]")]
        [ServiceFilter(typeof(VehicleUpdateValidatorFilter))]
        public IActionResult Update(VehicleUpdateDto updateDto)
        {
            return CreateActionResult(_service.Update<VehicleUpdateDto,VehicleResponseDto>(updateDto));
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Remove(int id)
        {
            return CreateActionResult(_service.RemoveById(id));
        }



    }
}
