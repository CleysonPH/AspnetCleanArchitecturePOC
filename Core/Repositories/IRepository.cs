namespace ProjectManager.Core.Repositories;

public interface IRepository<TEntity, Id>
{
    bool Exists(Id id);
    TEntity? GetById(Id id);
    IEnumerable<TEntity> GetAll();
}
