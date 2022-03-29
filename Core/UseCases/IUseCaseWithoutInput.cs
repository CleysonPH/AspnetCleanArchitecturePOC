namespace ProjectManager.Core.UseCases;

public interface IUseCaseWithoutInput<Output>
{
    Output Execute();
}