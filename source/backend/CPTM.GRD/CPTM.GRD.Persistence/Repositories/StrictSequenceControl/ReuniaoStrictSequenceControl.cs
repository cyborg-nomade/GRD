using CPTM.GRD.Application.Contracts.Persistence.StrictSequenceControl;
using CPTM.GRD.Application.Models.Settings;
using Microsoft.Extensions.Options;

namespace CPTM.GRD.Persistence.Repositories.StrictSequenceControl;

public class ReuniaoStrictSequenceControl : IReuniaoStrictSequenceControl
{
    private const string ControlFilesDir = "ControlFiles";
    private const string ControlFileName = "reuniaoControl.txt";
    private const int InitialValue = 0;
    private readonly string _controlFilePath;

    public ReuniaoStrictSequenceControl(IOptions<StrictSequenceControlServiceSettings> strictSequenceOptions)
    {
        var controlFileDirPath = Path.Combine(strictSequenceOptions.Value.HomeDir, ControlFilesDir);
        Directory.CreateDirectory(controlFileDirPath);

        _controlFilePath = Path.Combine(controlFileDirPath, ControlFileName);
        if (!File.Exists(_controlFilePath))
        {
            File.WriteAllText(_controlFilePath, InitialValue.ToString());
        }
    }

    public async Task<int> GetNextNumeroReuniao()
    {
        var fileLines = await File.ReadAllLinesAsync(_controlFilePath);
        var currentValue = int.Parse(fileLines[0]);
        var nextValue = ++currentValue;
        await File.WriteAllTextAsync(_controlFilePath, nextValue.ToString());
        return nextValue;
    }

    public async Task<bool> IsValid(int numeroReuniao)
    {
        var fileLines = await File.ReadAllLinesAsync(_controlFilePath);
        var currentValue = int.Parse(fileLines[0]);
        return numeroReuniao < currentValue;
    }
}