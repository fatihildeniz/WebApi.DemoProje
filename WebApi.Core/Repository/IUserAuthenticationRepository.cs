using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core.DTOs;
using WebApi.Core.Entities;

namespace WebApi.Core.Repository
{
    public interface IUserAuthenticationRepository
    {
        public IQueryable<UserAuthentication> GetUser(string name, string password);
        public Task Add(UserAuthentication userAuthentication);


    }
}
