using Microsoft.AspNetCore.Mvc;
using ProjectManager.Api.V1.Common;
using ProjectManager.Application.UseCases.Users;
using ProjectManager.Application.ViewModels.Users;
using ProjectManager.Core.Exceptions;

namespace ProjectManager.Api.V1.Users;

[ApiController]
[Route("api/v1/[controller]")]
public class UsersController : ControllerBase
{
    private readonly CreateUserUseCase _createUserUseCase;
    private readonly FindAllUsersUseCase _findAllUsersUseCase;
    private readonly FindUserByIdUseCase _findUserByIdUseCase;
    private readonly DeleteUserByIdUseCase _deleteUserByIdUseCase;

    public UsersController(
        CreateUserUseCase createUserUseCase,
        FindAllUsersUseCase findAllUsersUseCase,
        FindUserByIdUseCase findUserByIdUseCase,
        DeleteUserByIdUseCase deleteUserByIdUseCase)
    {
        _createUserUseCase = createUserUseCase;
        _findAllUsersUseCase = findAllUsersUseCase;
        _findUserByIdUseCase = findUserByIdUseCase;
        _deleteUserByIdUseCase = deleteUserByIdUseCase;
    }

    [HttpGet]
    public IActionResult FindAll()
    {
        var users = _findAllUsersUseCase.Execute();
        return Ok(users);
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateUserViewModel createUserViewModel)
    {
        try
        {
            var user = _createUserUseCase.Execute(createUserViewModel);
            return Ok(user);
        }
        catch (ValidationException e)
        {
            return BadRequest(new ErrorResponse(e));
        }
    }

    [HttpGet("{id}")]
    public IActionResult FindById(int id)
    {
        try
        {
            var user = _findUserByIdUseCase.Execute(id);
            return Ok(user);
        }
        catch (UserNotFoundException e)
        {
            return NotFound(new ErrorResponse(404, "Not Found", e));
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            _deleteUserByIdUseCase.Execute(id);
            return NoContent();
        }
        catch (UserNotFoundException e)
        {
            return NotFound(new ErrorResponse(404, "Not Found", e));
        }
    }
}