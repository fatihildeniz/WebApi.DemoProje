using WebApi.Core.DTOs.UserDtos;
using WebApi.Core.Entities;
using WebApi.Repository;
using WebApi.Validation.Abstract;
namespace WebApi.Service.Filters.UserValidators
{
    public class UserSaveValidatorFilter : Validator
    {
        public UserSaveValidatorFilter(AppDbContext appDbContext) : base(appDbContext)
        {

            AddNotAvailableFilter<UserAuthentication, UserSaveDto>("UserName", "UserName");
            AddAvailableFilter<User, UserSaveDto>("ID", "CreatedBy");

        }
    }
}
