using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTM.GRD.Persistence.Migrations
{
    public partial class FullModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GRD_REUNIOES",
                schema: "GRD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
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
                    PautaPreviaFilePath = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    MemoriaPreviaFilePath = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    PautaDefinitivaFilePath = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    RelatorioDeliberativoFilePath = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    AtaFilePath = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRD_REUNIOES", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GRD_LOGS_REUNIAO",
                schema: "GRD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Tipo = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ReuniaoId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Diferenca = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Data = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ReuniaoId1 = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRD_LOGS_REUNIAO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogsReuniao_Reuniao",
                        column: x => x.ReuniaoId1,
                        principalSchema: "GRD",
                        principalTable: "GRD_REUNIOES",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GRD_PROPOSICOES",
                schema: "GRD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    IdPrd = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Arquivada = table.Column<bool>(type: "NUMBER(1)", nullable: false),
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
                    ReuniaoId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AnotacoesPrevia = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    AjustesRd = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    MotivoRetornoGrg = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    MotivoRetornoDiretoriaResp = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Deliberacao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
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
                    OutrosFilePath = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ResolucaoDiretoriaFilePath = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    AreaAtual = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DescricaoFluxo = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TempoPrevPerm = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DescProxPasso = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TempoPermProx = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Seq = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    ReuniaoId1 = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRD_PROPOSICOES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reunioes_Proposicao",
                        column: x => x.ReuniaoId,
                        principalSchema: "GRD",
                        principalTable: "GRD_REUNIOES",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reunioes_ProposicaoPrev",
                        column: x => x.ReuniaoId1,
                        principalSchema: "GRD",
                        principalTable: "GRD_REUNIOES",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GRD_LOGS_PROPOSICAO",
                schema: "GRD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Tipo = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ProposicaoId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Diferenca = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Data = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    ProposicaoId1 = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRD_LOGS_PROPOSICAO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogsProposicao_Proposicao",
                        column: x => x.ProposicaoId1,
                        principalSchema: "GRD",
                        principalTable: "GRD_PROPOSICOES",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GRD_RESOLUCOES",
                schema: "GRD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NumeroResolucao = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AssinaturaResolucao = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ResolucaoDiretoria = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ResolucaoFilePath = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ProposicaoId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRD_RESOLUCOES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RESOLUCOES_PROPOSICOES",
                        column: x => x.ProposicaoId,
                        principalSchema: "GRD",
                        principalTable: "GRD_PROPOSICOES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GRD_VOTOS",
                schema: "GRD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
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
                });

            migrationBuilder.CreateTable(
                name: "GRD_PARTICIPANTES",
                schema: "GRD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ReuniaoId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    ReuniaoId1 = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRD_PARTICIPANTES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reunioes_Participante",
                        column: x => x.ReuniaoId,
                        principalSchema: "GRD",
                        principalTable: "GRD_REUNIOES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reunioes_ParticipantePrev",
                        column: x => x.ReuniaoId1,
                        principalSchema: "GRD",
                        principalTable: "GRD_REUNIOES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Votos_Participante",
                        column: x => x.Id,
                        principalSchema: "GRD",
                        principalTable: "GRD_VOTOS",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GRD_ACOES",
                schema: "GRD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Tipo = table.Column<int>(type: "NUMBER(10)", nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "GRD_ANDAMENTOS",
                schema: "GRD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Data = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
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
                });

            migrationBuilder.CreateTable(
                name: "GRD_LOGS_ACAO",
                schema: "GRD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Tipo = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AcaoId = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Diferenca = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Data = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    AcaoId1 = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRD_LOGS_ACAO", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogsAcao_Acao",
                        column: x => x.AcaoId1,
                        principalSchema: "GRD",
                        principalTable: "GRD_ACOES",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ReuniaoAcao",
                schema: "GRD",
                columns: table => new
                {
                    AcoesId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    ReunioesId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReuniaoAcao", x => new { x.AcoesId, x.ReunioesId });
                    table.ForeignKey(
                        name: "FK_ReuniaoAcao_GRD_ACOES",
                        column: x => x.AcoesId,
                        principalSchema: "GRD",
                        principalTable: "GRD_ACOES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReuniaoAcao_GRD_REUNIOES",
                        column: x => x.ReunioesId,
                        principalSchema: "GRD",
                        principalTable: "GRD_REUNIOES",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    Diretoria = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ParticipanteId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    ProposicaoId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    UserId = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRD_GROUPS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Acoes_Group",
                        column: x => x.Id,
                        principalSchema: "GRD",
                        principalTable: "GRD_ACOES",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Participantes_Group",
                        column: x => x.ParticipanteId,
                        principalSchema: "GRD",
                        principalTable: "GRD_PARTICIPANTES",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Proposicoes_Group",
                        column: x => x.ProposicaoId,
                        principalSchema: "GRD",
                        principalTable: "GRD_PROPOSICOES",
                        principalColumn: "Id");
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
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    AndamentoId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    LogAcaoId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    LogProposicaoId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    LogReuniaoId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    ParticipanteId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    ProposicaoId = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRD_USERS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Andamentos_Users",
                        column: x => x.AndamentoId,
                        principalSchema: "GRD",
                        principalTable: "GRD_ANDAMENTOS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Groups_User",
                        column: x => x.Id,
                        principalSchema: "GRD",
                        principalTable: "GRD_GROUPS",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LogsAcao_User",
                        column: x => x.LogAcaoId,
                        principalSchema: "GRD",
                        principalTable: "GRD_LOGS_ACAO",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LogsProposicao_User",
                        column: x => x.LogProposicaoId,
                        principalSchema: "GRD",
                        principalTable: "GRD_LOGS_PROPOSICAO",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LogsReuniao_User",
                        column: x => x.LogReuniaoId,
                        principalSchema: "GRD",
                        principalTable: "GRD_LOGS_REUNIAO",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Participantes_User",
                        column: x => x.ParticipanteId,
                        principalSchema: "GRD",
                        principalTable: "GRD_PARTICIPANTES",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Proposicoes_User",
                        column: x => x.ProposicaoId,
                        principalSchema: "GRD",
                        principalTable: "GRD_PROPOSICOES",
                        principalColumn: "Id");
                });

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
                name: "IX_GRD_GROUPS_ParticipanteId",
                schema: "GRD",
                table: "GRD_GROUPS",
                column: "ParticipanteId",
                unique: true,
                filter: "\"ParticipanteId\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GRD_GROUPS_ProposicaoId",
                schema: "GRD",
                table: "GRD_GROUPS",
                column: "ProposicaoId",
                unique: true,
                filter: "\"ProposicaoId\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GRD_GROUPS_UserId",
                schema: "GRD",
                table: "GRD_GROUPS",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_GRD_LOGS_ACAO_AcaoId1",
                schema: "GRD",
                table: "GRD_LOGS_ACAO",
                column: "AcaoId1");

            migrationBuilder.CreateIndex(
                name: "IX_GRD_LOGS_PROPOSICAO_PropId1",
                schema: "GRD",
                table: "GRD_LOGS_PROPOSICAO",
                column: "ProposicaoId1");

            migrationBuilder.CreateIndex(
                name: "IX_GRD_LOGS_REUNIAO_ReuniaoId1",
                schema: "GRD",
                table: "GRD_LOGS_REUNIAO",
                column: "ReuniaoId1");

            migrationBuilder.CreateIndex(
                name: "IX_GRD_PARTICIPANTES_ReuniaoId",
                schema: "GRD",
                table: "GRD_PARTICIPANTES",
                column: "ReuniaoId");

            migrationBuilder.CreateIndex(
                name: "IX_GRD_PARTICIPANTES_ReuniaId1",
                schema: "GRD",
                table: "GRD_PARTICIPANTES",
                column: "ReuniaoId1");

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
                name: "IX_GRD_RESOLUCOES_ProposicaoId",
                schema: "GRD",
                table: "GRD_RESOLUCOES",
                column: "ProposicaoId");

            migrationBuilder.CreateIndex(
                name: "IX_GRD_USERS_AndamentoId",
                schema: "GRD",
                table: "GRD_USERS",
                column: "AndamentoId",
                unique: true,
                filter: "\"AndamentoId\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GRD_USERS_LogAcaoId",
                schema: "GRD",
                table: "GRD_USERS",
                column: "LogAcaoId",
                unique: true,
                filter: "\"LogAcaoId\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GRD_USERS_LogProposicaoId",
                schema: "GRD",
                table: "GRD_USERS",
                column: "LogProposicaoId",
                unique: true,
                filter: "\"LogProposicaoId\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GRD_USERS_LogReuniaoId",
                schema: "GRD",
                table: "GRD_USERS",
                column: "LogReuniaoId",
                unique: true,
                filter: "\"LogReuniaoId\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GRD_USERS_ParticipanteId",
                schema: "GRD",
                table: "GRD_USERS",
                column: "ParticipanteId",
                unique: true,
                filter: "\"ParticipanteId\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GRD_USERS_ProposicaoId",
                schema: "GRD",
                table: "GRD_USERS",
                column: "ProposicaoId",
                unique: true,
                filter: "\"ProposicaoId\" IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GRD_VOTOS_ProposicaoId",
                schema: "GRD",
                table: "GRD_VOTOS",
                column: "ProposicaoId");

            migrationBuilder.CreateIndex(
                name: "IX_ReuniaoAcao_ReunioesId",
                schema: "GRD",
                table: "ReuniaoAcao",
                column: "ReunioesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ACOES_USERS_ResponsavelId",
                schema: "GRD",
                table: "GRD_ACOES",
                column: "ResponsavelId",
                principalSchema: "GRD",
                principalTable: "GRD_USERS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Group",
                schema: "GRD",
                table: "GRD_GROUPS",
                column: "UserId",
                principalSchema: "GRD",
                principalTable: "GRD_USERS",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GRD_ACOES_GRD_USERS_ResponsavelId",
                schema: "GRD",
                table: "GRD_ACOES");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Group",
                schema: "GRD",
                table: "GRD_GROUPS");

            migrationBuilder.DropTable(
                name: "GRD_RESOLUCOES",
                schema: "GRD");

            migrationBuilder.DropTable(
                name: "ReuniaoAcao",
                schema: "GRD");

            migrationBuilder.DropTable(
                name: "GRD_USERS",
                schema: "GRD");

            migrationBuilder.DropTable(
                name: "GRD_ANDAMENTOS",
                schema: "GRD");

            migrationBuilder.DropTable(
                name: "GRD_GROUPS",
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
                name: "GRD_PARTICIPANTES",
                schema: "GRD");

            migrationBuilder.DropTable(
                name: "GRD_ACOES",
                schema: "GRD");

            migrationBuilder.DropTable(
                name: "GRD_VOTOS",
                schema: "GRD");

            migrationBuilder.DropTable(
                name: "GRD_PROPOSICOES",
                schema: "GRD");

            migrationBuilder.DropTable(
                name: "GRD_REUNIOES",
                schema: "GRD");
        }
    }
}
