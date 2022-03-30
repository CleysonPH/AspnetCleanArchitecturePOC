namespace ProjectManager.Core.Repositories;

public interface ICrudRepository<TEntity, Id> : IRepository<TEntity, Id>
{
    TEntity Add(TEntity entity);
    TEntity Update(TEntity entity);
    void Delete(TEntity entity);
}
