using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Validation.Abstract
{
    public interface IValidator
    {
        

        IValidator AddAvailableFilter<TValEntity>(string entityPropertyName, object matchValue) where TValEntity : class;
        IValidator AddNotAvailableFilter<TValEntity>(string entityPropertyName, object matchValue) where TValEntity : class;
        IValidator AddAvailableFilter<TValEntity>(string entityPropertyName, string entityDtoParameterName) where TValEntity : class;
        IValidator AddNotAvailableFilter<TValEntity>(string entityPropertyName, string entityDtoParameterName) where TValEntity : class;
    }
}
