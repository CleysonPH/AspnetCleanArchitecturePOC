using ProjectManager.Application.Repositories.Users;
using ProjectManager.Core.Exceptions;
using ProjectManager.Core.UseCases;

namespace ProjectManager.Application.UseCases.Users;

public class DeleteUserByIdUseCase : IUseCaseWithoutOutput<int>
{
    private readonly IUserRepository _userRepository;

    public DeleteUserByIdUseCase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void Execute(int id)
    {
        var user = _userRepository.GetById(id);
        if (user == null)
        {
            throw new UserNotFoundException();
        }
        _userRepository.Delete(user);
    }
}