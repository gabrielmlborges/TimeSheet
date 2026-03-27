using TimeSheet.Application.DTOs;
using TimeSheet.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace TimeSheet.Controllers;

[ApiController]
[Route("api/[controlller]")]

public class ActivityController : ControllerBase
{
    private readonly IActivityService _activityService;
    public ActivityController(IActivityService activityService)
    {
        _activityService = activityService;
    }
    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateActivityRequestDTO dto)
    {
        var result = await _activityService.CreateActivity(dto);

        if (result == null) return BadRequest("ERROR");

        return Ok(result);
    }
}
