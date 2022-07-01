using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core.DTOs.StatusDtos;
using WebApi.Core.Entities;
using WebApi.Repository;
using WebApi.Validation.Abstract;

namespace WebApi.Service.Filters.StatusValidators
{
    public class StatusUpdateValidatorFilter : Validator
    {
        public StatusUpdateValidatorFilter(AppDbContext appDbContext) : base(appDbContext)
        {
            AddAvailableFilter<User, StatusUpdateDto>("ID", "ModifiedBy");
            AddNotAvailableFilter<Status, StatusUpdateDto>("Name", "Name");
            AddNotAvailableFilter<Status, StatusUpdateDto>("ID", "ID");
        }
    }
}
