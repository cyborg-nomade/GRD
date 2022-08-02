using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTM.GRD.Persistence.Migrations
{
    public partial class RemoveGroupRelator : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Andamentos_Users",
                schema: "GRD",
                table: "GRD_USERS");

            migrationBuilder.DropForeignKey(
                name: "FK_Groups_User",
                schema: "GRD",
                table: "GRD_USERS");

            migrationBuilder.DropIndex(
                name: "IX_GRD_USERS_AndamentoId",
                schema: "GRD",
                table: "GRD_USERS");

            migrationBuilder.DropColumn(
                name: "AndamentoId",
                schema: "GRD",
                table: "GRD_USERS");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                schema: "GRD",
                table: "GRD_GROUPS",
                type: "NUMBER(10)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)");

            migrationBuilder.AddForeignKey(
                name: "FK_Andamentos_Users",
                schema: "GRD",
                table: "GRD_USERS",
                column: "Id",
                principalSchema: "GRD",
                principalTable: "GRD_ANDAMENTOS",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Andamentos_Users",
                schema: "GRD",
                table: "GRD_USERS");

            migrationBuilder.AddColumn<int>(
                name: "AndamentoId",
                schema: "GRD",
                table: "GRD_USERS",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                schema: "GRD",
                table: "GRD_GROUPS",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "NUMBER(10)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_GRD_USERS_AndamentoId",
                schema: "GRD",
                table: "GRD_USERS",
                column: "AndamentoId",
                unique: true,
                filter: "\"AndamentoId\" IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Andamentos_Users",
                schema: "GRD",
                table: "GRD_USERS",
                column: "AndamentoId",
                principalSchema: "GRD",
                principalTable: "GRD_ANDAMENTOS",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_User",
                schema: "GRD",
                table: "GRD_USERS",
                column: "Id",
                principalSchema: "GRD",
                principalTable: "GRD_GROUPS",
                principalColumn: "Id");
        }
    }
}
