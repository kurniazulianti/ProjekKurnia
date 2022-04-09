using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjekKurnia.Migrations
{
    public partial class TabelAnti : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tb_Departemen",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(767)", nullable: false),
                    NamaDep = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_Departemen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tb_Dokter",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(767)", nullable: false),
                    NamaD = table.Column<string>(type: "text", nullable: true),
                    Hp = table.Column<string>(type: "text", nullable: true),
                    Alamat = table.Column<string>(type: "text", nullable: true),
                    TempatD = table.Column<string>(type: "text", nullable: true),
                    TanggalD = table.Column<DateTime>(type: "datetime", nullable: false),
                    Image = table.Column<string>(type: "text", nullable: true),
                    Departemen = table.Column<string>(type: "text", nullable: true)
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
                    NamaP = table.Column<string>(type: "text", nullable: true),
                    TempatL = table.Column<string>(type: "text", nullable: true),
                    TanggalL = table.Column<DateTime>(type: "datetime", nullable: false),
                    Alamat = table.Column<string>(type: "text", nullable: true),
                    NoHp = table.Column<string>(type: "text", nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true)
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
                name: "Tb_RawatInap",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(767)", nullable: false),
                    Ruangan = table.Column<string>(type: "text", nullable: true),
                    BiayaInap = table.Column<string>(type: "text", nullable: true),
                    PasienId = table.Column<string>(type: "varchar(767)", nullable: true),
                    DokterId = table.Column<string>(type: "varchar(767)", nullable: true),
                    DepartemenId = table.Column<string>(type: "varchar(767)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_RawatInap", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_RawatInap_Tb_Departemen_DepartemenId",
                        column: x => x.DepartemenId,
                        principalTable: "Tb_Departemen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tb_RawatInap_Tb_Dokter_DokterId",
                        column: x => x.DokterId,
                        principalTable: "Tb_Dokter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tb_RawatInap_Tb_Pasien_PasienId",
                        column: x => x.PasienId,
                        principalTable: "Tb_Pasien",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tb_RawatJalan",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(767)", nullable: false),
                    Biaya = table.Column<string>(type: "text", nullable: true),
                    PasienId = table.Column<string>(type: "varchar(767)", nullable: true),
                    DokterId = table.Column<string>(type: "varchar(767)", nullable: true),
                    DepartemenId = table.Column<string>(type: "varchar(767)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tb_RawatJalan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tb_RawatJalan_Tb_Departemen_DepartemenId",
                        column: x => x.DepartemenId,
                        principalTable: "Tb_Departemen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tb_RawatJalan_Tb_Dokter_DokterId",
                        column: x => x.DokterId,
                        principalTable: "Tb_Dokter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tb_RawatJalan_Tb_Pasien_PasienId",
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
                name: "IX_Tb_RawatInap_DepartemenId",
                table: "Tb_RawatInap",
                column: "DepartemenId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_RawatInap_DokterId",
                table: "Tb_RawatInap",
                column: "DokterId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_RawatInap_PasienId",
                table: "Tb_RawatInap",
                column: "PasienId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_RawatJalan_DepartemenId",
                table: "Tb_RawatJalan",
                column: "DepartemenId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_RawatJalan_DokterId",
                table: "Tb_RawatJalan",
                column: "DokterId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_RawatJalan_PasienId",
                table: "Tb_RawatJalan",
                column: "PasienId");

            migrationBuilder.CreateIndex(
                name: "IX_Tb_User_RolesId",
                table: "Tb_User",
                column: "RolesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tb_RawatInap");

            migrationBuilder.DropTable(
                name: "Tb_RawatJalan");

            migrationBuilder.DropTable(
                name: "Tb_User");

            migrationBuilder.DropTable(
                name: "Tb_Departemen");

            migrationBuilder.DropTable(
                name: "Tb_Dokter");

            migrationBuilder.DropTable(
                name: "Tb_Pasien");

            migrationBuilder.DropTable(
                name: "Tb_Roles");
        }
    }
}
