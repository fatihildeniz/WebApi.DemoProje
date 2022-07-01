using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core.Entities;

namespace WebApi.Core.Repository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        User GetResponsibleUserWithMaintenances(int id);
        
    }
}
