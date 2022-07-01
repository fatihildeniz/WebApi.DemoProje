using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core.DTOs;
using WebApi.Core.DTOs.UserDtos;
using WebApi.Core.DTOs.VehicleTypeDtos;
using WebApi.Core.Entities;
using WebApi.Core.Repository;
using WebApi.Core.Services;
using WebApi.Core.UnitOfWorks;

namespace WebApi.Service.Services
{
    public class UserService : GenericService<User>, IUserService
    {
        
        public UserService(IGenericRepository<User> repository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            
        }

        
    }
}
