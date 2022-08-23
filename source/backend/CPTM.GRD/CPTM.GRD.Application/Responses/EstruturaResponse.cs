namespace CPTM.GRD.Application.Responses;

public class EstruturaResponse
{
    public List<string?> Diretorias { get; set; } = new List<string?>();
    public List<string?> GerenciasGerais { get; set; } = new List<string?>();
    public List<string?> Gerencias { get; set; } = new List<string?>();
    public List<string?> Departamentos { get; set; } = new List<string?>();
}