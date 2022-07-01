
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Core.DTOs.ActionTypeDtos;
using WebApi.Core.Entities;
using WebApi.Core.Services;
using WebApi.Service.Filters.ActionTypeValidators;

namespace WebApi.Demo2.Controllers
{
    [Route("api/[controller]")]
    //[Authorize(AuthenticationSchemes = "Basic", Roles = "admin")]
    public class ActionTypeController : AppBaseController
    {
        private readonly IActionTypeService _service;
        


        public ActionTypeController(IActionTypeService service)
        {
            _service = service;
        }



        [HttpPost]
        [Route("[action]")]
        [ServiceFilter(typeof(ActionTypeSaveValidatorFilter))]
        public IActionResult Add(ActionTypeSaveDto saveDto)
        {
            return CreateActionResult(_service.Add<ActionTypeSaveDto,ActionTypeResponseDto>(saveDto));
         }




        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            return CreateActionResult(_service.GetById<ActionTypeResponseDto>(id));
        }



        [HttpPut]
        [Route("[action]")]
        [ServiceFilter(typeof(ActionTypeUpdateValidatorFilter))]
        public IActionResult Update(ActionTypeUpdateDto updateDto)
        {
            return CreateActionResult(_service.Update<ActionTypeUpdateDto,ActionTypeResponseDto>(updateDto));
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Remove(int id)
        {
            return CreateActionResult(_service.RemoveById(id));
        }



    }
}
