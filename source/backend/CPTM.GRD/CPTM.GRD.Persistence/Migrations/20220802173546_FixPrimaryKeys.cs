using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTM.GRD.Persistence.Migrations
{
    public partial class FixPrimaryKeys : Migration
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

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "GRD",
                table: "GRD_VOTOS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "GRD",
                table: "GRD_USERS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "GRD",
                table: "GRD_REUNIOES",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "GRD",
                table: "GRD_RESOLUCOES",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "GRD",
                table: "GRD_PROPOSICOES",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

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
                table: "GRD_LOGS_REUNIAO",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "GRD",
                table: "GRD_LOGS_PROPOSICAO",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "GRD",
                table: "GRD_LOGS_ACAO",
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

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "GRD",
                table: "GRD_ANDAMENTOS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "GRD",
                table: "GRD_ACOES",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .OldAnnotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "GRD",
                table: "GRD_VOTOS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "GRD",
                table: "GRD_USERS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "GRD",
                table: "GRD_REUNIOES",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "GRD",
                table: "GRD_RESOLUCOES",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "GRD",
                table: "GRD_PROPOSICOES",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "GRD",
                table: "GRD_PARTICIPANTES",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "GRD",
                table: "GRD_LOGS_REUNIAO",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "GRD",
                table: "GRD_LOGS_PROPOSICAO",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "GRD",
                table: "GRD_LOGS_ACAO",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "GRD",
                table: "GRD_GROUPS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "GRD",
                table: "GRD_ANDAMENTOS",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "GRD",
                table: "GRD_ACOES",
                type: "NUMBER(10)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)")
                .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1");
        }
    }
}
