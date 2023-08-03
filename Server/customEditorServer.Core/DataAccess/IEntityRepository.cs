using System.Linq.Expressions;
using customEditorServer.Core.Entites;

namespace customEditorServer.Core.DataAccess;

public interface IEntityRepository<T> where T : class, IEntity, new()
{
    List<T> GetAll(Expression<Func<T, bool>> filter = null);
    T Get(Expression<Func<T, bool>> filter);
    T GetById(int id);

    void Add(T entity);
    void DeleteByEntity(T entity);
    void DeleteById(int id);
    void Update(T entity);
}

