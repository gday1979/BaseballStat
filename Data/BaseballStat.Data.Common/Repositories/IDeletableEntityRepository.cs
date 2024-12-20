﻿namespace BaseballStat.Data.Common.Repositories
{
    using System.Linq;
    using System.Threading.Tasks;

    using BaseballStat.Data.Common.Models;

    public interface IDeletableEntityRepository<TEntity> : IDeletableEntity<TEntity>
        where TEntity : class, IDeletableEntity
    {
        IQueryable<TEntity> AllWithDeleted();

        IQueryable<TEntity> AllAsNoTrackingWithDeleted();

        void HardDelete(TEntity entity);

        void Undelete(TEntity entity);
    }
}
