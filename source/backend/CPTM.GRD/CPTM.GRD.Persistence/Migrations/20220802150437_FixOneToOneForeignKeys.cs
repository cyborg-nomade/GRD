using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTM.GRD.Persistence.Migrations
{
    public partial class FixOneToOneForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acoes_Group",
                schema: "GRD",
                table: "GRD_GROUPS");

            migrationBuilder.DropForeignKey(
                name: "FK_Participantes_Group",
                schema: "GRD",
                table: "GRD_GROUPS");

            migrationBuilder.DropForeignKey(
                name: "FK_Proposicoes_Group",
                schema: "GRD",
                table: "GRD_GROUPS");

            migrationBuilder.DropForeignKey(
                name: "FK_Votos_Participante",
                schema: "GRD",
                table: "GRD_PARTICIPANTES");

            migrationBuilder.DropForeignKey(
                name: "FK_Andamentos_Users",
                schema: "GRD",
                table: "GRD_USERS");

            migrationBuilder.DropForeignKey(
                name: "FK_LogsAcao_User",
                schema: "GRD",
                table: "GRD_USERS");

            migrationBuilder.DropForeignKey(
                name: "FK_LogsProposicao_User",
                schema: "GRD",
                table: "GRD_USERS");

            migrationBuilder.DropForeignKey(
                name: "FK_LogsReuniao_User",
                schema: "GRD",
                table: "GRD_USERS");

            migrationBuilder.DropForeignKey(
                name: "FK_Participantes_User",
                schema: "GRD",
                table: "GRD_USERS");

            migrationBuilder.DropForeignKey(
                name: "FK_Proposicoes_User",
                schema: "GRD",
                table: "GRD_USERS");

            migrationBuilder.DropIndex(
                name: "IX_GRD_USERS_LogAcaoId",
                schema: "GRD",
                table: "GRD_USERS");

            migrationBuilder.DropIndex(
                name: "IX_GRD_USERS_LogProposicaoId",
                schema: "GRD",
                table: "GRD_USERS");

            migrationBuilder.DropIndex(
                name: "IX_GRD_USERS_LogReuniaoId",
                schema: "GRD",
                table: "GRD_USERS");

            migrationBuilder.DropIndex(
                name: "IX_GRD_USERS_ParticipanteId",
                schema: "GRD",
                table: "GRD_USERS");

            migrationBuilder.DropIndex(
                name: "IX_GRD_USERS_ProposicaoId",
                schema: "GRD",
                table: "GRD_USERS");

            migrationBuilder.DropIndex(
                name: "IX_GRD_GROUPS_ParticipanteId",
                schema: "GRD",
                table: "GRD_GROUPS");

            migrationBuilder.DropIndex(
                name: "IX_GRD_GROUPS_ProposicaoId",
                schema: "GRD",
                table: "GRD_GROUPS");

            migrationBuilder.DropColumn(
                name: "LogAcaoId",
                schema: "GRD",
                table: "GRD_USERS");

            migrationBuilder.DropColumn(
                name: "LogProposicaoId",
                schema: "GRD",
                table: "GRD_USERS");

            migrationBuilder.DropColumn(
                name: "LogReuniaoId",
                schema: "GRD",
                table: "GRD_USERS");

            migrationBuilder.DropColumn(
                name: "ParticipanteId",
                schema: "GRD",
                table: "GRD_USERS");

            migrationBuilder.DropColumn(
                name: "ProposicaoId",
                schema: "GRD",
                table: "GRD_USERS");

            migrationBuilder.DropColumn(
                name: "ParticipanteId",
                schema: "GRD",
                table: "GRD_GROUPS");

            migrationBuilder.DropColumn(
                name: "ProposicaoId",
                schema: "GRD",
                table: "GRD_GROUPS");

            migrationBuilder.AddColumn<int>(
                name: "ParticipanteId",
                schema: "GRD",
                table: "GRD_VOTOS",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "GRD",
                table: "GRD_USERS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AddColumn<int>(
                name: "AreaSolicitanteId",
                schema: "GRD",
                table: "GRD_PROPOSICOES",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CriadorId",
                schema: "GRD",
                table: "GRD_PROPOSICOES",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "GRD",
                table: "GRD_PARTICIPANTES",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AddColumn<int>(
                name: "DiretoriaAreaId",
                schema: "GRD",
                table: "GRD_PARTICIPANTES",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                schema: "GRD",
                table: "GRD_PARTICIPANTES",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioRespId",
                schema: "GRD",
                table: "GRD_LOGS_REUNIAO",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioRespId",
                schema: "GRD",
                table: "GRD_LOGS_PROPOSICAO",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioRespId",
                schema: "GRD",
                table: "GRD_LOGS_ACAO",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "GRD",
                table: "GRD_GROUPS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                schema: "GRD",
                table: "GRD_ANDAMENTOS",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DiretoriaResId",
                schema: "GRD",
                table: "GRD_ACOES",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_GRD_VOTOS_ParticipanteId",
                schema: "GRD",
                table: "GRD_VOTOS",
                column: "ParticipanteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GRD_PROPOSICOES_AreaSolicitanteId",
                schema: "GRD",
                table: "GRD_PROPOSICOES",
                column: "AreaSolicitanteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GRD_PROPOSICOES_CriadorId",
                schema: "GRD",
                table: "GRD_PROPOSICOES",
                column: "CriadorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GRD_PARTICIPANTES_DiretoriaAreaId",
                schema: "GRD",
                table: "GRD_PARTICIPANTES",
                column: "DiretoriaAreaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GRD_PARTICIPANTES_UserId",
                schema: "GRD",
                table: "GRD_PARTICIPANTES",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GRD_LOGS_REUNIAO_UsuarioRespId",
                schema: "GRD",
                table: "GRD_LOGS_REUNIAO",
                column: "UsuarioRespId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GRD_LOGS_PROPOSICAO_UsuarioRespId",
                schema: "GRD",
                table: "GRD_LOGS_PROPOSICAO",
                column: "UsuarioRespId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GRD_LOGS_ACAO_UsuarioRespId",
                schema: "GRD",
                table: "GRD_LOGS_ACAO",
                column: "UsuarioRespId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GRD_ANDAMENTOS_UserId",
                schema: "GRD",
                table: "GRD_ANDAMENTOS",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_GRD_ACOES_DiretoriaResId",
                schema: "GRD",
                table: "GRD_ACOES",
                column: "DiretoriaResId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Acoes_Group",
                schema: "GRD",
                table: "GRD_ACOES",
                column: "DiretoriaResId",
                principalSchema: "GRD",
                principalTable: "GRD_GROUPS",
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
                name: "FK_LogsAcao_User",
                schema: "GRD",
                table: "GRD_LOGS_ACAO",
                column: "UsuarioRespId",
                principalSchema: "GRD",
                principalTable: "GRD_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LogsProposicao_User",
                schema: "GRD",
                table: "GRD_LOGS_PROPOSICAO",
                column: "UsuarioRespId",
                principalSchema: "GRD",
                principalTable: "GRD_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LogsReuniao_User",
                schema: "GRD",
                table: "GRD_LOGS_REUNIAO",
                column: "UsuarioRespId",
                principalSchema: "GRD",
                principalTable: "GRD_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Participantes_Group",
                schema: "GRD",
                table: "GRD_PARTICIPANTES",
                column: "DiretoriaAreaId",
                principalSchema: "GRD",
                principalTable: "GRD_GROUPS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Participantes_User",
                schema: "GRD",
                table: "GRD_PARTICIPANTES",
                column: "UserId",
                principalSchema: "GRD",
                principalTable: "GRD_USERS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Proposicoes_Group",
                schema: "GRD",
                table: "GRD_PROPOSICOES",
                column: "AreaSolicitanteId",
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
                name: "FK_Votos_Participante",
                schema: "GRD",
                table: "GRD_VOTOS",
                column: "ParticipanteId",
                principalSchema: "GRD",
                principalTable: "GRD_PARTICIPANTES",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Acoes_Group",
                schema: "GRD",
                table: "GRD_ACOES");

            migrationBuilder.DropForeignKey(
                name: "FK_Andamentos_Users",
                schema: "GRD",
                table: "GRD_ANDAMENTOS");

            migrationBuilder.DropForeignKey(
                name: "FK_LogsAcao_User",
                schema: "GRD",
                table: "GRD_LOGS_ACAO");

            migrationBuilder.DropForeignKey(
                name: "FK_LogsProposicao_User",
                schema: "GRD",
                table: "GRD_LOGS_PROPOSICAO");

            migrationBuilder.DropForeignKey(
                name: "FK_LogsReuniao_User",
                schema: "GRD",
                table: "GRD_LOGS_REUNIAO");

            migrationBuilder.DropForeignKey(
                name: "FK_Participantes_Group",
                schema: "GRD",
                table: "GRD_PARTICIPANTES");

            migrationBuilder.DropForeignKey(
                name: "FK_Participantes_User",
                schema: "GRD",
                table: "GRD_PARTICIPANTES");

            migrationBuilder.DropForeignKey(
                name: "FK_Proposicoes_Group",
                schema: "GRD",
                table: "GRD_PROPOSICOES");

            migrationBuilder.DropForeignKey(
                name: "FK_Proposicoes_User",
                schema: "GRD",
                table: "GRD_PROPOSICOES");

            migrationBuilder.DropForeignKey(
                name: "FK_Votos_Participante",
                schema: "GRD",
                table: "GRD_VOTOS");

            migrationBuilder.DropIndex(
                name: "IX_GRD_VOTOS_ParticipanteId",
                schema: "GRD",
                table: "GRD_VOTOS");

            migrationBuilder.DropIndex(
                name: "IX_GRD_PROPOSICOES_AreaSolicitanteId",
                schema: "GRD",
                table: "GRD_PROPOSICOES");

            migrationBuilder.DropIndex(
                name: "IX_GRD_PROPOSICOES_CriadorId",
                schema: "GRD",
                table: "GRD_PROPOSICOES");

            migrationBuilder.DropIndex(
                name: "IX_GRD_PARTICIPANTES_DiretoriaAreaId",
                schema: "GRD",
                table: "GRD_PARTICIPANTES");

            migrationBuilder.DropIndex(
                name: "IX_GRD_PARTICIPANTES_UserId",
                schema: "GRD",
                table: "GRD_PARTICIPANTES");

            migrationBuilder.DropIndex(
                name: "IX_GRD_LOGS_REUNIAO_UsuarioRespId",
                schema: "GRD",
                table: "GRD_LOGS_REUNIAO");

            migrationBuilder.DropIndex(
                name: "IX_GRD_LOGS_PROPOSICAO_UsuarioRespId",
                schema: "GRD",
                table: "GRD_LOGS_PROPOSICAO");

            migrationBuilder.DropIndex(
                name: "IX_GRD_LOGS_ACAO_UsuarioRespId",
                schema: "GRD",
                table: "GRD_LOGS_ACAO");

            migrationBuilder.DropIndex(
                name: "IX_GRD_ANDAMENTOS_UserId",
                schema: "GRD",
                table: "GRD_ANDAMENTOS");

            migrationBuilder.DropIndex(
                name: "IX_GRD_ACOES_DiretoriaResId",
                schema: "GRD",
                table: "GRD_ACOES");

            migrationBuilder.DropColumn(
                name: "ParticipanteId",
                schema: "GRD",
                table: "GRD_VOTOS");

            migrationBuilder.DropColumn(
                name: "AreaSolicitanteId",
                schema: "GRD",
                table: "GRD_PROPOSICOES");

            migrationBuilder.DropColumn(
                name: "CriadorId",
                schema: "GRD",
                table: "GRD_PROPOSICOES");

            migrationBuilder.DropColumn(
                name: "DiretoriaAreaId",
                schema: "GRD",
                table: "GRD_PARTICIPANTES");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "GRD",
                table: "GRD_PARTICIPANTES");

            migrationBuilder.DropColumn(
                name: "UsuarioRespId",
                schema: "GRD",
                table: "GRD_LOGS_REUNIAO");

            migrationBuilder.DropColumn(
                name: "UsuarioRespId",
                schema: "GRD",
                table: "GRD_LOGS_PROPOSICAO");

            migrationBuilder.DropColumn(
                name: "UsuarioRespId",
                schema: "GRD",
                table: "GRD_LOGS_ACAO");

            migrationBuilder.DropColumn(
                name: "UserId",
                schema: "GRD",
                table: "GRD_ANDAMENTOS");

            migrationBuilder.DropColumn(
                name: "DiretoriaResId",
                schema: "GRD",
                table: "GRD_ACOES");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "GRD",
                table: "GRD_USERS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AddColumn<int>(
                name: "LogAcaoId",
                schema: "GRD",
                table: "GRD_USERS",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LogProposicaoId",
                schema: "GRD",
                table: "GRD_USERS",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LogReuniaoId",
                schema: "GRD",
                table: "GRD_USERS",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ParticipanteId",
                schema: "GRD",
                table: "GRD_USERS",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProposicaoId",
                schema: "GRD",
                table: "GRD_USERS",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "GRD",
                table: "GRD_PARTICIPANTES",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "GRD",
                table: "GRD_GROUPS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AddColumn<int>(
                name: "ParticipanteId",
                schema: "GRD",
                table: "GRD_GROUPS",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProposicaoId",
                schema: "GRD",
                table: "GRD_GROUPS",
                type: "NUMBER(10)",
                nullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Acoes_Group",
                schema: "GRD",
                table: "GRD_GROUPS",
                column: "Id",
                principalSchema: "GRD",
                principalTable: "GRD_ACOES",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Participantes_Group",
                schema: "GRD",
                table: "GRD_GROUPS",
                column: "ParticipanteId",
                principalSchema: "GRD",
                principalTable: "GRD_PARTICIPANTES",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Proposicoes_Group",
                schema: "GRD",
                table: "GRD_GROUPS",
                column: "ProposicaoId",
                principalSchema: "GRD",
                principalTable: "GRD_PROPOSICOES",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Votos_Participante",
                schema: "GRD",
                table: "GRD_PARTICIPANTES",
                column: "Id",
                principalSchema: "GRD",
                principalTable: "GRD_VOTOS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Andamentos_Users",
                schema: "GRD",
                table: "GRD_USERS",
                column: "Id",
                principalSchema: "GRD",
                principalTable: "GRD_ANDAMENTOS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LogsAcao_User",
                schema: "GRD",
                table: "GRD_USERS",
                column: "LogAcaoId",
                principalSchema: "GRD",
                principalTable: "GRD_LOGS_ACAO",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LogsProposicao_User",
                schema: "GRD",
                table: "GRD_USERS",
                column: "LogProposicaoId",
                principalSchema: "GRD",
                principalTable: "GRD_LOGS_PROPOSICAO",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LogsReuniao_User",
                schema: "GRD",
                table: "GRD_USERS",
                column: "LogReuniaoId",
                principalSchema: "GRD",
                principalTable: "GRD_LOGS_REUNIAO",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Participantes_User",
                schema: "GRD",
                table: "GRD_USERS",
                column: "ParticipanteId",
                principalSchema: "GRD",
                principalTable: "GRD_PARTICIPANTES",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Proposicoes_User",
                schema: "GRD",
                table: "GRD_USERS",
                column: "ProposicaoId",
                principalSchema: "GRD",
                principalTable: "GRD_PROPOSICOES",
                principalColumn: "Id");
        }
    }
}
