using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core.DTOs;
using WebApi.Core.Entities;
using WebApi.Core.Repository;
using WebApi.Core.Services;
using WebApi.Core.UnitOfWorks;
using WebApi.Repository;
using WebApi.Repository.UnitOfWorks;
using WebApi.Service.Services;

namespace WebApi.Service
{
    public class UserAuthenticationService : GenericService<UserAuthentication>, IUserAuthenticationService
    {
        public UserAuthenticationService(IGenericRepository<UserAuthentication> repository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
        }

        
    }
}
