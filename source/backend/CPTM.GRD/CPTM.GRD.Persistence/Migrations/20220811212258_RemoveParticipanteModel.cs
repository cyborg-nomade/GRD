using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CPTM.GRD.Persistence.Migrations
{
    public partial class RemoveParticipanteModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartReuniao_PartId",
                schema: "GRD",
                table: "GRD_PART_REUNIAO");

            migrationBuilder.DropForeignKey(
                name: "FK_PartPrevReuniao_PartId",
                schema: "GRD",
                table: "GRD_PARTPREV_REUNIAO");

            migrationBuilder.DropForeignKey(
                name: "FK_Votos_Part",
                schema: "GRD",
                table: "GRD_VOTOS");

            migrationBuilder.DropTable(
                name: "GRD_PARTICIPANTES",
                schema: "GRD");

            migrationBuilder.DropSequence(
                name: "SEQ_PARTICIPANTES",
                schema: "GRD");

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
                name: "FK_PartPrevReuniao_PartId",
                schema: "GRD",
                table: "GRD_PARTPREV_REUNIAO",
                column: "PartId",
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
                principalTable: "GRD_USERS",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PartReuniao_PartId",
                schema: "GRD",
                table: "GRD_PART_REUNIAO");

            migrationBuilder.DropForeignKey(
                name: "FK_PartPrevReuniao_PartId",
                schema: "GRD",
                table: "GRD_PARTPREV_REUNIAO");

            migrationBuilder.DropForeignKey(
                name: "FK_Votos_Part",
                schema: "GRD",
                table: "GRD_VOTOS");

            migrationBuilder.CreateSequence(
                name: "SEQ_PARTICIPANTES",
                schema: "GRD",
                incrementBy: 10);

            migrationBuilder.CreateTable(
                name: "GRD_PARTICIPANTES",
                schema: "GRD",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    AreaId = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    UserId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    Email = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    Nome = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GRD_PARTICIPANTES", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Part_Group",
                        column: x => x.AreaId,
                        principalSchema: "GRD",
                        principalTable: "GRD_GROUPS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Part_User",
                        column: x => x.UserId,
                        principalSchema: "GRD",
                        principalTable: "GRD_USERS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

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
                unique: true,
                filter: "\"UserId\" IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_PartReuniao_PartId",
                schema: "GRD",
                table: "GRD_PART_REUNIAO",
                column: "PartId",
                principalSchema: "GRD",
                principalTable: "GRD_PARTICIPANTES",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_PartPrevReuniao_PartId",
                schema: "GRD",
                table: "GRD_PARTPREV_REUNIAO",
                column: "PartId",
                principalSchema: "GRD",
                principalTable: "GRD_PARTICIPANTES",
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
    }
}
