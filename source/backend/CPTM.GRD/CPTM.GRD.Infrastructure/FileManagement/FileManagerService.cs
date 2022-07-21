using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Domain.Proposicoes;
using CPTM.GRD.Domain.Reunioes;

namespace CPTM.GRD.Infrastructure.FileManagement;

public class FileManagerService : IFileManagerService
{
    private readonly string _controlFileDirPath;
    private const string ControlFilesDir = "GeneratedFiles";

    public FileManagerService(string homeDir)
    {
        _controlFileDirPath = Path.Combine(homeDir, ControlFilesDir);
        Directory.CreateDirectory(_controlFileDirPath);
    }

    public async Task<string> CreatePautaPrevia(Reuniao reuniao)
    {
        var pautaPreviaFilePath = Path.Combine(_controlFileDirPath, $"RD{reuniao.NumeroReuniao}-PautaPrévia.txt");
        await File.WriteAllTextAsync(pautaPreviaFilePath, "Pauta Prévia");
        return pautaPreviaFilePath;
    }

    public async Task<string> CreateMemoriaPrevia(Reuniao reuniao)
    {
        var memoriaPreviaFilePath = Path.Combine(_controlFileDirPath, $"RD{reuniao.NumeroReuniao}-MemóriaPrévia.txt");
        await File.WriteAllTextAsync(memoriaPreviaFilePath, "Memória Prévia");
        return memoriaPreviaFilePath;
    }

    public async Task<string> CreatePautaDefinitiva(Reuniao reuniao)
    {
        var pautaDefinitivaFilePath =
            Path.Combine(_controlFileDirPath, $"RD{reuniao.NumeroReuniao}-PautaDefinitiva.txt");
        await File.WriteAllTextAsync(pautaDefinitivaFilePath, "Pauta Definitiva");
        return pautaDefinitivaFilePath;
    }

    public async Task<string> CreateRelatorioDeliberativo(Reuniao reuniao)
    {
        var relatorioDeliberativoFilePath =
            Path.Combine(_controlFileDirPath, $"RD{reuniao.NumeroReuniao}-RelatórioDeliberativo.txt");
        await File.WriteAllTextAsync(relatorioDeliberativoFilePath, "Relatório Deliberativo");
        return relatorioDeliberativoFilePath;
    }

    public async Task<string> CreateResolucaoDiretoria(Reuniao reuniao, Proposicao proposicao)
    {
        var resolucaoDiretoriaFilePath =
            Path.Combine(_controlFileDirPath, $"IDPRD{proposicao.IdPrd}-ResoluçãoDiretoria.txt");
        await File.WriteAllTextAsync(resolucaoDiretoriaFilePath, "Resolução Diretoria");
        return resolucaoDiretoriaFilePath;
    }

    public async Task<string> CreateAta(Reuniao reuniao)
    {
        var ataFilePath = Path.Combine(_controlFileDirPath, $"RD{reuniao.NumeroReuniao}-Ata.txt");
        await File.WriteAllTextAsync(ataFilePath, "Ata");
        return ataFilePath;
    }
}