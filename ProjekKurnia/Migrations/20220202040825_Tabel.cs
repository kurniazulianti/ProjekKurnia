using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjekKurnia.Migrations
{
    public partial class Tabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_Dokter",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(767)", nullable: false),
                    NamaD = table.Column<string>(type: "text", nullable: false),
                    Hp = table.Column<string>(type: "text", nullable: false),
                    alamat = table.Column<string>(type: "text", nullable: false),
                    Specialis = table.Column<string>(type: "text", nullable: false),
                    Ijin = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Dokter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Pasien",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(767)", nullable: false),
                    NamaP = table.Column<string>(type: "text", nullable: false),
                    Jk = table.Column<string>(type: "text", nullable: false),
                    GolD = table.Column<string>(type: "text", nullable: false),
                    TempatL = table.Column<string>(type: "text", nullable: false),
                    TanggalL = table.Column<string>(type: "text", nullable: false),
                    NamaIbu = table.Column<string>(type: "text", nullable: false),
                    StatusM = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Pasien", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Roles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(767)", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Pemeriksaan",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(767)", nullable: false),
                    TanggalB = table.Column<DateTime>(type: "datetime", nullable: false),
                    Keluhan = table.Column<string>(type: "text", nullable: false),
                    Diagnosis = table.Column<string>(type: "text", nullable: false),
                    Tindakan = table.Column<string>(type: "text", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "Tb_User",
                columns: table => new
                {
                    Username = table.Column<string>(type: "varchar(767)", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    RolesId = table.Column<string>(type: "varchar(767)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_User", x => x.Username);
                    table.ForeignKey(
                        name: "FK_Tb_User_Tb_Roles_RolesId",
                        column: x => x.RolesId,
                        principalTable: "Tb_Roles",
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

            migrationBuilder.CreateIndex(
                name: "IX_Tb_User_RolesId",
                table: "Tb_User",
                column: "RolesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_Pemeriksaan");

            migrationBuilder.DropTable(
                name: "Tb_User");

            migrationBuilder.DropTable(
                name: "Tb_Dokter");

            migrationBuilder.DropTable(
                name: "Tb_Pasien");

            migrationBuilder.DropTable(
                name: "Tb_Roles");
        }
    }
}
