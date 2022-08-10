using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTM.GRD.Persistence.Migrations
{
    public partial class FixColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProtoloExpediente",
                schema: "GRD",
                table: "GRD_PROPOSICOES",
                newName: "ProtocoloExpediente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProtocoloExpediente",
                schema: "GRD",
                table: "GRD_PROPOSICOES",
                newName: "ProtoloExpediente");
        }
    }
}
