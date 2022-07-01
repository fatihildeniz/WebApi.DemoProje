using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core.Entities;
using WebApi.Core.Repository;

namespace WebApi.Repository.Repositories
{
    public class PictureGroupRepository : GenericRepository<PictureGroup>, IPictureGroupRepository
    {
        public PictureGroupRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
