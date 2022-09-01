using CPTM.GRD.Application.DTOs.AccessControl.User;
using MediatR;

namespace CPTM.GRD.Application.Features.AccessControl.Requests.Queries;

public class GetAllUsersListRequest : BasicRequest, IRequest<List<UserDto>>
{
}