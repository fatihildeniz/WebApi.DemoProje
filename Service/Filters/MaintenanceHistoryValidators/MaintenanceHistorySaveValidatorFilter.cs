using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core.DTOs.MaintenanceHistoryDtos;
using WebApi.Core.Entities;
using WebApi.Repository;
using WebApi.Validation.Abstract;

namespace WebApi.Service.Filters.MaintenanceHistoryValidators
{
    public class MaintenanceHistorySaveValidatorFilter : Validator
    {
        public MaintenanceHistorySaveValidatorFilter(AppDbContext appDbContext) : base(appDbContext)
        {
            AddAvailableFilter<User, MaintenanceHistorySaveDto>("ID", "CreatedBy");
            AddAvailableFilter<ActionType, MaintenanceHistorySaveDto>("ID", "ActionTypeID");
            AddAvailableFilter<Maintenance, MaintenanceHistorySaveDto>("ID", "MaintenanceID");
        }
    }
}
