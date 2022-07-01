
using WebApi.Core.DTOs;
using WebApi.Core.DTOs.StatusDtos;
using WebApi.Core.Entities;

namespace WebApi.Core.Services
{
    public interface IStatusService : IGenericService<Status>
    {
        CustomResponseDto Add(StatusSaveDto saveDto);
        CustomResponseDto Update(StatusUpdateDto updateDto);
    }
}
