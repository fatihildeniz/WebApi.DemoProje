using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core.UnitOfWorks;

namespace WebApi.Repository.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _appDbContext;

        public UnitOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public int Commit()
        {
            return _appDbContext.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
           return await _appDbContext.SaveChangesAsync();
        }
    }
}
