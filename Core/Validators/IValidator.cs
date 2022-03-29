namespace ProjectManager.Core.Validators;

public interface IValidator<T>
{
    void Validate(T entity);
}
