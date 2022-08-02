using AutoMapper;
using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.DTOs.AccessControl.Group;
using CPTM.GRD.Application.DTOs.AccessControl.User;
using CPTM.GRD.Application.Features.AccessControl.Handlers.Commands;
using CPTM.GRD.Application.Features.AccessControl.Requests.Commands;
using CPTM.GRD.Application.Profiles;
using CPTM.GRD.Application.Tests.Mocks.Infrastructure;
using CPTM.GRD.Application.Tests.Mocks.Persistence.AccessControl;
using CPTM.GRD.Common;
using Moq;
using Shouldly;

namespace CPTM.GRD.Application.Tests.Tests.AccessControl.Commands;

public class CreateUserRequestHandlerTests
{
    private readonly Mock<IUserRepository> _userRepository;
    private readonly Mock<IAuthenticationService> _authenticationService;
    private readonly IMapper _mapper;
    private readonly Mock<IEmailService> _emailService;

    public CreateUserRequestHandlerTests()
    {
        _userRepository = MockUserRepository.GetUserRepository();
        _authenticationService = MockAuthenticationService.GetAuthenticationService();
        _emailService = MockEmailService.GetEmailService();

        var mapperConfig = new MapperConfiguration(c => { c.AddProfile<MappingProfile>(); });

        _mapper = mapperConfig.CreateMapper();
    }

    [Fact]
    public async Task CreateUserRequestTest()
    {
        var handler = new CreateUserRequestHandler(_userRepository.Object, _authenticationService.Object, _mapper,
            _emailService.Object);

        var userToAdd = new CreateUserDto()
        {
            Nome = "User Test",
            AreasAcesso = new List<GroupDto>()
            {
                new GroupDto()
                {
                    Id = 1,
                    Nome = "Departamento de Desenvolvimento Sistemas",
                    Sigla = "DFIS",
                    Diretoria = "Diretoria Financeira",
                    SiglaDiretoria = "DF",
                    Gerencia = "Gerência de Tecnilogia da Informação",
                    SiglaGerencia = "GFI",
                }
            },
            Funcao = "Tester",
            NivelAcesso = AccessLevel.Sub,
            UsernameAd = "urielf"
        };
        var userAdded = new UserDto()
        {
            Nome = userToAdd.Nome,
            Funcao = userToAdd.Funcao,
            NivelAcesso = userToAdd.NivelAcesso,
            UsernameAd = userToAdd.UsernameAd,
            AreasAcesso = userToAdd.AreasAcesso,
            Id = 2
        };
        var result =
            await handler.Handle(new CreateUserRequest() { CreateUserDto = userToAdd }, CancellationToken.None);

        result.ShouldBeOfType<UserDto>();
        result.ShouldBeEquivalentTo(userAdded);
    }
}