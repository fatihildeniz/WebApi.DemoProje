using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core.Entities;
using WebApi.Core.Repository;

namespace WebApi.Repository.Repositories
{
    public class VehicleTypeRepository : GenericRepository<VehicleType>, IVehicleTypeRepository
    {
        public VehicleTypeRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
