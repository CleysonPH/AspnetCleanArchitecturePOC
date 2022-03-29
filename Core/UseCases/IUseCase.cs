namespace ProjectManager.Core.UseCases;

public interface IUseCase<Input, Output>
{
    Output Execute(Input input);
}