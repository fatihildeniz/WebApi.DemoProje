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
    public class ActionTypeUpdateValidatorFilter : Validator
    {
        public ActionTypeUpdateValidatorFilter(AppDbContext appDbContext) : base(appDbContext)
        {
            AddAvailableFilter<ActionType, ActionTypeUpdateDto>("ID", "ID");
            AddNotAvailableFilter<ActionType, ActionTypeUpdateDto>("Name", "Name");
            AddAvailableFilter<User, ActionTypeUpdateDto>("ID", "ModifiedBy");
        }
    }
}
