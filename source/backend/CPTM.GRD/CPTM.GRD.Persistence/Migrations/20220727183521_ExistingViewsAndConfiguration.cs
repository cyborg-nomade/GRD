using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTM.GRD.Persistence.Migrations
{
    public partial class ExistingViewsAndConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GRD_CONFIGURACAO",
                schema: "GRD");

            migrationBuilder.DropTable(
                name: "GRD_USUARIO_PREFERENCIA",
                schema: "GRD");
        }
    }
}
