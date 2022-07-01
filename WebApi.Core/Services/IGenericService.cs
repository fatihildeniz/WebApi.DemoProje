using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApi.Core.DTOs;

namespace WebApi.Core.Services
{
    public enum IsAvailableResponse
    {
        NotAvailable = 0,
        Available = 1,
        ServerError = 2
    }
    public interface IGenericService<TEntity> where TEntity:class  
    {
        TEntity GetById(int id);
        CustomResponseDto GetById<TResponseDto>(int id) where TResponseDto : class;
        CustomResponseDto Get<TResponseDto>(Expression<Func<TEntity,bool>> expression) where TResponseDto : class;
        List<TEntity> Get(Expression<Func<TEntity, bool>> expression);
        CustomResponseDto Add<TSaveDto,TResponseDto>(TSaveDto saveDto) where TSaveDto : class where TResponseDto : class;
        TEntity Add(TEntity entity);
        CustomResponseDto AddRange<TSaveDto, TResponseDto>(IEnumerable<TSaveDto> saveDtos) where TSaveDto : class where TResponseDto: class;
        List<TEntity> AddRange(List<TEntity> entities);
        CustomResponseDto Update<TUpdateDto,TResponseDto>(TUpdateDto updateDto) where TUpdateDto : class where TResponseDto : class;
        TEntity Update(TEntity entity);
        CustomResponseDto RemoveById(int id);
        CustomResponseDto RemoveRange<TUpdateDto>(IEnumerable<TUpdateDto> updateDtos) where TUpdateDto : class;

        IsAvailableResponse IsAvailable(Expression<Func<TEntity, bool>> expression);

     }
}
