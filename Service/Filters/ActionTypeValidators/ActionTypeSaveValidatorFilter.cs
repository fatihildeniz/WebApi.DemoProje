using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core.DTOs.ActionTypeDtos;
using WebApi.Core.Entities;
using WebApi.Repository;
using WebApi.Validation.Abstract;

namespace WebApi.Service.Filters.ActionTypeValidators
{
    public class ActionTypeSaveValidatorFilter : Validator
    {
        public ActionTypeSaveValidatorFilter(AppDbContext appDbContext) : base(appDbContext)
        {
            
            AddNotAvailableFilter<ActionType, ActionTypeSaveDto>("Name", "Name");
            
            AddAvailableFilter<User, ActionTypeSaveDto>("ID", "CreatedBy");
        }
    }
}
