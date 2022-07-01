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
    public class PictureGroupUpdateValidatorFilter : Validator
    {
        public PictureGroupUpdateValidatorFilter(AppDbContext appDbContext) : base(appDbContext)
        {
            AddAvailableFilter<PictureGroup, PictureGroupUpdateDto>("ID", "ID");
            AddAvailableFilter<User, PictureGroupUpdateDto>("ID", "ModifiedBy");
        }
    }
}
