using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core.DTOs;
using WebApi.Core.DTOs.MaintenanceHistoryDtos;
using WebApi.Core.Entities;

namespace WebApi.Core.Services
{
    public interface IMaintenanceHistoryService : IGenericService<MaintenanceHistory>
    {
        CustomResponseDto Add(MaintenanceHistorySaveDto saveDto);
        CustomResponseDto Update(MaintenanceHistoryUpdateDto updateDto);
    }
}
