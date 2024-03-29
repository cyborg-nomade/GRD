﻿using CPTM.GRD.Application.Contracts.Persistence.StrictSequenceControl;
using CPTM.GRD.Application.Models.Settings;
using Microsoft.Extensions.Options;

namespace CPTM.GRD.Persistence.Repositories.StrictSequenceControl;

public class ProposicaoStrictSequenceControl : IProposicaoStrictSequenceControl
{
    private const string ControlFilesDir = "ControlFiles";
    private const string ControlFileName = "proposicaoControl.txt";
    private const int InitialValue = 0;
    private readonly string _controlFilePath;

    public ProposicaoStrictSequenceControl(IOptions<StrictSequenceControlServiceSettings> strictSequenceOptions)
    {
        var controlFileDirPath = Path.Combine(strictSequenceOptions.Value.HomeDir, ControlFilesDir);
        Directory.CreateDirectory(controlFileDirPath);

        _controlFilePath = Path.Combine(controlFileDirPath, ControlFileName);
        if (!File.Exists(_controlFilePath))
        {
            File.WriteAllText(_controlFilePath, InitialValue.ToString());
        }
    }

    public async Task<int> GetNextIdPrd()
    {
        var fileLines = await File.ReadAllLinesAsync(_controlFilePath);
        var currentValue = int.Parse(fileLines[0]);
        var nextValue = ++currentValue;
        await File.WriteAllTextAsync(_controlFilePath, nextValue.ToString());
        return nextValue;
    }

    public async Task<bool> IsValid(int idprd)
    {
        var fileLines = await File.ReadAllLinesAsync(_controlFilePath);
        var currentValue = int.Parse(fileLines[0]);
        return idprd <= currentValue;
    }
}