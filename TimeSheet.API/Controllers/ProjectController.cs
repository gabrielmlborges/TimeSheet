using TimeSheet.Application.DTOs;
using TimeSheet.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace TimeSheet.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectController : ApiControllerBase
{
    private readonly IProjectService _projectService;
    private readonly IActivityService _activityService;

    public ProjectController(IProjectService projectService, IActivityService activityService)
    {
        _projectService = projectService;
        _activityService = activityService;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var result = await _projectService.GetAllProjects();

        return Ok(result);
    }

    [HttpGet("me")]
    public async Task<ActionResult> GetUserProjects()
    {
        var result = await _projectService.GetUserProjects(UserId);

        return Ok(result);
    }

    [HttpGet("{projectId:Guid}/activities")]
    public async Task<ActionResult> GetProjectActivities(Guid projectId)
    {
        var result = await _activityService.GetProjectActivities(projectId);

        return Ok(result);
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
