using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.DTOs.AccessControl.User;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Application.Features.AccessControl.Requests.Commands;
using CPTM.GRD.Application.Responses;
using CPTM.GRD.Common;
using CPTM.GRD.Domain.AccessControl;
using MediatR;

namespace CPTM.GRD.Application.Features.AccessControl.Handlers.Commands;

public class LoginUserRequestHandler : IRequestHandler<LoginUserRequest, AuthResponse>
{
    private readonly IAuthenticationService _authenticationService;
    private readonly IUserRepository _userRepository;
    private readonly IGroupRepository _groupRepository;
    private readonly IMapper _mapper;

    public LoginUserRequestHandler(
        IAuthenticationService authenticationService,
        IUserRepository userRepository,
        IGroupRepository groupRepository,
        IMapper mapper)
    {
        _authenticationService = authenticationService;
        _userRepository = userRepository;
        _groupRepository = groupRepository;
        _mapper = mapper;
    }

    public async Task<AuthResponse> Handle(LoginUserRequest request, CancellationToken cancellationToken)
    {
        if (!await _authenticationService.ExistsAd(request.AuthUser.Username))
        {
            throw new NotFoundException(nameof(request.AuthUser), request.AuthUser.Username);
        }

        if (!await _authenticationService.Authenticate(request.AuthUser))
        {
            throw new BadRequestException("Credenciais inválidas");
        }

        User? loggedUser;
        var userAd = await _authenticationService.GetUsuarioAd(request.AuthUser.Username);

        if (await _authenticationService.IsGerente(request.AuthUser.Username))
        {
            loggedUser = await _userRepository.GetOrAddGerente(userAd);
        }
        else if (await _authenticationService.IsDiretor(request.AuthUser.Username))
        {
            loggedUser = await _userRepository.GetOrAddDiretor(userAd);
        }
        else if (await _authenticationService.IsGrgMember(request.AuthUser.Username))
        {
            loggedUser = await _userRepository.GetOrAddGrgMember(userAd);
        }
        else if (_authenticationService.IsSysAdmin(request.AuthUser.Username))
        {
            loggedUser = await _userRepository.GetOrAddSysAdmin(userAd);
        }
        else
        {
            loggedUser = await _userRepository.GetByUsername(request.AuthUser.Username);
            if (loggedUser == null) throw new NotFoundException(nameof(loggedUser), request.AuthUser.Username);
        }

        var authResponse = _authenticationService.GenerateToken(loggedUser);

        return new AuthResponse()
        {
            User = _mapper.Map<UserDto>(loggedUser),
            Token = authResponse.Token,
            ExpirationDate = authResponse.ExpirationDate
        };
    }
}