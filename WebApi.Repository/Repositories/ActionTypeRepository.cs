using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core.Entities;
using WebApi.Core.Repository;

namespace WebApi.Repository.Repositories
{
    public class ActionTypeRepository : GenericRepository<ActionType>, IActionTypeRepository
    {
        public ActionTypeRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
