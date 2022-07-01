using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core.Entities;
using WebApi.Core.Repository;

namespace WebApi.Repository.Repositories
{
    public class StatusRepository : GenericRepository<Status>, IStatusRepository
    {
        public StatusRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
