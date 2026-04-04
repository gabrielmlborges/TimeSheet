using TimeSheet.Application.DTOs;
using TimeSheet.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace TimeSheet.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectController : ControllerBase
{
    private readonly IProjectService _projectService;

    public ProjectController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateProjectRequestDTO dto)
    {
        var result = await _projectService.CreateProject(dto);

        return Ok(result);
    }

    [HttpPost("{projectId:guid}/activities")]
    public async Task<ActionResult> AddActivities(Guid projectId, [FromBody] AddActivitiesToProjectDTO dto)
    {
        await _projectService.AddActivitiesToProject(projectId, dto);

        return NoContent();
    }

    [HttpPost("{projectId:guid}/users")]
    public async Task<ActionResult> AssignUsers(Guid projectId, [FromBody] AssignUsersToProjectDTO dto)
    {
        await _projectService.AssignUsersToProject(projectId, dto);

        return NoContent();
    }
}
