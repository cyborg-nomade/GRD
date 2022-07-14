using AutoMapper;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.DTOs.AccessControl;
using CPTM.GRD.Application.Features.AccessControl.Requests.Queries;
using MediatR;

namespace CPTM.GRD.Application.Features.AccessControl.Handlers.Queries;

public class GetUserDetailRequestHandler : IRequestHandler<GetUserDetailRequest, UserDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetUserDetailRequestHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UserDto> Handle(GetUserDetailRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.Get(request.Uid);
        return _mapper.Map<UserDto>(user);
    }
}