using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AcademiX.Migrations
{
    public partial class supervisor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ThesisSupervisors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Cabinet = table.Column<int>(type: "int", nullable: false),
                    WorkingTime = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsReviewer = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThesisSupervisors", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ThesisSupervisorsSpecialties",
                columns: table => new
                {
                    ThesisSupervisorId = table.Column<int>(type: "int", nullable: false),
                    SpecialtyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThesisSupervisorsSpecialties", x => new { x.ThesisSupervisorId, x.SpecialtyId });
                    table.ForeignKey(
                        name: "FK_ThesisSupervisorsSpecialties_Specialties_SpecialtyId",
                        column: x => x.SpecialtyId,
                        principalTable: "Specialties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ThesisSupervisorsSpecialties_ThesisSupervisors_ThesisSupervi~",
                        column: x => x.ThesisSupervisorId,
                        principalTable: "ThesisSupervisors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ThesisSupervisorsSpecialties_SpecialtyId",
                table: "ThesisSupervisorsSpecialties",
                column: "SpecialtyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThesisSupervisorsSpecialties");

            migrationBuilder.DropTable(
                name: "ThesisSupervisors");
        }
    }
}
