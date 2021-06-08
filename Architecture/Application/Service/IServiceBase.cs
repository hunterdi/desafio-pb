using Domain;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Architecture
{
    public interface IServiceBase<TDomain> where TDomain: BaseDomain
    {
        Task<TDomain> CreateAsync(TDomain obj);
        Task<TDomain> DeleteAsync(Guid id);
        Task<IEnumerable<TDomain>> GetAllAsync();
        Task<TDomain> GetByIdAsync(Guid id);
        Task<TDomain> UpdateAsync(Guid id, TDomain obj);
    }
}
