using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTM.GRD.Persistence.Migrations
{
    public partial class FullModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence(
                name: "SEQ_ACOES",
                schema: "GRD",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "SEQ_ANDAMENTOS",
                schema: "GRD",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "SEQ_GROUPS",
                schema: "GRD",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "SEQ_LOGS_ACAO",
                schema: "GRD",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "SEQ_LOGS_PROPOSICAO",
                schema: "GRD",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "SEQ_LOGS_REUNIAO",
                schema: "GRD",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "SEQ_PARTICIPANTES",
                schema: "GRD",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "SEQ_PROPOSICOES",
                schema: "GRD",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "SEQ_RESOLUCOES",
                schema: "GRD",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "SEQ_REUNIOES",
                schema: "GRD",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "SEQ_USERS",
                schema: "GRD",
                incrementBy: 10);

            migrationBuilder.CreateSequence(
                name: "SEQ_VOTOS",
                schema: "GRD",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "GRD_GROUPS",
                schema: "GRD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Sigla = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    SiglaGerencia = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: false),
                    Gerencia = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    SiglaDiretoria = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: false),
                    Diretoria = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRD_GROUPS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GRD_RESOLUCOES",
                schema: "GRD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    NumeroResolucao = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AssinaturaResolucao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ResolucaoDiretoria = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ResolucaoFilePath = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRD_RESOLUCOES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GRD_REUNIOES",
                schema: "GRD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    NumeroReuniao = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Data = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Horario = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DataPrevia = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    HorarioPrevia = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Local = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TipoReuniao = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Comunicado = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    OutrasObservacoes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    MensagemEMail = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PautaPreviaFilePath = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    MemoriaPreviaFilePath = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PautaDefinitivaFilePath = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    RelatorioDeliberativoFilePath = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    AtaFilePath = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRD_REUNIOES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GRD_USERS",
                schema: "GRD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    UsernameAd = table.Column<string>(type: "NVARCHAR2(250)", maxLength: 250, nullable: false),
                    NivelAcesso = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Funcao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRD_USERS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GRD_ACOES",
                schema: "GRD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Tipo = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DiretoriaResId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Definicao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Periodicidade = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PrazoInicial = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Arquivada = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    ResponsavelId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    EmailDiretor = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NumeroContrato = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Fornecedor = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    PrazoProrrogadoDias = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PrazoFinal = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DiasParaVencimento = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AlertaVencimento = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRD_ACOES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acoes_Group",
                        column: x => x.DiretoriaResId,
                        principalSchema: "GRD",
                        principalTable: "GRD_GROUPS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Acoes_User",
                        column: x => x.ResponsavelId,
                        principalSchema: "GRD",
                        principalTable: "GRD_USERS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GRD_LOGS_REUNIAO",
                schema: "GRD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Tipo = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ReuniaoRef = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Diferenca = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Data = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    RespId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ReuniaoId = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRD_LOGS_REUNIAO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogsR_Reuniao",
                        column: x => x.ReuniaoId,
                        principalSchema: "GRD",
                        principalTable: "GRD_REUNIOES",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LogsR_User",
                        column: x => x.RespId,
                        principalSchema: "GRD",
                        principalTable: "GRD_USERS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GRD_PARTICIPANTES",
                schema: "GRD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    UserId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AreaId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRD_PARTICIPANTES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Part_Group",
                        column: x => x.AreaId,
                        principalSchema: "GRD",
                        principalTable: "GRD_GROUPS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Part_User",
                        column: x => x.UserId,
                        principalSchema: "GRD",
                        principalTable: "GRD_USERS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GRD_PROPOSICOES",
                schema: "GRD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IdPrd = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Arquivada = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CriadorId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AreaId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Titulo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Objeto = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DescricaoProposicao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PossuiParecerJuridico = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    ResumoGeralResolucao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ObservacoesCustos = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CompetenciasConformeNormas = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DataBaseValor = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    Moeda = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ValorOriginalContrato = table.Column<float>(type: "BINARY_FLOAT", nullable: false),
                    ValorTotalProposicao = table.Column<float>(type: "BINARY_FLOAT", nullable: false),
                    ReceitaDespesa = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    NumeroContrato = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Termo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Fornecedor = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ValorAtualContrato = table.Column<float>(type: "BINARY_FLOAT", nullable: false),
                    NumeroReservaVerba = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ValorReservaVerba = table.Column<float>(type: "BINARY_FLOAT", nullable: false),
                    InicioVigenciaReserva = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    FimVigenciaReserva = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    NumeroProposicao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ProtoloExpediente = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NumeroProcessoLicit = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    OutrasObservacoes = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ReuniaoId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    AnotacoesPrevia = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    AjustesRd = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    MotivoRetornoGrg = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    MotivoRetornoDiretoriaResp = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Deliberacao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    IsExtraPauta = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    NumeroConselho = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    SinteseProcessoFilePath = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NotaTecnicaFilePath = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PrdFilePath = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ParecerJuridicoFilePath = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TrFilePath = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    RelatorioTecnicoFilePath = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PlanilhaQuantFilePath = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EditalFilePath = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ReservaVerbaFilePath = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ScFilePath = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    RavFilePath = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CronogramaFisFinFilePath = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PcaFilePath = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    OutrosFilePath = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    ResolucaoDiretoriaFilePath = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    AreaAtual = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DescricaoFluxo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TempoPrevPerm = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    DescProxPasso = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    TempoPermProx = table.Column<string>(type: "NVARCHAR2(2000)", nullable: true),
                    Seq = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    ReuniaoId1 = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRD_PROPOSICOES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proposicoes_Group",
                        column: x => x.AreaId,
                        principalSchema: "GRD",
                        principalTable: "GRD_GROUPS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Proposicoes_User",
                        column: x => x.CriadorId,
                        principalSchema: "GRD",
                        principalTable: "GRD_USERS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reunioes_Prop",
                        column: x => x.ReuniaoId,
                        principalSchema: "GRD",
                        principalTable: "GRD_REUNIOES",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reunioes_PropPrev",
                        column: x => x.ReuniaoId1,
                        principalSchema: "GRD",
                        principalTable: "GRD_REUNIOES",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GRD_USER_GROUP",
                schema: "GRD",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    UserId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRD_USER_GROUP", x => new { x.GroupId, x.UserId });
                    table.ForeignKey(
                        name: "FK_UserGroup_GroupId",
                        column: x => x.GroupId,
                        principalSchema: "GRD",
                        principalTable: "GRD_GROUPS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_UserGroup_UserId",
                        column: x => x.UserId,
                        principalSchema: "GRD",
                        principalTable: "GRD_USERS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GRD_ACAO_REUNIAO",
                schema: "GRD",
                columns: table => new
                {
                    AcaoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ReuniaoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRD_ACAO_REUNIAO", x => new { x.AcaoId, x.ReuniaoId });
                    table.ForeignKey(
                        name: "FK_AcaoReuniao_AcaoId",
                        column: x => x.AcaoId,
                        principalSchema: "GRD",
                        principalTable: "GRD_ACOES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_AcaoReuniao_ReuniaoId",
                        column: x => x.ReuniaoId,
                        principalSchema: "GRD",
                        principalTable: "GRD_REUNIOES",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GRD_ANDAMENTOS",
                schema: "GRD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Data = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    UserId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    NomeResponsavel = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    AnexosFilePaths = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    AcaoId = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRD_ANDAMENTOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acoes_Andamento",
                        column: x => x.AcaoId,
                        principalSchema: "GRD",
                        principalTable: "GRD_ACOES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Andamentos_Users",
                        column: x => x.UserId,
                        principalSchema: "GRD",
                        principalTable: "GRD_USERS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GRD_LOGS_ACAO",
                schema: "GRD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Tipo = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AcaoRef = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Diferenca = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Data = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    RespId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AcaoId = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRD_LOGS_ACAO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogsA_Acao",
                        column: x => x.AcaoId,
                        principalSchema: "GRD",
                        principalTable: "GRD_ACOES",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LogsA_User",
                        column: x => x.RespId,
                        principalSchema: "GRD",
                        principalTable: "GRD_USERS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GRD_PART_REUNIAO",
                schema: "GRD",
                columns: table => new
                {
                    PartId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ReuniaoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRD_PART_REUNIAO", x => new { x.PartId, x.ReuniaoId });
                    table.ForeignKey(
                        name: "FK_PartReuniao_PartId",
                        column: x => x.PartId,
                        principalSchema: "GRD",
                        principalTable: "GRD_PARTICIPANTES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_PartReuniao_ReuniaoId",
                        column: x => x.ReuniaoId,
                        principalSchema: "GRD",
                        principalTable: "GRD_REUNIOES",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GRD_PARTPREV_REUNIAO",
                schema: "GRD",
                columns: table => new
                {
                    PartId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ReuId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRD_PARTPREV_REUNIAO", x => new { x.PartId, x.ReuId });
                    table.ForeignKey(
                        name: "FK_PartPrevReuniao_PartId",
                        column: x => x.PartId,
                        principalSchema: "GRD",
                        principalTable: "GRD_PARTICIPANTES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_PartPrevReuniao_ReuId",
                        column: x => x.ReuId,
                        principalSchema: "GRD",
                        principalTable: "GRD_REUNIOES",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GRD_LOGS_PROPOSICAO",
                schema: "GRD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Tipo = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ProposicaoRef = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Diferenca = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Data = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    RespId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    PropId = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRD_LOGS_PROPOSICAO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogsP_Proposicao",
                        column: x => x.PropId,
                        principalSchema: "GRD",
                        principalTable: "GRD_PROPOSICOES",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LogsP_User",
                        column: x => x.RespId,
                        principalSchema: "GRD",
                        principalTable: "GRD_USERS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GRD_VOTOS",
                schema: "GRD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ParticipanteId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    VotoRd = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ProposicaoId = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRD_VOTOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proposicoes_Voto",
                        column: x => x.ProposicaoId,
                        principalSchema: "GRD",
                        principalTable: "GRD_PROPOSICOES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Votos_Part",
                        column: x => x.ParticipanteId,
                        principalSchema: "GRD",
                        principalTable: "GRD_PARTICIPANTES",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_GRD_ACAO_REUNIAO_ReuniaoId",
                schema: "GRD",
                table: "GRD_ACAO_REUNIAO",
                column: "ReuniaoId");

            migrationBuilder.CreateIndex(
                name: "IX_GRD_ACOES_DiretoriaResId",
                schema: "GRD",
                table: "GRD_ACOES",
                column: "DiretoriaResId");

            migrationBuilder.CreateIndex(
                name: "IX_GRD_ACOES_ResponsavelId",
                schema: "GRD",
                table: "GRD_ACOES",
                column: "ResponsavelId");

            migrationBuilder.CreateIndex(
                name: "IX_GRD_ANDAMENTOS_AcaoId",
                schema: "GRD",
                table: "GRD_ANDAMENTOS",
                column: "AcaoId");

            migrationBuilder.CreateIndex(
                name: "IX_GRD_ANDAMENTOS_UserId",
                schema: "GRD",
                table: "GRD_ANDAMENTOS",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GRD_LOGS_ACAO_AcaoId",
                schema: "GRD",
                table: "GRD_LOGS_ACAO",
                column: "AcaoId");

            migrationBuilder.CreateIndex(
                name: "IX_GRD_LOGS_ACAO_RespId",
                schema: "GRD",
                table: "GRD_LOGS_ACAO",
                column: "RespId");

            migrationBuilder.CreateIndex(
                name: "IX_GRD_LOGS_PROPOSICAO_PropId",
                schema: "GRD",
                table: "GRD_LOGS_PROPOSICAO",
                column: "PropId");

            migrationBuilder.CreateIndex(
                name: "IX_GRD_LOGS_PROPOSICAO_RespId",
                schema: "GRD",
                table: "GRD_LOGS_PROPOSICAO",
                column: "RespId");

            migrationBuilder.CreateIndex(
                name: "IX_GRD_LOGS_REUNIAO_RespId",
                schema: "GRD",
                table: "GRD_LOGS_REUNIAO",
                column: "RespId");

            migrationBuilder.CreateIndex(
                name: "IX_GRD_LOGS_REUNIAO_ReuniaoId",
                schema: "GRD",
                table: "GRD_LOGS_REUNIAO",
                column: "ReuniaoId");

            migrationBuilder.CreateIndex(
                name: "IX_GRD_PART_REUNIAO_ReuniaoId",
                schema: "GRD",
                table: "GRD_PART_REUNIAO",
                column: "ReuniaoId");

            migrationBuilder.CreateIndex(
                name: "IX_GRD_PARTICIPANTES_AreaId",
                schema: "GRD",
                table: "GRD_PARTICIPANTES",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_GRD_PARTICIPANTES_UserId",
                schema: "GRD",
                table: "GRD_PARTICIPANTES",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GRD_PARTPREV_REUNIAO_ReuId",
                schema: "GRD",
                table: "GRD_PARTPREV_REUNIAO",
                column: "ReuId");

            migrationBuilder.CreateIndex(
                name: "IX_GRD_PROPOSICOES_AreaId",
                schema: "GRD",
                table: "GRD_PROPOSICOES",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_GRD_PROPOSICOES_CriadorId",
                schema: "GRD",
                table: "GRD_PROPOSICOES",
                column: "CriadorId");

            migrationBuilder.CreateIndex(
                name: "IX_GRD_PROPOSICOES_ReuniaoId",
                schema: "GRD",
                table: "GRD_PROPOSICOES",
                column: "ReuniaoId");

            migrationBuilder.CreateIndex(
                name: "IX_GRD_PROPOSICOES_ReuniaoId1",
                schema: "GRD",
                table: "GRD_PROPOSICOES",
                column: "ReuniaoId1");

            migrationBuilder.CreateIndex(
                name: "IX_GRD_USER_GROUP_UserId",
                schema: "GRD",
                table: "GRD_USER_GROUP",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GRD_VOTOS_ParticipanteId",
                schema: "GRD",
                table: "GRD_VOTOS",
                column: "ParticipanteId");

            migrationBuilder.CreateIndex(
                name: "IX_GRD_VOTOS_ProposicaoId",
                schema: "GRD",
                table: "GRD_VOTOS",
                column: "ProposicaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GRD_ACAO_REUNIAO",
                schema: "GRD");

            migrationBuilder.DropTable(
                name: "GRD_ANDAMENTOS",
                schema: "GRD");

            migrationBuilder.DropTable(
                name: "GRD_LOGS_ACAO",
                schema: "GRD");

            migrationBuilder.DropTable(
                name: "GRD_LOGS_PROPOSICAO",
                schema: "GRD");

            migrationBuilder.DropTable(
                name: "GRD_LOGS_REUNIAO",
                schema: "GRD");

            migrationBuilder.DropTable(
                name: "GRD_PART_REUNIAO",
                schema: "GRD");

            migrationBuilder.DropTable(
                name: "GRD_PARTPREV_REUNIAO",
                schema: "GRD");

            migrationBuilder.DropTable(
                name: "GRD_RESOLUCOES",
                schema: "GRD");

            migrationBuilder.DropTable(
                name: "GRD_USER_GROUP",
                schema: "GRD");

            migrationBuilder.DropTable(
                name: "GRD_VOTOS",
                schema: "GRD");

            migrationBuilder.DropTable(
                name: "GRD_ACOES",
                schema: "GRD");

            migrationBuilder.DropTable(
                name: "GRD_PROPOSICOES",
                schema: "GRD");

            migrationBuilder.DropTable(
                name: "GRD_PARTICIPANTES",
                schema: "GRD");

            migrationBuilder.DropTable(
                name: "GRD_REUNIOES",
                schema: "GRD");

            migrationBuilder.DropTable(
                name: "GRD_GROUPS",
                schema: "GRD");

            migrationBuilder.DropTable(
                name: "GRD_USERS",
                schema: "GRD");

            migrationBuilder.DropSequence(
                name: "SEQ_ACOES",
                schema: "GRD");

            migrationBuilder.DropSequence(
                name: "SEQ_ANDAMENTOS",
                schema: "GRD");

            migrationBuilder.DropSequence(
                name: "SEQ_GROUPS",
                schema: "GRD");

            migrationBuilder.DropSequence(
                name: "SEQ_LOGS_ACAO",
                schema: "GRD");

            migrationBuilder.DropSequence(
                name: "SEQ_LOGS_PROPOSICAO",
                schema: "GRD");

            migrationBuilder.DropSequence(
                name: "SEQ_LOGS_REUNIAO",
                schema: "GRD");

            migrationBuilder.DropSequence(
                name: "SEQ_PARTICIPANTES",
                schema: "GRD");

            migrationBuilder.DropSequence(
                name: "SEQ_PROPOSICOES",
                schema: "GRD");

            migrationBuilder.DropSequence(
                name: "SEQ_RESOLUCOES",
                schema: "GRD");

            migrationBuilder.DropSequence(
                name: "SEQ_REUNIOES",
                schema: "GRD");

            migrationBuilder.DropSequence(
                name: "SEQ_USERS",
                schema: "GRD");

            migrationBuilder.DropSequence(
                name: "SEQ_VOTOS",
                schema: "GRD");
        }
    }
}
