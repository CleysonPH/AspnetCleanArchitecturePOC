using ProjectManager.Application.Mappers.Users;
using ProjectManager.Application.Repositories.Users;
using ProjectManager.Application.ViewModels.Users;
using ProjectManager.Core.Exceptions;
using ProjectManager.Core.UseCases;

namespace ProjectManager.Application.UseCases.Users;

public class FindUserByIdUseCase : IUseCase<int, DetailUserViewModel>
{
    private readonly IUserMapper _userMapper;
    private readonly IUserRepository _userRepository;

    public FindUserByIdUseCase(IUserMapper userMapper, IUserRepository userRepository)
    {
        _userMapper = userMapper;
        _userRepository = userRepository;
    }

    public DetailUserViewModel Execute(int id)
    {
        var user = _userRepository.GetById(id);
        if (user == null)
        {
            throw new UserNotFoundException();
        }
        return _userMapper.ToDetailViewModel(user);
    }
}
