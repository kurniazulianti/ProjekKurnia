using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjekKurnia.Migrations
{
    public partial class Tb_Pemeriksaan : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_Pemeriksaan",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(767)", nullable: false),
                    TanggalB = table.Column<DateTime>(type: "datetime", nullable: false),
                    Keluhan = table.Column<string>(type: "text", nullable: true),
                    Diagnosis = table.Column<string>(type: "text", nullable: true),
                    Tindakan = table.Column<string>(type: "text", nullable: true),
                    PasienId = table.Column<string>(type: "varchar(767)", nullable: true),
                    DokterId = table.Column<string>(type: "varchar(767)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Pemeriksaan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_Pemeriksaan_Tb_Dokter_DokterId",
                        column: x => x.DokterId,
                        principalTable: "Tb_Dokter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tb_Pemeriksaan_Tb_Pasien_PasienId",
                        column: x => x.PasienId,
                        principalTable: "Tb_Pasien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Pemeriksaan_DokterId",
                table: "Tb_Pemeriksaan",
                column: "DokterId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_Pemeriksaan_PasienId",
                table: "Tb_Pemeriksaan",
                column: "PasienId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_Pemeriksaan");
        }
    }
}
