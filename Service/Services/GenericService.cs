using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core.DTOs;
using WebApi.Core.Entities;
using WebApi.Core.Repository;
using WebApi.Core.Services;
using WebApi.Core.UnitOfWorks;

namespace WebApi.Service.Services
{
    public class GenericService<TEntity> : IGenericService<TEntity> where TEntity:class
    {
        protected readonly IGenericRepository<TEntity> _repository;
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IMapper _mapper;

        

        public GenericService(IGenericRepository<TEntity> repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public CustomResponseDto Add<TSaveDto,TResponseDto>(TSaveDto saveDto) where TSaveDto : class where TResponseDto : class
        {
            try
            {
                TEntity entity = _mapper.Map<TSaveDto,TEntity>(saveDto);
                entity.GetType().GetProperty("ModifiedBy").SetValue(entity, entity.GetType().GetProperty("CreatedBy").GetValue(entity));
                entity.GetType().GetProperty("CreateDate").SetValue(entity,DateTime.Now);
                entity.GetType().GetProperty("ModifyDate").SetValue(entity, entity.GetType().GetProperty("CreateDate").GetValue(entity));
                _repository.Add(entity);
                if(_unitOfWork.Commit()>0)
                {
                    TResponseDto responseSaveDto = _mapper.Map<TResponseDto>(entity);
                    return new CustomResponseDto() { Data = responseSaveDto, Message = "Success: Data contains new created data.", StatusCode = 201 };
                }
                    

                throw new Exception("Server Error");
            }
            catch (Exception e) 
            {
                return new CustomResponseDto() { Message = e.Message, StatusCode = 500 };
            }
            
        }

        public TEntity Add(TEntity entity)
        {
            try
            {
                _repository.Add(entity);
                if (_unitOfWork.Commit() > 0)
                {
                    
                    return entity;
                }
                else
                {
                    return null;
                }

                throw new Exception("Server Error");
            }
            catch (Exception)
            {
                return null;
            }
        }

        public CustomResponseDto AddRange<TSaveDto,TResponseDto>(IEnumerable<TSaveDto> saveDtos) where TSaveDto : class where TResponseDto : class
        {
            try
            {
                List<TEntity> entities = _mapper.Map<List<TEntity>>(saveDtos);
                foreach (var entity in entities)
                {
                    entity.GetType().GetProperty("CreateDate").SetValue(entity, DateTime.Now);
                }
                _repository.AddRange(entities);
                if (_unitOfWork.Commit() > 0)
                {
                    List<TResponseDto> responseDtos = _mapper.Map<List<TResponseDto>>(entities);
                    return new CustomResponseDto() { Data = responseDtos, Message = "Success: Data contains new created data.", StatusCode = 201 };
                }
                    

                throw new Exception("Server Error");
            }
            catch (Exception e)
            {
                return new CustomResponseDto() { Message = e.Message, StatusCode = 500 };
            }
        }

        public List<TEntity> AddRange(List<TEntity> entities)
        {
            try
            {
                _repository.AddRange(entities);
                if (_unitOfWork.Commit() > 0)
                {
                    
                    return entities;
                }

                return null;
                
            }
            catch 
            {
                return null;
            }
        }

        public CustomResponseDto Get<TResponseDto>(Expression<Func<TEntity, bool>> expression) where TResponseDto : class
        {
            try
            {
                List<TEntity> entities = _repository.Get(expression);

                if (entities.Count > 0)
                {
                    List<TResponseDto> responseDtos = _mapper.Map<List<TResponseDto>>(entities);
                    return new CustomResponseDto() { Data = responseDtos, Message = "Success: Data contains data.", StatusCode = 201 };
                }
                else
                {
                    return new CustomResponseDto() { Message = "Null: Data not found", StatusCode = 204 };
                }

                throw new Exception("Server Error");
            }
            catch (Exception e)
            {
                return new CustomResponseDto() { Message = e.Message, StatusCode = 500 };
            }
        }

        public List<TEntity> Get(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                List<TEntity> entities = _repository.Get(expression);

                if (entities.Count > 0)
                {
                    return entities;
                }
                else
                {
                    return null;
                }

            }
            catch 
            {
                return null;
            }
        }

        public CustomResponseDto GetById<TResponseDto>(int id) where TResponseDto : class
        {
            try
            {
                TEntity entity = _repository.GetById(id);

                if (entity!=null && (bool)entity.GetType().GetProperty("IsDeleted").GetValue(entity)!=true)
                {
                    TResponseDto responseDto = _mapper.Map<TResponseDto>(entity);
                    return new CustomResponseDto() { Data = responseDto, Message = "Success: Data contains data.", StatusCode = 201 };
                }
                else
                {
                    return new CustomResponseDto() { Message = "Null: Data not found", StatusCode = 204 };
                }

                throw new Exception("Server Error");
            }
            catch (Exception e)
            {
                return new CustomResponseDto() { Message = e.Message, StatusCode = 500 };
            }
        }

        public TEntity GetById(int id)
        {
            try
            {
                TEntity entity = _repository.GetById(id);

                if (entity != null)
                {
                    return entity;
                }
                else
                {
                    return null;
                }

                
            }
            catch 
            {
                return null;
            }
        }

        public IsAvailableResponse IsAvailable(Expression<Func<TEntity, bool>> expression)
        {
            try
            {
                if (_repository.Get(expression).Count > 0)
                {
                    return IsAvailableResponse.Available;
                }
                return IsAvailableResponse.NotAvailable;
            }
            catch (Exception)
            {

                return IsAvailableResponse.ServerError;
            }
            
            
        }

        public CustomResponseDto RemoveById(int id)
        {
            try
            {
                TEntity entity = _repository.GetById(id);
                
                if(entity!=null)
                {
                    entity.GetType().GetProperty("IsDeleted").SetValue(entity, true);
                    _repository.Update(entity);
                    if (_unitOfWork.Commit() > 0)
                    {
                        return new CustomResponseDto() { Message = "Success : Data deleted", StatusCode = 204 };
                    }

                    throw new Exception("Server Error");
                }
                else
                {
                    return new CustomResponseDto() { Message = "Null : Data not found", StatusCode = 204 };
                }
            }
            catch (Exception e)
            {

                return new CustomResponseDto() { Message = e.Message, StatusCode = 500 };
            }
            
        }

        public CustomResponseDto RemoveRange<TUpdateDto>(IEnumerable<TUpdateDto> updateDtos) where TUpdateDto : class
        {
            try
            {
                List<TEntity> entities = _mapper.Map<List<TEntity>>(updateDtos);
                foreach(TEntity entity in entities)
                {
                    entity.GetType().GetProperty("IsDeleted").SetValue(entity, true);
                }
                _repository.UpdateRange(entities);
                if (_unitOfWork.Commit()>0)
                {
                    return new CustomResponseDto() { Message = "Success : Data deleted", StatusCode = 204 };
                }
                throw new Exception("Server Error");
            }
            catch (Exception e)
            {

                return new CustomResponseDto() { Message = e.Message, StatusCode = 500 };
            }
        }

        public CustomResponseDto Update<TUpdateDto,TResponseDto>(TUpdateDto updateDto) where TUpdateDto : class where TResponseDto : class
        {
            try
            {
                TEntity entity = _repository.GetById((int)updateDto.GetType().GetProperty("ID").GetValue(updateDto));
                if((bool)entity.GetType().GetProperty("IsDeleted").GetValue(entity)==true)
                {
                    return new CustomResponseDto() {Message = "Data not found", StatusCode = 204 };
                }
                _mapper.Map(updateDto,entity);
                entity.GetType().GetProperty("ModifyDate").SetValue(entity,DateTime.Now);
                _repository.Update(entity);
                if(_unitOfWork.Commit()>0)
                {
                    TResponseDto responseDto = _mapper.Map<TResponseDto>(entity);
                    return new CustomResponseDto() {Data=responseDto, Message = "Success : [Data] contains updated entity data", StatusCode = 201 };
                }

                throw new Exception("Server Error");
            }
            catch (Exception e)
            {

                return new CustomResponseDto() { Message = e.Message, StatusCode = 500 };
            }
            
        }

        public TEntity Update(TEntity entity)
        {
            try
            {
                _repository.Update(entity);
                if (_unitOfWork.Commit() > 0)
                {
                    
                    return entity;
                }
                else
                {
                    return null;
                }

            }
            catch
            {

                return null;
            }
        }
    }
}
