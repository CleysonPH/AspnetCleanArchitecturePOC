namespace ProjectManager.Core.UseCases;

public interface IUseCaseWithoutOutput<Input>
{
    void Execute(Input input);
}