using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WebApi.Core.DTOs;
using WebApi.Core.DTOs.MaintenanceDtos;
using WebApi.Core.Entities;
using WebApi.Core.Repository;
using WebApi.Core.Services;
using WebApi.Core.UnitOfWorks;

namespace WebApi.Service.Services
{
    public class MaintenanceService : GenericService<Maintenance>, IMaintenanceService
    {
        protected readonly IMaintenanceRepository _repository;
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _unitOfWork;
        public MaintenanceService(IMaintenanceRepository repository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, unitOfWork, mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public CustomResponseDto GetMaintenancesByResponsibleUserID(int id)
        {
            return new CustomResponseDto() { Data=_repository.GetMaintenancesByResponsibleUserID(id) };
        }
    }
}
