using CPTM.GRD.Application.DTOs.AccessControl;
using MediatR;

namespace CPTM.GRD.Application.Features.AccessControl.Requests.Queries;

public class GetAllUsersListRequest : IRequest<List<UserDto>>
{
}