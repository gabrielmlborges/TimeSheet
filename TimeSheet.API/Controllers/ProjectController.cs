using TimeSheet.Application.DTOs;
using TimeSheet.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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
    [Authorize(Policy = "AdminOnly")]
    public async Task<ActionResult> GetAll()
    {
        var result = await _projectService.GetAllProjects();

        return Ok(result);
    }

    [HttpGet("me")]
    [Authorize]
    public async Task<ActionResult> GetUserProjects()
    {
        var result = await _projectService.GetUserProjects(UserId);

        return Ok(result);
    }

    [HttpGet("{projectId:Guid}/activities")]
    [Authorize]
    public async Task<ActionResult> GetProjectActivities(Guid projectId)
    {
        var result = await _activityService.GetProjectActivities(projectId, UserId);

        return Ok(result);
    }

    [HttpPost]
    [Authorize(Policy = "AdminOnly")]
    public async Task<ActionResult> Create([FromBody] CreateProjectRequestDTO dto)
    {
        var result = await _projectService.CreateProject(dto);

        return Ok(result);
    }

    [HttpPost("{projectId:guid}/activities")]
    [Authorize(Policy = "AdminOnly")]
    public async Task<ActionResult> AddActivities(Guid projectId, [FromBody] AddActivitiesToProjectDTO dto)
    {
        await _projectService.AddActivitiesToProject(projectId, dto);

        return NoContent();
    }

    [HttpPost("{projectId:guid}/users")]
    [Authorize(Policy = "AdminOnly")]
    public async Task<ActionResult> AssignUsers(Guid projectId, [FromBody] AssignUsersToProjectDTO dto)
    {
        await _projectService.AssignUsersToProject(projectId, dto);

        return NoContent();
    }
}
