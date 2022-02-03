﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjekKurnia.Data;

namespace ProjekKurnia.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.13");

            modelBuilder.Entity("ProjekKurnia.Models.Dokter", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Alamat")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Hp")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NamaD")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Specialis")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("TanggalD")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Tb_Dokter");
                });

            modelBuilder.Entity("ProjekKurnia.Models.Pasien", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("GolD")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Jk")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NamaIbu")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("NamaP")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("StatusM")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("TanggalL")
                        .HasColumnType("datetime");

                    b.Property<string>("TempatL")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Tb_Pasien");
                });

            modelBuilder.Entity("ProjekKurnia.Models.Pemeriksaan", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Diagnosis")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("DokterId")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Keluhan")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasienId")
                        .HasColumnType("varchar(767)");

                    b.Property<DateTime>("TanggalB")
                        .HasColumnType("datetime");

                    b.Property<string>("Tindakan")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("DokterId");

                    b.HasIndex("PasienId");

                    b.ToTable("Tb_Pemeriksaan");
                });

            modelBuilder.Entity("ProjekKurnia.Models.Roles", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Tb_Roles");
                });

            modelBuilder.Entity("ProjekKurnia.Models.User", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("varchar(767)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("RolesId")
                        .HasColumnType("varchar(767)");

                    b.HasKey("Username");

                    b.HasIndex("RolesId");

                    b.ToTable("Tb_User");
                });

            modelBuilder.Entity("ProjekKurnia.Models.Pemeriksaan", b =>
                {
                    b.HasOne("ProjekKurnia.Models.Dokter", "Dokter")
                        .WithMany()
                        .HasForeignKey("DokterId");

                    b.HasOne("ProjekKurnia.Models.Pasien", "Pasien")
                        .WithMany()
                        .HasForeignKey("PasienId");

                    b.Navigation("Dokter");

                    b.Navigation("Pasien");
                });

            modelBuilder.Entity("ProjekKurnia.Models.User", b =>
                {
                    b.HasOne("ProjekKurnia.Models.Roles", "Roles")
                        .WithMany()
                        .HasForeignKey("RolesId");

                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}
