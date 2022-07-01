using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core.Entities;
using WebApi.Core.Repository;

namespace WebApi.Repository.Repositories
{
    public class MaintenanceRepository : GenericRepository<Maintenance>, IMaintenanceRepository
    {
        public MaintenanceRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Maintenance> GetMaintenancesByResponsibleUserID(int responsibleUserID)
        {
            return _dbSet.Where(x => x.ResponsibleUserID == responsibleUserID)
                .Include(x => x.PictureGroup)
                .Include(x => x.Status)
                .Include(x => x.Vehicle)
                .ThenInclude(x => x.VehicleType)
                .Include(x => x.MaintenanceHistories)
                .ThenInclude(x => x.ActionType).ToList();
        }

        public IEnumerable<Maintenance> GetMaintenancesByUserID(int userID)
        {
            return _dbSet.Where(x=> x.UserID==userID).ToList();
        }

        
    }
}
