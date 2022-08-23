using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.DTOs.AccessControl.User;
using CPTM.GRD.Application.DTOs.AccessControl.User.Validators;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Application.Features.AccessControl.Requests.Commands;
using CPTM.GRD.Common;
using CPTM.GRD.Domain.AccessControl;
using MediatR;

namespace CPTM.GRD.Application.Features.AccessControl.Handlers.Commands;

public class CreateUserRequestHandler : IRequestHandler<CreateUserRequest, UserDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthenticationService _authenticationService;
    private readonly IMapper _mapper;

    // ReSharper disable once NotAccessedField.Local
    private readonly IEmailService _emailService;

    public CreateUserRequestHandler(
        IUnitOfWork unitOfWork,
        IAuthenticationService authenticationService,
        IMapper mapper,
        IEmailService emailService)
    {
        _unitOfWork = unitOfWork;
        _authenticationService = authenticationService;
        _mapper = mapper;
        _emailService = emailService;
    }

    public async Task<UserDto> Handle(CreateUserRequest request, CancellationToken cancellationToken)
    {
        _authenticationService.AuthorizeByMinLevel(request.RequestUser, AccessLevel.Gerente);

        var validator = new CreateUserDtoValidator(_authenticationService);
        var validationResult = await validator.ValidateAsync(request.CreateUserDto, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult);
        }

        User addedUser;
        var userAd = await _authenticationService.GetUsuarioAd(request.CreateUserDto.UsernameAd);

        if (await _authenticationService.IsGerente(request.CreateUserDto.UsernameAd))
        {
            addedUser = await _unitOfWork.UserRepository.GetOrAddGerente(userAd);
        }
        else if (await _authenticationService.IsDiretor(request.CreateUserDto.UsernameAd))
        {
            addedUser = await _unitOfWork.UserRepository.GetOrAddDiretor(userAd);
        }
        else if (await _authenticationService.IsGrgMember(request.CreateUserDto.UsernameAd))
        {
            addedUser = await _unitOfWork.UserRepository.GetOrAddGrgMember(userAd);
        }
        else if (_authenticationService.IsSysAdmin(request.CreateUserDto.UsernameAd))
        {
            addedUser = await _unitOfWork.UserRepository.GetOrAddSysAdmin(userAd);
        }
        else
        {
            addedUser = await _unitOfWork.UserRepository.GetOrAdd(userAd, AccessLevel.Sub);
        }

        await _unitOfWork.Save();

        //await _emailService.SendEmail(new List<User>() { addedUser }, UserCreationSubject, UserCreationMessage);

        return _mapper.Map<UserDto>(addedUser);
    }
}