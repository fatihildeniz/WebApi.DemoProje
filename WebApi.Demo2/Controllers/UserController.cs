using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApi.Core.DTOs.UserDtos;
using WebApi.Core.Entities;
using WebApi.Core.Services;
using WebApi.Demo2.Filters;

using WebApi.Service.Filters;
using WebApi.Service.Filters.UserValidators;
using WebApi.Service.Services;

namespace WebApi.Demo2.Controllers
{
    [Route("api/[controller]")]
    //[Authorize(AuthenticationSchemes = "Basic", Roles = "admin")]
    public class UserController : AppBaseController
    {
        private readonly IUserService _service;
        private readonly IAuthorizationService _authorizationService;


        public UserController(IUserService service, IAuthorizationService authorizationService)
        {
            _service = service;
            _authorizationService = authorizationService;
        }



        [HttpPost]
        [Route("[action]")]
        [ServiceFilter(typeof(UserSaveValidatorFilter))]
        
        public IActionResult Add(UserSaveDto userSaveDto)
        {

            return CreateActionResult(_service.Add<UserSaveDto,UserResponseDto>(userSaveDto));
         }




        [HttpGet]
        [Route("{id}")]
        
        public IActionResult Get(int id)
        {
            return CreateActionResult(_service.GetById<UserResponseDto>(id));
        }



        [HttpPut]
        [Route("[action]")]
        [ServiceFilter(typeof(UserUpdateValidatorFilter))]
        public IActionResult Update(UserUpdateDto updateDto)
        {
            return CreateActionResult(_service.Update<UserUpdateDto,UserResponseDto>(updateDto));
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Remove(int id)
        {
            return CreateActionResult(_service.RemoveById(id));
        }



    }
}
