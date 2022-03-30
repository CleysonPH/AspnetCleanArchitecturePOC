using ProjectManager.Application.Mappers.Users;
using ProjectManager.Application.Repositories.Users;
using ProjectManager.Application.Services;
using ProjectManager.Application.Validators.Users;
using ProjectManager.Application.ViewModels.Users;
using ProjectManager.Core.UseCases;
using ProjectManager.Domain.Entities;

namespace ProjectManager.Application.UseCases.Users;

public class CreateUserUseCase : IUseCase<CreateUserViewModel, DetailUserViewModel>
{
    private readonly IUserMapper _userMapper;
    private readonly IUserRepository _userRepository;
    private readonly ICreateUserValidator _validator;
    private readonly IPasswordEncoder _passwordEncoder;

    public CreateUserUseCase(
        IUserMapper userMapper,
        IUserRepository userRepository,
        ICreateUserValidator validator,
        IPasswordEncoder passwordEncoder)
    {
        _userMapper = userMapper;
        _userRepository = userRepository;
        _validator = validator;
        _passwordEncoder = passwordEncoder;
    }

    public DetailUserViewModel Execute(CreateUserViewModel createUserViewModel)
    {
        _validator.Validate(createUserViewModel);

        var user = _userMapper.ToEntity(createUserViewModel);
        user.Password = _passwordEncoder.Encode(user.Password);

        user = _userRepository.Add(user);

        return _userMapper.ToDetailViewModel(user);
    }
}
