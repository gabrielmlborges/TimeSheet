using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TimeSheet.Application.DTOs;
using TimeSheet.Application.Interfaces;

namespace TimeSheet.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TimeLogController : ApiControllerBase
{
    private readonly ITimeLogService _timelogService;

    public TimeLogController(ITimeLogService timeLogService)
    {
        _timelogService = timeLogService;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult> Create([FromBody] CreateTimeLogRequestDTO dto)
    {
        var result = await _timelogService.CreateTimeLog(UserId, dto);

        return Ok(result);
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult> GetAllLogsFromUser([FromQuery] GetUserLogsRequestDTO dto)
    {
        var result = await _timelogService.GetUserLogs(UserId, dto);

        return Ok(result);
    }
}
