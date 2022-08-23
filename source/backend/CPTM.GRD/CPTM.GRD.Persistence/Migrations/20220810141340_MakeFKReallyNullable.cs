using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTM.GRD.Persistence.Migrations
{
    public partial class MakeFKReallyNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcaoReuniao_ReuniaoId",
                schema: "GRD",
                table: "GRD_ACAO_REUNIAO");

            migrationBuilder.DropForeignKey(
                name: "FK_Acoes_Group",
                schema: "GRD",
                table: "GRD_ACOES");

            migrationBuilder.DropForeignKey(
                name: "FK_Acoes_User",
                schema: "GRD",
                table: "GRD_ACOES");

            migrationBuilder.DropForeignKey(
                name: "FK_Andamentos_Users",
                schema: "GRD",
                table: "GRD_ANDAMENTOS");

            migrationBuilder.DropForeignKey(
                name: "FK_LogsA_Acao",
                schema: "GRD",
                table: "GRD_LOGS_ACAO");

            migrationBuilder.DropForeignKey(
                name: "FK_LogsA_User",
                schema: "GRD",
                table: "GRD_LOGS_ACAO");

            migrationBuilder.DropForeignKey(
                name: "FK_LogsP_Proposicao",
                schema: "GRD",
                table: "GRD_LOGS_PROPOSICAO");

            migrationBuilder.DropForeignKey(
                name: "FK_LogsP_User",
                schema: "GRD",
                table: "GRD_LOGS_PROPOSICAO");

            migrationBuilder.DropForeignKey(
                name: "FK_LogsR_Reuniao",
                schema: "GRD",
                table: "GRD_LOGS_REUNIAO");

            migrationBuilder.DropForeignKey(
                name: "FK_LogsR_User",
                schema: "GRD",
                table: "GRD_LOGS_REUNIAO");

            migrationBuilder.DropForeignKey(
                name: "FK_PartReuniao_ReuniaoId",
                schema: "GRD",
                table: "GRD_PART_REUNIAO");

            migrationBuilder.DropForeignKey(
                name: "FK_Part_Group",
                schema: "GRD",
                table: "GRD_PARTICIPANTES");

            migrationBuilder.DropForeignKey(
                name: "FK_Part_User",
                schema: "GRD",
                table: "GRD_PARTICIPANTES");

            migrationBuilder.DropForeignKey(
                name: "FK_PartPrevReuniao_ReuId",
                schema: "GRD",
                table: "GRD_PARTPREV_REUNIAO");

            migrationBuilder.DropForeignKey(
                name: "FK_Proposicoes_Group",
                schema: "GRD",
                table: "GRD_PROPOSICOES");

            migrationBuilder.DropForeignKey(
                name: "FK_Proposicoes_User",
                schema: "GRD",
                table: "GRD_PROPOSICOES");

            migrationBuilder.DropForeignKey(
                name: "FK_Reunioes_Prop",
                schema: "GRD",
                table: "GRD_PROPOSICOES");

            migrationBuilder.DropForeignKey(
                name: "FK_Reunioes_PropPrev",
                schema: "GRD",
                table: "GRD_PROPOSICOES");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroup_UserId",
                schema: "GRD",
                table: "GRD_USER_GROUP");

            migrationBuilder.DropForeignKey(
                name: "FK_Votos_Part",
                schema: "GRD",
                table: "GRD_VOTOS");

            migrationBuilder.AddForeignKey(
                name: "FK_AcaoReuniao_ReuniaoId",
                schema: "GRD",
                table: "GRD_ACAO_REUNIAO",
                column: "ReuniaoId",
                principalSchema: "GRD",
                principalTable: "GRD_REUNIOES",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Acoes_Group",
                schema: "GRD",
                table: "GRD_ACOES",
                column: "DiretoriaResId",
                principalSchema: "GRD",
                principalTable: "GRD_GROUPS",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Acoes_User",
                schema: "GRD",
                table: "GRD_ACOES",
                column: "ResponsavelId",
                principalSchema: "GRD",
                principalTable: "GRD_USERS",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Andamentos_Users",
                schema: "GRD",
                table: "GRD_ANDAMENTOS",
                column: "UserId",
                principalSchema: "GRD",
                principalTable: "GRD_USERS",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_LogsA_Acao",
                schema: "GRD",
                table: "GRD_LOGS_ACAO",
                column: "AcaoId",
                principalSchema: "GRD",
                principalTable: "GRD_ACOES",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_LogsA_User",
                schema: "GRD",
                table: "GRD_LOGS_ACAO",
                column: "RespId",
                principalSchema: "GRD",
                principalTable: "GRD_USERS",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_LogsP_Proposicao",
                schema: "GRD",
                table: "GRD_LOGS_PROPOSICAO",
                column: "PropId",
                principalSchema: "GRD",
                principalTable: "GRD_PROPOSICOES",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_LogsP_User",
                schema: "GRD",
                table: "GRD_LOGS_PROPOSICAO",
                column: "RespId",
                principalSchema: "GRD",
                principalTable: "GRD_USERS",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_LogsR_Reuniao",
                schema: "GRD",
                table: "GRD_LOGS_REUNIAO",
                column: "ReuniaoId",
                principalSchema: "GRD",
                principalTable: "GRD_REUNIOES",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_LogsR_User",
                schema: "GRD",
                table: "GRD_LOGS_REUNIAO",
                column: "RespId",
                principalSchema: "GRD",
                principalTable: "GRD_USERS",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_PartReuniao_ReuniaoId",
                schema: "GRD",
                table: "GRD_PART_REUNIAO",
                column: "ReuniaoId",
                principalSchema: "GRD",
                principalTable: "GRD_REUNIOES",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Part_Group",
                schema: "GRD",
                table: "GRD_PARTICIPANTES",
                column: "AreaId",
                principalSchema: "GRD",
                principalTable: "GRD_GROUPS",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Part_User",
                schema: "GRD",
                table: "GRD_PARTICIPANTES",
                column: "UserId",
                principalSchema: "GRD",
                principalTable: "GRD_USERS",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_PartPrevReuniao_ReuId",
                schema: "GRD",
                table: "GRD_PARTPREV_REUNIAO",
                column: "ReuId",
                principalSchema: "GRD",
                principalTable: "GRD_REUNIOES",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Proposicoes_Group",
                schema: "GRD",
                table: "GRD_PROPOSICOES",
                column: "AreaId",
                principalSchema: "GRD",
                principalTable: "GRD_GROUPS",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Proposicoes_User",
                schema: "GRD",
                table: "GRD_PROPOSICOES",
                column: "CriadorId",
                principalSchema: "GRD",
                principalTable: "GRD_USERS",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Reunioes_Prop",
                schema: "GRD",
                table: "GRD_PROPOSICOES",
                column: "ReuniaoId",
                principalSchema: "GRD",
                principalTable: "GRD_REUNIOES",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Reunioes_PropPrev",
                schema: "GRD",
                table: "GRD_PROPOSICOES",
                column: "ReuniaoId1",
                principalSchema: "GRD",
                principalTable: "GRD_REUNIOES",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroup_UserId",
                schema: "GRD",
                table: "GRD_USER_GROUP",
                column: "UserId",
                principalSchema: "GRD",
                principalTable: "GRD_USERS",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Votos_Part",
                schema: "GRD",
                table: "GRD_VOTOS",
                column: "ParticipanteId",
                principalSchema: "GRD",
                principalTable: "GRD_PARTICIPANTES",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcaoReuniao_ReuniaoId",
                schema: "GRD",
                table: "GRD_ACAO_REUNIAO");

            migrationBuilder.DropForeignKey(
                name: "FK_Acoes_Group",
                schema: "GRD",
                table: "GRD_ACOES");

            migrationBuilder.DropForeignKey(
                name: "FK_Acoes_User",
                schema: "GRD",
                table: "GRD_ACOES");

            migrationBuilder.DropForeignKey(
                name: "FK_Andamentos_Users",
                schema: "GRD",
                table: "GRD_ANDAMENTOS");

            migrationBuilder.DropForeignKey(
                name: "FK_LogsA_Acao",
                schema: "GRD",
                table: "GRD_LOGS_ACAO");

            migrationBuilder.DropForeignKey(
                name: "FK_LogsA_User",
                schema: "GRD",
                table: "GRD_LOGS_ACAO");

            migrationBuilder.DropForeignKey(
                name: "FK_LogsP_Proposicao",
                schema: "GRD",
                table: "GRD_LOGS_PROPOSICAO");

            migrationBuilder.DropForeignKey(
                name: "FK_LogsP_User",
                schema: "GRD",
                table: "GRD_LOGS_PROPOSICAO");

            migrationBuilder.DropForeignKey(
                name: "FK_LogsR_Reuniao",
                schema: "GRD",
                table: "GRD_LOGS_REUNIAO");

            migrationBuilder.DropForeignKey(
                name: "FK_LogsR_User",
                schema: "GRD",
                table: "GRD_LOGS_REUNIAO");

            migrationBuilder.DropForeignKey(
                name: "FK_PartReuniao_ReuniaoId",
                schema: "GRD",
                table: "GRD_PART_REUNIAO");

            migrationBuilder.DropForeignKey(
                name: "FK_Part_Group",
                schema: "GRD",
                table: "GRD_PARTICIPANTES");

            migrationBuilder.DropForeignKey(
                name: "FK_Part_User",
                schema: "GRD",
                table: "GRD_PARTICIPANTES");

            migrationBuilder.DropForeignKey(
                name: "FK_PartPrevReuniao_ReuId",
                schema: "GRD",
                table: "GRD_PARTPREV_REUNIAO");

            migrationBuilder.DropForeignKey(
                name: "FK_Proposicoes_Group",
                schema: "GRD",
                table: "GRD_PROPOSICOES");

            migrationBuilder.DropForeignKey(
                name: "FK_Proposicoes_User",
                schema: "GRD",
                table: "GRD_PROPOSICOES");

            migrationBuilder.DropForeignKey(
                name: "FK_Reunioes_Prop",
                schema: "GRD",
                table: "GRD_PROPOSICOES");

            migrationBuilder.DropForeignKey(
                name: "FK_Reunioes_PropPrev",
                schema: "GRD",
                table: "GRD_PROPOSICOES");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroup_UserId",
                schema: "GRD",
                table: "GRD_USER_GROUP");

            migrationBuilder.DropForeignKey(
                name: "FK_Votos_Part",
                schema: "GRD",
                table: "GRD_VOTOS");

            migrationBuilder.AddForeignKey(
                name: "FK_AcaoReuniao_ReuniaoId",
                schema: "GRD",
                table: "GRD_ACAO_REUNIAO",
                column: "ReuniaoId",
                principalSchema: "GRD",
                principalTable: "GRD_REUNIOES",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Acoes_Group",
                schema: "GRD",
                table: "GRD_ACOES",
                column: "DiretoriaResId",
                principalSchema: "GRD",
                principalTable: "GRD_GROUPS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Acoes_User",
                schema: "GRD",
                table: "GRD_ACOES",
                column: "ResponsavelId",
                principalSchema: "GRD",
                principalTable: "GRD_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Andamentos_Users",
                schema: "GRD",
                table: "GRD_ANDAMENTOS",
                column: "UserId",
                principalSchema: "GRD",
                principalTable: "GRD_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LogsA_Acao",
                schema: "GRD",
                table: "GRD_LOGS_ACAO",
                column: "AcaoId",
                principalSchema: "GRD",
                principalTable: "GRD_ACOES",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LogsA_User",
                schema: "GRD",
                table: "GRD_LOGS_ACAO",
                column: "RespId",
                principalSchema: "GRD",
                principalTable: "GRD_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LogsP_Proposicao",
                schema: "GRD",
                table: "GRD_LOGS_PROPOSICAO",
                column: "PropId",
                principalSchema: "GRD",
                principalTable: "GRD_PROPOSICOES",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LogsP_User",
                schema: "GRD",
                table: "GRD_LOGS_PROPOSICAO",
                column: "RespId",
                principalSchema: "GRD",
                principalTable: "GRD_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LogsR_Reuniao",
                schema: "GRD",
                table: "GRD_LOGS_REUNIAO",
                column: "ReuniaoId",
                principalSchema: "GRD",
                principalTable: "GRD_REUNIOES",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LogsR_User",
                schema: "GRD",
                table: "GRD_LOGS_REUNIAO",
                column: "RespId",
                principalSchema: "GRD",
                principalTable: "GRD_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PartReuniao_ReuniaoId",
                schema: "GRD",
                table: "GRD_PART_REUNIAO",
                column: "ReuniaoId",
                principalSchema: "GRD",
                principalTable: "GRD_REUNIOES",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Part_Group",
                schema: "GRD",
                table: "GRD_PARTICIPANTES",
                column: "AreaId",
                principalSchema: "GRD",
                principalTable: "GRD_GROUPS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Part_User",
                schema: "GRD",
                table: "GRD_PARTICIPANTES",
                column: "UserId",
                principalSchema: "GRD",
                principalTable: "GRD_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PartPrevReuniao_ReuId",
                schema: "GRD",
                table: "GRD_PARTPREV_REUNIAO",
                column: "ReuId",
                principalSchema: "GRD",
                principalTable: "GRD_REUNIOES",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Proposicoes_Group",
                schema: "GRD",
                table: "GRD_PROPOSICOES",
                column: "AreaId",
                principalSchema: "GRD",
                principalTable: "GRD_GROUPS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Proposicoes_User",
                schema: "GRD",
                table: "GRD_PROPOSICOES",
                column: "CriadorId",
                principalSchema: "GRD",
                principalTable: "GRD_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reunioes_Prop",
                schema: "GRD",
                table: "GRD_PROPOSICOES",
                column: "ReuniaoId",
                principalSchema: "GRD",
                principalTable: "GRD_REUNIOES",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reunioes_PropPrev",
                schema: "GRD",
                table: "GRD_PROPOSICOES",
                column: "ReuniaoId1",
                principalSchema: "GRD",
                principalTable: "GRD_REUNIOES",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroup_UserId",
                schema: "GRD",
                table: "GRD_USER_GROUP",
                column: "UserId",
                principalSchema: "GRD",
                principalTable: "GRD_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Votos_Part",
                schema: "GRD",
                table: "GRD_VOTOS",
                column: "ParticipanteId",
                principalSchema: "GRD",
                principalTable: "GRD_PARTICIPANTES",
                principalColumn: "Id");
        }
    }
}
