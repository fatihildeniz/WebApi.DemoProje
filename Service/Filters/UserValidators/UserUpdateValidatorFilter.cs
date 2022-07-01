using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core.DTOs.UserDtos;
using WebApi.Core.Entities;
using WebApi.Repository;
using WebApi.Validation.Abstract;

namespace WebApi.Service.Filters.UserValidators
{
    public class UserUpdateValidatorFilter : Validator
    {
        public UserUpdateValidatorFilter(AppDbContext appDbContext) : base(appDbContext)
        {
            AddAvailableFilter<User, UserUpdateDto>("ID", "ID");
            AddAvailableFilter<User, UserUpdateDto>("ID", "ModifiedBy");
        }
    }
}
