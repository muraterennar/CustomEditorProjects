using System.Linq.Expressions;
using customEditorServer.Core.Entites;
using Microsoft.EntityFrameworkCore;

namespace customEditorServer.Core.DataAccess.EntityFramework;

public class EfEntityRepositorybase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
{

    public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
    {
        using (TContext context = new())
        {
            return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
        }
    }

    public TEntity Get(Expression<Func<TEntity, bool>> filter)
    {
        using (TContext context = new())
        {
            return context.Set<TEntity>().SingleOrDefault(filter);
        }
    }

    public TEntity GetById(int id)
    {
        using (TContext context = new())
        {
            return context.Set<TEntity>().SingleOrDefault(t => t.Id == id);
        }
    }

    public void Add(TEntity entity)
    {
        using (TContext context = new())
        {
            var addedEntity = context.Add(entity);
            addedEntity.State = EntityState.Added;
            context.SaveChanges();
        }
    }

    public void DeleteByEntity(TEntity entity)
    {
        using (TContext context = new())
        {
            var deleteForByEntity = context.Remove(entity);
            deleteForByEntity.State = EntityState.Deleted;
            context.SaveChanges();
        }
    }

    public void DeleteById(int id)
    {
        using (TContext context = new())
        {
            var deleteForById = context.Remove(id);
            deleteForById.State = EntityState.Deleted;
            context.SaveChanges();
        }
    }

    public void Update(TEntity entity)
    {
        using (TContext context = new())
        {
            var updatedEntity = context.Update(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}

