using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UrlCreation.Data
{
    public interface IApplicationDbContext
    {
        public IQueryable<Entities.Url> DbSetUrl { get; }

        public int SaveChanges();

        public EntityEntry<TEntity> Add<TEntity>(TEntity entity)
            where TEntity : class;
    }
}
