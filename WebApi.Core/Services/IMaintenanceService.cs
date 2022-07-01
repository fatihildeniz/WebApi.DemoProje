﻿using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core.DTOs;
using WebApi.Core.DTOs.MaintenanceDtos;
using WebApi.Core.Entities;

namespace WebApi.Core.Services
{
    public interface IMaintenanceService : IGenericService<Maintenance>
    {
        CustomResponseDto GetMaintenancesByResponsibleUserID(int id);
        
    }
}
