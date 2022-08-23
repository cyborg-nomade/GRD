using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTM.GRD.Persistence.Migrations
{
    public partial class MakeParticipanteUserNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GRD_PARTICIPANTES_UserId",
                schema: "GRD",
                table: "GRD_PARTICIPANTES");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                schema: "GRD",
                table: "GRD_PARTICIPANTES",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.CreateIndex(
                name: "IX_GRD_PARTICIPANTES_UserId",
                schema: "GRD",
                table: "GRD_PARTICIPANTES",
                column: "UserId",
                unique: true,
                filter: "\"UserId\" IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_GRD_PARTICIPANTES_UserId",
                schema: "GRD",
                table: "GRD_PARTICIPANTES");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                schema: "GRD",
                table: "GRD_PARTICIPANTES",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GRD_PARTICIPANTES_UserId",
                schema: "GRD",
                table: "GRD_PARTICIPANTES",
                column: "UserId",
                unique: true);
        }
    }
}
