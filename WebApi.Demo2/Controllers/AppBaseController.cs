using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Core.DTOs;

namespace WebApi.Demo2.Controllers
{
    
    [ApiController]
    public class AppBaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult(CustomResponseDto response)
        {
            if(response.StatusCode == 204)
            {
               return new ObjectResult(null) { StatusCode = response.StatusCode };
            }
            
            return new ObjectResult(response) { StatusCode = response.StatusCode};
        }
    }
}
