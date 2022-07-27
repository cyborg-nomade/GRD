using CPTM.GRD.Application.Contracts.Infrastructure;
using CPTM.GRD.Application.Models.Settings;
using CPTM.GRD.Domain.Proposicoes;
using CPTM.GRD.Domain.Reunioes;
using Microsoft.Extensions.Options;

namespace CPTM.GRD.Infrastructure.FileManagement;

public class FileManagerService : IFileManagerService
{
    private readonly string _appFilesDirPath;

    private FileManagerServiceSettings FileManagerServiceSettings { get; }

    public FileManagerService(IOptions<FileManagerServiceSettings> fileOptions)
    {
        FileManagerServiceSettings = fileOptions.Value;
        _appFilesDirPath =
            Path.Combine(FileManagerServiceSettings.HomeDir, FileManagerServiceSettings.AppFilesDir);
        Directory.CreateDirectory(_appFilesDirPath);
    }

    public async Task<string> CreatePautaPrevia(Reuniao reuniao)
    {
        var pautaPreviaFilePath = Path.Combine(_appFilesDirPath, $"RD{reuniao.NumeroReuniao}-PautaPrévia.txt");
        await File.WriteAllTextAsync(pautaPreviaFilePath, "Pauta Prévia");
        return pautaPreviaFilePath;
    }

    public async Task<string> CreateMemoriaPrevia(Reuniao reuniao)
    {
        var memoriaPreviaFilePath = Path.Combine(_appFilesDirPath, $"RD{reuniao.NumeroReuniao}-MemóriaPrévia.txt");
        await File.WriteAllTextAsync(memoriaPreviaFilePath, "Memória Prévia");
        return memoriaPreviaFilePath;
    }

    public async Task<string> CreatePautaDefinitiva(Reuniao reuniao)
    {
        var pautaDefinitivaFilePath =
            Path.Combine(_appFilesDirPath, $"RD{reuniao.NumeroReuniao}-PautaDefinitiva.txt");
        await File.WriteAllTextAsync(pautaDefinitivaFilePath, "Pauta Definitiva");
        return pautaDefinitivaFilePath;
    }

    public async Task<string> CreateRelatorioDeliberativo(Reuniao reuniao)
    {
        var relatorioDeliberativoFilePath =
            Path.Combine(_appFilesDirPath, $"RD{reuniao.NumeroReuniao}-RelatórioDeliberativo.txt");
        await File.WriteAllTextAsync(relatorioDeliberativoFilePath, "Relatório Deliberativo");
        return relatorioDeliberativoFilePath;
    }

    public async Task<string> CreateResolucaoDiretoria(Reuniao reuniao, Proposicao proposicao)
    {
        var resolucaoDiretoriaFilePath =
            Path.Combine(_appFilesDirPath, $"IDPRD{proposicao.IdPrd}-ResoluçãoDiretoria.txt");
        await File.WriteAllTextAsync(resolucaoDiretoriaFilePath, "Resolução Diretoria");
        return resolucaoDiretoriaFilePath;
    }

    public async Task<string> CreateAta(Reuniao reuniao)
    {
        var ataFilePath = Path.Combine(_appFilesDirPath, $"RD{reuniao.NumeroReuniao}-Ata.txt");
        await File.WriteAllTextAsync(ataFilePath, "Ata");
        return ataFilePath;
    }
}