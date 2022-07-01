using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core.Entities;
using WebApi.Core.Repository;

namespace WebApi.Repository.Repositories
{
    public class MaintenanceHistoryRepository : GenericRepository<MaintenanceHistory>, IMaintenanceHistoryRepository
    {
        public MaintenanceHistoryRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
