using CPTM.GRD.Application.Contracts.Persistence.AccessControl;
using CPTM.GRD.Application.Exceptions;
using CPTM.GRD.Common;
using CPTM.GRD.Domain.AccessControl;
using Moq;

namespace CPTM.GRD.Application.Tests.Mocks.Persistence.AccessControl;

public static class MockUserRepository
{
    public static Mock<IUserRepository> GetUserRepository()
    {
        var users = new List<User>()
        {
            new User()
            {
                Id = 1,
                Nome = "Uriel Alexis Farizeli Fiori",
                UsernameAd = "urielf",
                NivelAcesso = AccessLevel.SysAdmin,
                AreasAcesso = new List<Group>()
                {
                    new Group()
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
                Email = "uriel.fiori@cptm.sp.gov.br",
                Funcao = "Analista de Sistemas",
            },
        };

        var mockRepo = new Mock<IUserRepository>();

        mockRepo.Setup(r => r.GetAll()).ReturnsAsync(users);
        mockRepo.Setup(r => r.Get(It.IsAny<int>())).ReturnsAsync((int id) => users.SingleOrDefault(u => u.Id == id));
        mockRepo.Setup(r => r.Add(It.IsAny<User>())).ReturnsAsync((User newUser) =>
        {
            newUser.Id = users.Count + 1;
            users.Add(newUser);
            return newUser;
        });
        mockRepo.Setup(r => r.Exists(It.IsAny<int>()))
            .ReturnsAsync((int id) => users.SingleOrDefault(u => u.Id == id) != null);
        mockRepo.Setup(r => r.Update(It.IsAny<User>())).ReturnsAsync((User updatedUser) =>
        {
            var oldUser = users.SingleOrDefault(u => u.Id == updatedUser.Id);
            if (oldUser == null) throw new NotFoundException(nameof(oldUser), nameof(oldUser));
            users.Remove(oldUser);
            users.Add(updatedUser);
            return updatedUser;
        });
        //mockRepo.Setup(r => r.Delete(It.IsAny<int>())).Returns((int id) =>
        //{
        //    var oldUser = users.SingleOrDefault(u => u.Id == id);
        //    if (oldUser == null) throw new NotFoundException(nameof(oldUser), nameof(oldUser));
        //    users.Remove(oldUser);
        //});

        return mockRepo;
    }
}