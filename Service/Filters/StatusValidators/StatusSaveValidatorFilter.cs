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
    public class StatusSaveValidatorFilter : Validator
    {
        public StatusSaveValidatorFilter(AppDbContext appDbContext) : base(appDbContext)
        {
            AddAvailableFilter<User, StatusSaveDto>("ID", "CreatedBy");
            AddNotAvailableFilter<Status, StatusSaveDto>("Name", "Name");
        }
    }
}
