using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        public Task<int> CommitAsync();
        public int Commit();
    }
}
