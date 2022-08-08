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
using static CPTM.GRD.Application.Models.EmailSubjectsAndMessages;

namespace CPTM.GRD.Application.Features.AccessControl.Handlers.Commands;

public class CreateUserRequestHandler : IRequestHandler<CreateUserRequest, UserDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthenticationService _authenticationService;
    private readonly IMapper _mapper;
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

        var validator = new CreateUserDtoValidator(_authenticationService, _unitOfWork.UserRepository);
        var validationResult = await validator.ValidateAsync(request.CreateUserDto, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult);
        }

        var user = _mapper.Map<User>(request.CreateUserDto);
        var addedUser = await _unitOfWork.UserRepository.Add(user);
        await _unitOfWork.Save();

        await _emailService.SendEmail(new List<User>() { user }, UserCreationSubject, UserCreationMessage);

        return _mapper.Map<UserDto>(addedUser);
    }
}