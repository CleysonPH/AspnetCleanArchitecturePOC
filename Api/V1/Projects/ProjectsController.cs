using Microsoft.AspNetCore.Mvc;
using ProjectManager.Api.V1.Common;
using ProjectManager.Application.UseCases.Projects;
using ProjectManager.Application.ViewModels.Projects;
using ProjectManager.Core.Exceptions;

namespace ProjectManager.Api.V1.Projects;

[ApiController]
[Route("api/v1/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly CreateProjectUseCase _createProjectUseCase;

    public ProjectsController(CreateProjectUseCase createProjectUseCase)
    {
        _createProjectUseCase = createProjectUseCase;
    }

    [HttpPost]
    public IActionResult Create([FromBody] CreateProjectViewModel createProjectViewModel)
    {
        try
        {
            var project = _createProjectUseCase.Execute(createProjectViewModel);
            return Ok(project);
        }
        catch (ValidationException e)
        {
            return BadRequest(new ErrorResponse(e));
        }
    }
}