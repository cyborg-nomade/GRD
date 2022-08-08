using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence;
using CPTM.GRD.Application.DTOs.AccessControl.User;
using CPTM.GRD.Application.DTOs.AccessControl.User.Validators;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Application.Features.AccessControl.Requests.Commands;
using CPTM.GRD.Common;
using MediatR;

namespace CPTM.GRD.Application.Features.AccessControl.Handlers.Commands;

public class UpdateUserRequestHandler : IRequestHandler<UpdateUserRequest, UserDto>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IAuthenticationService _authenticationService;

    public UpdateUserRequestHandler(
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IAuthenticationService authenticationService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _authenticationService = authenticationService;
    }

    public async Task<UserDto> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
    {
        _authenticationService.AuthorizeByMinLevel(request.RequestUser, AccessLevel.Grg);

        var validator = new UpdateUserDtoValidator(_authenticationService, _unitOfWork.UserRepository);
        var validationResult = await validator.ValidateAsync(request.UpdateUserDto, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult);
        }

        var savedUser = await _unitOfWork.UserRepository.Get(request.UpdateUserDto.Id);
        if (savedUser == null) throw new NotFoundException(nameof(savedUser), nameof(savedUser));

        await _authenticationService.AuthorizeByMinGroups(request.RequestUser, savedUser.AreasAcesso);

        _mapper.Map(request.UpdateUserDto, savedUser);
        var updatedUser = await _unitOfWork.UserRepository.Update(savedUser);
        return _mapper.Map<UserDto>(updatedUser);
    }
}