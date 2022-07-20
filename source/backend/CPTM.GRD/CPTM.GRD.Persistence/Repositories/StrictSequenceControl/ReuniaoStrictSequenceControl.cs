﻿using CPTM.GRD.Application.Contracts.Persistence.StrictSequenceControl;

namespace CPTM.GRD.Persistence.Repositories.StrictSequenceControl;

public class ReuniaoStrictSequenceControl : IReuniaoStrictSequenceControl
{
    private readonly string _controlFilesDirPath = Path.Combine(Directory.GetCurrentDirectory(), "ControlFiles");
    private const string ControlFileName = "reuniaoControl.txt";
    private const int InitialValue = 0;

    public ReuniaoStrictSequenceControl()
    {
        if (!Directory.Exists(_controlFilesDirPath))
        {
            Directory.CreateDirectory(_controlFilesDirPath);
        }

        if (!File.Exists(Path.Combine(_controlFilesDirPath, ControlFileName)))
        {
            File.WriteAllText(Path.Combine(_controlFilesDirPath, ControlFileName),
                InitialValue.ToString());
        }
    }

    public async Task<int> GetNextNumeroReuniao()
    {
        var fileLines = await File.ReadAllLinesAsync(Path.Combine(_controlFilesDirPath, ControlFileName));
        var currentValue = int.Parse(fileLines[0]);
        var nextValue = ++currentValue;
        await File.WriteAllTextAsync(Path.Combine(_controlFilesDirPath, ControlFileName),
            nextValue.ToString());
        return nextValue;
    }

    public async Task<bool> IsValid(int numeroReuniao)
    {
        var fileLines = await File.ReadAllLinesAsync(Path.Combine(_controlFilesDirPath, ControlFileName));
        var currentValue = int.Parse(fileLines[0]);
        return numeroReuniao < currentValue;
    }
}