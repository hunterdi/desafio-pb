using Domain;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Architecture
{
    public interface IRepositoryBase<TDomain> where TDomain : BaseDomain
    {
        Task<TDomain> CreateAsync(TDomain domain);
        Task<TDomain> DeleteByIdAsync(Guid id);
        IQueryable<TDomain> GetAll();
        Task<IEnumerable<TDomain>> GetAllAsync();
        Task<TDomain> GetByIdAsync(Guid id);
        Task<TDomain> UpdateAsync(Guid id, TDomain domain);
    }
}
