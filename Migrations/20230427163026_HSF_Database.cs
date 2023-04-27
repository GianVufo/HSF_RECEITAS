using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hsf_Receitas.Migrations
{
    public partial class HSF_Database : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Receitas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PacientName = table.Column<string>(maxLength: 80, nullable: false),
                    DoctorName = table.Column<string>(maxLength: 80, nullable: false),
                    DateOfMedicalAppoiment = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receitas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ATM",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PacientName = table.Column<string>(maxLength: 80, nullable: false),
                    MedicUnity = table.Column<string>(maxLength: 40, nullable: false),
                    CID = table.Column<string>(maxLength: 20, nullable: false),
                    RestDays = table.Column<DateTime>(nullable: false),
                    ReceituarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ATM_Receitas_ReceituarioId",
                        column: x => x.ReceituarioId,
                        principalTable: "Receitas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Medicamentos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    MedicationName = table.Column<string>(maxLength: 80, nullable: false),
                    MedicationDosage = table.Column<string>(maxLength: 20, nullable: false),
                    MedicationMethodUse = table.Column<string>(maxLength: 20, nullable: false),
                    UseTime = table.Column<int>(nullable: false),
                    DoseTime = table.Column<int>(nullable: false),
                    ReceituarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicamentos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Medicamentos_Receitas_ReceituarioId",
                        column: x => x.ReceituarioId,
                        principalTable: "Receitas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ATM_ReceituarioId",
                table: "ATM",
                column: "ReceituarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Medicamentos_ReceituarioId",
                table: "Medicamentos",
                column: "ReceituarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ATM");

            migrationBuilder.DropTable(
                name: "Medicamentos");

            migrationBuilder.DropTable(
                name: "Receitas");
        }
    }
}
