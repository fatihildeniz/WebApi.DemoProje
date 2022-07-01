using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core.DTOs.PictureGroupDtos;
using WebApi.Core.Entities;
using WebApi.Repository;
using WebApi.Validation.Abstract;

namespace WebApi.Service.Filters.PictureGroupValidators
{
    public class PictureGroupSaveValidatorFilter : Validator
    {
        public PictureGroupSaveValidatorFilter(AppDbContext appDbContext) : base(appDbContext)
        {
            AddAvailableFilter<User, PictureGroupSaveDto>("ID", "CreatedBy");
        }
    }
}
