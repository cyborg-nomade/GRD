using CPTM.GRD.Application.DTOs.AccessControl;
using MediatR;

namespace CPTM.GRD.Application.Features.AccessControl.Requests.Queries;

public class GetUserDetailRequest : IRequest<UserDto>
{
    public int Uid { get; set; }
}