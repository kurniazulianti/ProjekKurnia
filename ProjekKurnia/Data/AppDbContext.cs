using Microsoft.EntityFrameworkCore;
using ProjekKurnia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
        {

        }

        public virtual DbSet<Dokter> Tb_Dokter { get; set; }
        public virtual DbSet<Roles> Tb_Roles { get; set; }
        public virtual DbSet<User> Tb_User { get; set; }
        public virtual DbSet<Pasien> Tb_Pasien { get; set; }
        public virtual DbSet<Departemen> Tb_Departemen { get; set; }
        public virtual DbSet<Jalan> Tb_RawatJalan { get; set; }
        public virtual DbSet<Inap> Tb_RawatInap { get; set; }

        
    }
}
