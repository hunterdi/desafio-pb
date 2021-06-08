using Architecture.Data;
using Domain;
using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Architecture
{
    public abstract class RepositoryBase<TDomain, TContext> : IRepositoryBase<TDomain>
        where TDomain : BaseDomain where TContext : ApplicationDataMongoContext
    {
        protected readonly TContext _dbContext;
        protected readonly IMongoCollection<TDomain> _collection;
        
        public RepositoryBase(TContext dbContext)
        {
            this._dbContext = dbContext;
            this._collection = this._dbContext._database.GetCollection<TDomain>(typeof(TDomain).Name);
        }

        public virtual async Task<TDomain> CreateAsync(TDomain domain)
        {
            await _collection.InsertOneAsync(domain);
            
            return domain;
        }

        public virtual async Task<TDomain> DeleteByIdAsync(Guid id)
        {
            var result = await _collection.FindOneAndDeleteAsync(e => e.ID == id);
            return result;
        }

        public virtual IQueryable<TDomain> GetAll()
        {
            return _collection.AsQueryable();
        }

        public virtual async Task<IEnumerable<TDomain>> GetAllAsync()
        {
            var result = await _collection.FindAsync(e => true);

            return result.ToList();
        }

        public virtual async Task<TDomain> GetByIdAsync(Guid id)
        {
            var result = (await this._collection.FindAsync(e => e.ID == id)).SingleOrDefault();

            if (result == null)
            {
                throw new KeyNotFoundException("Not Found!");
            }
            return result;
        }

        public virtual async Task<TDomain> UpdateAsync(Guid id, TDomain domain)
        {
            var entity = await this.GetByIdAsync(id);

            await _collection.ReplaceOneAsync(e => e.ID == id, domain);

            return entity;
        }
    }
}
