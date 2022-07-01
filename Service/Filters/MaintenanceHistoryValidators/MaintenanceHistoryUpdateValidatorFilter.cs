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
    public class MaintenanceHistoryUpdateValidatorFilter : Validator
    {
        public MaintenanceHistoryUpdateValidatorFilter(AppDbContext appDbContext) : base(appDbContext)
        {
            AddAvailableFilter<MaintenanceHistory, MaintenanceHistoryUpdateDto>("ID", "ID");
            AddAvailableFilter<User, MaintenanceHistoryUpdateDto>("ID", "ModifiedBy");
            AddAvailableFilter<ActionType, MaintenanceHistoryUpdateDto>("ID", "ActionTypeID");
            AddAvailableFilter<Maintenance, MaintenanceHistoryUpdateDto>("ID", "MaintenanceID");
        }
    }
}
