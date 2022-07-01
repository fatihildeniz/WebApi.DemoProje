using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core.Entities;

namespace WebApi.Core.Repository
{
    public interface IMaintenanceRepository:IGenericRepository<Maintenance>
    {
        public IEnumerable<Maintenance> GetMaintenancesByResponsibleUserID(int responsibleUserID);
        public IEnumerable<Maintenance> GetMaintenancesByUserID(int userID);
       
       
    }
}
