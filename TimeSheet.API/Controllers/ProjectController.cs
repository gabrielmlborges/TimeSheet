using TimeSheet.Application.DTOs;
using TimeSheet.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace TimeSheet.Controllers;

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

        if (result == null) return BadRequest("ERROR");

        return Ok(result);
    }

    [HttpPost("{projectId}/employees")]
    public async Task<ActionResult> AssignEmployees(Guid projectId, [FromBody] AssignEmployeesRequestDTO request)
    {
        await _projectService.AssignMultiple(projectId, request);

        return Ok("Deu certo!!! (eu acho)");
    }
}
