namespace ProjectManager.Core.Repositories;

public interface ICrudRepository<TEntity, Id> : IRepository<TEntity, Id>
{
    void Add(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}
