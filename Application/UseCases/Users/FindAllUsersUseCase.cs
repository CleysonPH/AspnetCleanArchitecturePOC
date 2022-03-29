using ProjectManager.Application.Mappers.Users;
using ProjectManager.Application.Repositories.Users;
using ProjectManager.Application.ViewModels.Users;
using ProjectManager.Core.UseCases;

namespace ProjectManager.Application.UseCases.Users;

public class FindAllUsersUseCase : IUseCaseWithoutInput<IEnumerable<DetailUserViewModel>>
{
    private readonly IUserMapper _userMapper;
    private readonly IUserRepository _userRepository;

    public FindAllUsersUseCase(IUserMapper userMapper, IUserRepository userRepository)
    {
        _userMapper = userMapper;
        _userRepository = userRepository;
    }

    public IEnumerable<DetailUserViewModel> Execute()
    {
        return _userRepository.GetAll().Select(_userMapper.ToDetailViewModel);
    }
}