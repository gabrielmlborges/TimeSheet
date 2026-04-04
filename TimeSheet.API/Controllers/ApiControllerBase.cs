using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace TimeSheet.API.Controllers;

public abstract class ApiControllerBase : ControllerBase
{
    protected Guid UserId => GetUserId();

    private Guid GetUserId()
    {
        string? claim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (string.IsNullOrEmpty(claim))
        {
            throw new UnauthorizedAccessException("Usuario nao autorizado");
        }

        return Guid.Parse(claim);
    }
}
