﻿using CPTM.GRD.Domain;

namespace CPTM.GRD.Application.Contracts.Infrastructure;

public interface IFileCreator
{
    Task<string> CreatePautaPrevia(Reuniao reuniao);
    Task<string> CreateMemoriaPrevia(Reuniao reuniao);
    Task<string> CreatePautaDefinitiva(Reuniao reuniao);
    Task<string> CreateRelatorioDeliberativo(Reuniao reuniao);
    Task<string> CreateResolucaoDiretoria(Reuniao reuniao, Proposicao proposicao);
    Task<string> CreateAta(Reuniao reuniao);
}