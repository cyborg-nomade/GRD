// See https://aka.ms/new-console-template for more information

using CPTM.GRD.Application.DTOs.Main.Proposicao;
using CPTM.GRD.Application.Responses;
using CPTM.GRD.Common;
using Newtonsoft.Json;
using RestSharp;

Console.WriteLine("Hello, World!");

#region use case: 001. user logs in

var client = new RestClient("https://localhost:7001/GRD/api");

var loginRequest = new RestRequest("users/login", Method.Post);
loginRequest.AddHeader("Content-Type", "application/json");
loginRequest.AddBody(new { username = "urielf", password = "W$BcEbrgq33!" });

var loginResponse = await client.ExecuteAsync<AuthResponse>(loginRequest);

var token = loginResponse.Data?.Token;
var user = loginResponse.Data?.User;

Console.WriteLine(token);
Console.WriteLine(user?.ToString());

#endregion

#region use case: 002. user creates proposicao

var createProposicaoRequest = new RestRequest("proposicoes", Method.Post);
createProposicaoRequest.AddHeader("Content-Type", "application/json");
createProposicaoRequest.AddHeader("Authorization", "Bearer " + token);

var proposicaoToCreate = new CreateProposicaoDto()
{
    Criador = user!,
    Area = user!.AreasAcesso.First(),
    Titulo = "Teste",
    DescricaoProposicao = "teste1",
    PossuiParecerJuridico = false,
    ResumoGeralResolucao = "teste1",
    ObservacoesCustos = "teste",
    CompetenciasConformeNormas = "teste",
    DataBaseValor = DateTime.Now,
    Moeda = "real",
    ValorOriginalContrato = 100f,
    ValorTotalProposicao = 100f,
    NumeroContrato = "100",
    Termo = "teste",
    Fornecedor = "fornecedor teste",
    ValorAtualContrato = 100f,
    NumeroReservaVerba = "100",
    ValorReservaVerba = 100f,
    InicioVigenciaReserva = DateTime.Now.AddDays(-1),
    FimVigenciaReserva = DateTime.Now.AddDays(1),
    NumeroProposicao = "1000",
    ProtocoloExpediente = "1000f",
    NumeroProcessoLicit = "1f1",
    CronogramaFisFinFilePath = "C:\\",
    EditalFilePath = "C:\\",
    NotaTecnicaFilePath = "C:\\",
    ParecerJuridicoFilePath = "C:\\",
    PcaFilePath = "C:\\",
    PlanilhaQuantFilePath = "C:\\",
    PrdFilePath = "C:\\",
    RavFilePath = "C:\\",
    RelatorioTecnicoFilePath = "C:\\",
    ReservaVerbaFilePath = "C:\\",
    ScFilePath = "C:\\",
    SinteseProcessoFilePath = "C:\\",
    TrFilePath = "C:\\",
    Objeto = ObjetoProposicao.Aditamento
};

createProposicaoRequest.AddBody(JsonConvert.SerializeObject(proposicaoToCreate));

try
{
    var createProposicaoResponse = await client.ExecuteAsync<ProposicaoDto>(createProposicaoRequest);

    Console.WriteLine(createProposicaoResponse.Data);
}
catch (Exception e)
{
    Console.WriteLine(e);
    Console.WriteLine("oops");
}

#endregion