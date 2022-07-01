
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

using WebApi.Core.DTOs;
using WebApi.Repository;

namespace WebApi.Validation.Abstract
{
    public abstract class Validator : IActionFilter
    {
        private readonly AppDbContext _dbContext;
        private List<string> _validationMessages;
        

        private Action<string, object> _withValueAction = null;
        private Action<object, string, string> _withDtoAction = null;

        private List<object[]> _withValueActionArgs;
        private List<object[]> _withDtoActionArgs;

        private List<KeyValuePair<string,object>> _dtoObjects;

       
        public Validator(AppDbContext appDbContext)
        {
            _validationMessages = new List<string>();
            _withValueActionArgs = new List<object[]>();
            _withDtoActionArgs = new List<object[]>();

            
            _dbContext = appDbContext;
           
            
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _dtoObjects = filterContext.ActionArguments.ToList();

            if(_withValueAction!=null)
            {
                for (int i = 0; i < _withValueAction.GetInvocationList().Length; i++)
                {
                    var action = _withValueAction.GetInvocationList()[i];
                    action.DynamicInvoke(_withValueActionArgs[i][0], _withValueActionArgs[i][1]);
                }
            }
            
            foreach (var dtoObject in _dtoObjects)
            {
                if (_withDtoAction != null)
                {
                    for (int i = 0; i < _withDtoAction.GetInvocationList().Length; i++)
                    {
                        var action = _withDtoAction.GetInvocationList()[i];
                        action.DynamicInvoke(dtoObject, _withDtoActionArgs[i][0], _withDtoActionArgs[i][1].ToString());
                    }
                }
            }
            
            

            if (_validationMessages.Count > 0)
            {
                filterContext.Result = new ObjectResult(new CustomResponseDto() { Data = _validationMessages, Message = "Filter response", StatusCode = 404 });
            }
            
            
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            
        }


       

        //Query Methods
        private void Available<TValEntity>(string entityPropertyName, object matchValue) where TValEntity : class
        {
            ParameterExpression parameter = Expression.Parameter(typeof(TValEntity));
            MemberExpression property = Expression.Property(parameter, entityPropertyName);
            BinaryExpression body = Expression.Equal(property, Expression.Constant(matchValue));

            Expression<Func<TValEntity, bool>> equal = Expression.Lambda<Func<TValEntity, bool>>(body, parameter);

            IQueryable<TValEntity> query = _dbContext.Set<TValEntity>().Where(equal);
            if (query.Count() == 0) _validationMessages.Add(typeof(TValEntity).Name + " not found with property name: " + entityPropertyName + " value: " + matchValue.ToString());

        }

        private void NotAvailable<TValEntity>(string entityPropertyName, object matchValue) where TValEntity : class
        {
            ParameterExpression parameter = Expression.Parameter(typeof(TValEntity));
            MemberExpression property = Expression.Property(parameter, entityPropertyName);
            BinaryExpression body = Expression.Equal(property, Expression.Constant(matchValue));

            Expression<Func<TValEntity, bool>> equal = Expression.Lambda<Func<TValEntity, bool>>(body, parameter);

            IQueryable<TValEntity> query = _dbContext.Set<TValEntity>().Where(equal);
            if (query.Count() != 0) _validationMessages.Add(typeof(TValEntity).Name + " found with property name: " + entityPropertyName + " value: " + matchValue.ToString());

        }

        private void Available<TValEntity, TDto>(object dtoObject, string entityPropertyName, string entityDtoParameterName) where TValEntity : class where TDto : class
        {
            ParameterExpression parameter = Expression.Parameter(typeof(TValEntity));
            MemberExpression property = Expression.Property(parameter, entityPropertyName);
            object dtoValue = GetPropertyValue(dtoObject, entityDtoParameterName);
            BinaryExpression body = Expression.Equal(property, Expression.Constant(dtoValue));

            Expression<Func<TValEntity, bool>> equal = Expression.Lambda<Func<TValEntity, bool>>(body, parameter);

            IQueryable<TValEntity> query = _dbContext.Set<TValEntity>().Where(equal);
            if (query.Count() == 0) _validationMessages.Add(typeof(TValEntity).Name + " not found with property name: " + entityDtoParameterName + " value: " + dtoValue.ToString());

        }

        private void NotAvailable<TValEntity,TDto>(object dtoObject, string entityPropertyName, string entityDtoParameterName) where TValEntity : class where TDto : class
        {
            ParameterExpression parameter = Expression.Parameter(typeof(TValEntity));
            MemberExpression property = Expression.Property(parameter, entityPropertyName);
            object dtoValue = GetPropertyValue(dtoObject, entityDtoParameterName);
            BinaryExpression body = Expression.Equal(property, Expression.Constant(dtoValue));

            Expression<Func<TValEntity, bool>> equal = Expression.Lambda<Func<TValEntity, bool>>(body, parameter);

            IQueryable<TValEntity> query = _dbContext.Set<TValEntity>().Where(equal);
            if (query.Count() != 0) _validationMessages.Add(typeof(TValEntity).Name + " found with property name: " + entityDtoParameterName + " value: " + dtoValue.ToString());

        }

        private object GetPropertyValue(object obj, string propertyName)
        {

            foreach (var mainProperty in obj.GetType().GetProperties())
            {
                if (mainProperty.Name == propertyName) return mainProperty.GetValue(obj);
                if (mainProperty.PropertyType.IsClass)
                {
                    var propertyValue = GetPropertyValue(mainProperty.GetValue(obj), propertyName);
                    if (propertyValue != null) return propertyValue;
                }


            }

            return null;
        }


        //WorkList Methods
        public Validator AddAvailableFilter<TValEntity>(string entityPropertyName, object matchValue) where TValEntity : class
        {
            _withValueAction += Available<TValEntity>;
            _withValueActionArgs.Add(new object[] {entityPropertyName, matchValue});
            
            return this;
        }

        public Validator AddNotAvailableFilter<TValEntity>(string entityPropertyName, object matchValue) where TValEntity : class
        {
            _withValueAction += NotAvailable<TValEntity>;
            _withValueActionArgs.Add(new object[] { entityPropertyName, matchValue });
            return this;
        }

        public Validator AddAvailableFilter<TValEntity,TDto>(string entityPropertyName, string entityDtoParameterName) where TValEntity : class where TDto : class
        {
            _withDtoAction += Available<TValEntity, TDto>;
            _withDtoActionArgs.Add(new object[] { entityPropertyName, entityDtoParameterName }); 
            return this;
        }
        public Validator AddNotAvailableFilter<TValEntity,TDto>(string entityPropertyName, string entityDtoParameterName) where TValEntity : class where TDto : class
        {
            _withDtoAction += NotAvailable<TValEntity, TDto>;
            _withDtoActionArgs.Add(new object[] { entityPropertyName, entityDtoParameterName });
            return this;
        }
    }


}
