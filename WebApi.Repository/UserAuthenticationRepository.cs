using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core.DTOs;
using WebApi.Core.Entities;
using WebApi.Core.Repository;

namespace WebApi.Repository
{
    public class UserAuthenticationRepository : IUserAuthenticationRepository
    {
        private readonly AppDbContext _appDbContext;
        private readonly DbSet<UserAuthentication> _dbSet;

        public UserAuthenticationRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            _dbSet = _appDbContext.Set<UserAuthentication>();
        }




        public IQueryable<UserAuthentication> GetUser(string name, string password)
        {
           return _dbSet.Where(x => x.UserName == name && x.Password == password);
         }

        public async Task Add(UserAuthentication authentication)
        {
            await _dbSet.AddAsync(authentication);
        }
    }
}
