using WebApi.Core.DTOs;
using WebApi.Core.DTOs.ActionTypeDtos;
using WebApi.Core.Entities;

namespace WebApi.Core.Services
{
    public interface IActionTypeService : IGenericService<ActionType>
    {
        CustomResponseDto Add(ActionTypeSaveDto saveDto);
        CustomResponseDto Update(ActionTypeUpdateDto updateDto);

        //CustomResponseDto DeleteActionType(int id);
        //CustomResponseDto GetActionType(int id);
    }
}
