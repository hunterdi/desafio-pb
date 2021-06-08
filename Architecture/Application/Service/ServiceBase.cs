using AutoMapper;
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
    public abstract class ServiceBase<TDomain>: IServiceBase<TDomain> where TDomain : BaseDomain
    {
        protected readonly IRepositoryBase<TDomain> _repository;

        public ServiceBase(IRepositoryBase<TDomain> repository)
        {
            this._repository = repository;            
        }

        public virtual async Task<TDomain> CreateAsync(TDomain obj)
        {
            var result = await this._repository.CreateAsync(obj);
            
            return result;
        }

        public virtual async Task<TDomain> DeleteAsync(Guid id)
        {
            var result = await this._repository.DeleteByIdAsync(id);
            
            return result;
        }

        public virtual async Task<IEnumerable<TDomain>> GetAllAsync()
        {
            return await this._repository.GetAllAsync();
        }

        public virtual async Task<TDomain> GetByIdAsync(Guid id)
        {
            return await this._repository.GetByIdAsync(id);
        }

        public virtual async Task<TDomain> UpdateAsync(Guid id, TDomain obj)
        {
            await this._repository.UpdateAsync(id, obj);
            
            return obj;
        }

    }
}
