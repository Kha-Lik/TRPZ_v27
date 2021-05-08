using System.Linq;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbSet<TEntity> _set;

        public Repository(TicketsDbContext context)
        {
            _set = context.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll()
        {
            return _set.AsQueryable();
        }

        public TEntity GetById(int id)
        {
            return _set.Find(id);
        }

        public void Create(TEntity entity)
        {
            _set.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _set.Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _set.Remove(entity);
        }
    }
}