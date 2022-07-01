using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core.Entities;
using WebApi.Core.Repository;

namespace WebApi.Repository.Repositories
{
    public class VehicleRepository : GenericRepository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
