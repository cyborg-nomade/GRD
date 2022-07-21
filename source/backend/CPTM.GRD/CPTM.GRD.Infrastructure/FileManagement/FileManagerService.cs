using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Domain.Proposicoes;
using CPTM.GRD.Domain.Reunioes;

namespace CPTM.GRD.Infrastructure.FileManagement;

public class FileManagerService : IFileManagerService
{
    public Task<string> CreatePautaPrevia(Reuniao reuniao)
    {
        throw new NotImplementedException();
    }

    public Task<string> CreateMemoriaPrevia(Reuniao reuniao)
    {
        throw new NotImplementedException();
    }

    public Task<string> CreatePautaDefinitiva(Reuniao reuniao)
    {
        throw new NotImplementedException();
    }

    public Task<string> CreateRelatorioDeliberativo(Reuniao reuniao)
    {
        throw new NotImplementedException();
    }

    public Task<string> CreateResolucaoDiretoria(Reuniao reuniao, Proposicao proposicao)
    {
        throw new NotImplementedException();
    }

    public Task<string> CreateAta(Reuniao reuniao)
    {
        throw new NotImplementedException();
    }
}