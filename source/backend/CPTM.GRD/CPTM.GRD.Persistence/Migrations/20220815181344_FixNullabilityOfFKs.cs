using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTM.GRD.Persistence.Migrations
{
    public partial class FixNullabilityOfFKs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcaoReuniao_AcaoId",
                schema: "GRD",
                table: "GRD_ACAO_REUNIAO");

            migrationBuilder.DropForeignKey(
                name: "FK_AcaoReuniao_ReuniaoId",
                schema: "GRD",
                table: "GRD_ACAO_REUNIAO");

            migrationBuilder.DropForeignKey(
                name: "FK_PartReuniao_PartId",
                schema: "GRD",
                table: "GRD_PART_REUNIAO");

            migrationBuilder.DropForeignKey(
                name: "FK_PartReuniao_ReuniaoId",
                schema: "GRD",
                table: "GRD_PART_REUNIAO");

            migrationBuilder.DropForeignKey(
                name: "FK_PartPrevReuniao_PartId",
                schema: "GRD",
                table: "GRD_PARTPREV_REUNIAO");

            migrationBuilder.DropForeignKey(
                name: "FK_PartPrevReuniao_ReuId",
                schema: "GRD",
                table: "GRD_PARTPREV_REUNIAO");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroup_GroupId",
                schema: "GRD",
                table: "GRD_USER_GROUP");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroup_UserId",
                schema: "GRD",
                table: "GRD_USER_GROUP");

            migrationBuilder.AlterColumn<int>(
                name: "ParticipanteId",
                schema: "GRD",
                table: "GRD_VOTOS",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<int>(
                name: "CriadorId",
                schema: "GRD",
                table: "GRD_PROPOSICOES",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<int>(
                name: "AreaId",
                schema: "GRD",
                table: "GRD_PROPOSICOES",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<int>(
                name: "RespId",
                schema: "GRD",
                table: "GRD_LOGS_REUNIAO",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<int>(
                name: "RespId",
                schema: "GRD",
                table: "GRD_LOGS_PROPOSICAO",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<int>(
                name: "RespId",
                schema: "GRD",
                table: "GRD_LOGS_ACAO",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                schema: "GRD",
                table: "GRD_ANDAMENTOS",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<int>(
                name: "ResponsavelId",
                schema: "GRD",
                table: "GRD_ACOES",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AlterColumn<int>(
                name: "DiretoriaResId",
                schema: "GRD",
                table: "GRD_ACOES",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AddForeignKey(
                name: "FK_AcaoReuniao_AcaoId",
                schema: "GRD",
                table: "GRD_ACAO_REUNIAO",
                column: "AcaoId",
                principalSchema: "GRD",
                principalTable: "GRD_ACOES",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AcaoReuniao_ReuniaoId",
                schema: "GRD",
                table: "GRD_ACAO_REUNIAO",
                column: "ReuniaoId",
                principalSchema: "GRD",
                principalTable: "GRD_REUNIOES",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartReuniao_PartId",
                schema: "GRD",
                table: "GRD_PART_REUNIAO",
                column: "PartId",
                principalSchema: "GRD",
                principalTable: "GRD_USERS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartReuniao_ReuniaoId",
                schema: "GRD",
                table: "GRD_PART_REUNIAO",
                column: "ReuniaoId",
                principalSchema: "GRD",
                principalTable: "GRD_REUNIOES",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartPrevReuniao_PartId",
                schema: "GRD",
                table: "GRD_PARTPREV_REUNIAO",
                column: "PartId",
                principalSchema: "GRD",
                principalTable: "GRD_USERS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PartPrevReuniao_ReuId",
                schema: "GRD",
                table: "GRD_PARTPREV_REUNIAO",
                column: "ReuId",
                principalSchema: "GRD",
                principalTable: "GRD_REUNIOES",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroup_GroupId",
                schema: "GRD",
                table: "GRD_USER_GROUP",
                column: "GroupId",
                principalSchema: "GRD",
                principalTable: "GRD_GROUPS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroup_UserId",
                schema: "GRD",
                table: "GRD_USER_GROUP",
                column: "UserId",
                principalSchema: "GRD",
                principalTable: "GRD_USERS",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcaoReuniao_AcaoId",
                schema: "GRD",
                table: "GRD_ACAO_REUNIAO");

            migrationBuilder.DropForeignKey(
                name: "FK_AcaoReuniao_ReuniaoId",
                schema: "GRD",
                table: "GRD_ACAO_REUNIAO");

            migrationBuilder.DropForeignKey(
                name: "FK_PartReuniao_PartId",
                schema: "GRD",
                table: "GRD_PART_REUNIAO");

            migrationBuilder.DropForeignKey(
                name: "FK_PartReuniao_ReuniaoId",
                schema: "GRD",
                table: "GRD_PART_REUNIAO");

            migrationBuilder.DropForeignKey(
                name: "FK_PartPrevReuniao_PartId",
                schema: "GRD",
                table: "GRD_PARTPREV_REUNIAO");

            migrationBuilder.DropForeignKey(
                name: "FK_PartPrevReuniao_ReuId",
                schema: "GRD",
                table: "GRD_PARTPREV_REUNIAO");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroup_GroupId",
                schema: "GRD",
                table: "GRD_USER_GROUP");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroup_UserId",
                schema: "GRD",
                table: "GRD_USER_GROUP");

            migrationBuilder.AlterColumn<int>(
                name: "ParticipanteId",
                schema: "GRD",
                table: "GRD_VOTOS",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CriadorId",
                schema: "GRD",
                table: "GRD_PROPOSICOES",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AreaId",
                schema: "GRD",
                table: "GRD_PROPOSICOES",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RespId",
                schema: "GRD",
                table: "GRD_LOGS_REUNIAO",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RespId",
                schema: "GRD",
                table: "GRD_LOGS_PROPOSICAO",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RespId",
                schema: "GRD",
                table: "GRD_LOGS_ACAO",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                schema: "GRD",
                table: "GRD_ANDAMENTOS",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ResponsavelId",
                schema: "GRD",
                table: "GRD_ACOES",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DiretoriaResId",
                schema: "GRD",
                table: "GRD_ACOES",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AcaoReuniao_AcaoId",
                schema: "GRD",
                table: "GRD_ACAO_REUNIAO",
                column: "AcaoId",
                principalSchema: "GRD",
                principalTable: "GRD_ACOES",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

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
                name: "FK_PartReuniao_PartId",
                schema: "GRD",
                table: "GRD_PART_REUNIAO",
                column: "PartId",
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
                name: "FK_PartPrevReuniao_PartId",
                schema: "GRD",
                table: "GRD_PARTPREV_REUNIAO",
                column: "PartId",
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
                name: "FK_UserGroup_GroupId",
                schema: "GRD",
                table: "GRD_USER_GROUP",
                column: "GroupId",
                principalSchema: "GRD",
                principalTable: "GRD_GROUPS",
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
        }
    }
}
