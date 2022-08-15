using AutoMapper;
using CPTM.GRD.Application.Profiles;
using CPTM.GRD.Application.UnitTests.Mocks.Infrastructure;
using CPTM.GRD.Application.UnitTests.Mocks.Persistence.AccessControl;

namespace CPTM.GRD.Application.UnitTests.Tests.AccessControl.Commands;

public class CreateUserRequestHandlerTests
{
    public CreateUserRequestHandlerTests()
    {
        MockUserRepository.GetUserRepository();
        MockAuthenticationService.GetAuthenticationService();
        MockEmailService.GetEmailService();

        var mapperConfig = new MapperConfiguration(c => { c.AddProfile<MappingProfile>(); });

        mapperConfig.CreateMapper();
    }

    //[Fact]
    //public async Task CreateUserRequestTest()
    //{
    //    var handler = new CreateUserRequestHandler(_authenticationService.Object, _mapper,
    //        _emailService.Object);

    //    var userToAdd = new CreateUserDto()
    //    {
    //        Nome = "User Test",
    //        AreasAcesso = new List<GroupDto>()
    //        {
    //            new GroupDto()
    //            {
    //                Id = 1,
    //                Nome = "Departamento de Desenvolvimento Sistemas",
    //                Sigla = "DFIS",
    //                Diretoria = "Diretoria Financeira",
    //                SiglaDiretoria = "DF",
    //                Gerencia = "Gerência de Tecnilogia da Informação",
    //                SiglaGerencia = "GFI",
    //            }
    //        },
    //        Funcao = "Tester",
    //        NivelAcesso = AccessLevel.Sub,
    //        UsernameAd = "urielf"
    //    };
    //    var userAdded = new UserDto()
    //    {
    //        Nome = userToAdd.Nome,
    //        Funcao = userToAdd.Funcao,
    //        NivelAcesso = userToAdd.NivelAcesso,
    //        UsernameAd = userToAdd.UsernameAd,
    //        AreasAcesso = userToAdd.AreasAcesso,
    //        Id = 2
    //    };
    //    var result =
    //        await handler.Handle(new CreateUserRequest() { CreateUserDto = userToAdd }, CancellationToken.None);

    //    result.ShouldBeOfType<UserDto>();
    //    result.ShouldBeEquivalentTo(userAdded);
    //}
}