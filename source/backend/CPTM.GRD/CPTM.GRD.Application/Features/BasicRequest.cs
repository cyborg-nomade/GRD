using System.Security.Claims;

namespace CPTM.GRD.Application.Features;

public class BasicRequest
{
    public ClaimsPrincipal RequestUser { get; init; } = new ClaimsPrincipal();
}