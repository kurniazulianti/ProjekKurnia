using Microsoft.EntityFrameworkCore;
using ProjekKurnia.Data;
using ProjekKurnia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia.Repositories.PasienRepository
{
    public class PasienRepository : IPasienRepository
    {
        private readonly AppDbContext _context;
        public PasienRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Pasien> AmbilPasienIdAsync(string id)
        {
            return await _context.Tb_Pasien.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Pasien>> AmbilSemuaPasienAsync()
        {
            return await _context.Tb_Pasien.ToListAsync();
        }

        public async Task<bool> BuatPasienBaruAsync(Pasien baru)
        {
            _context.Add(baru);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Pasien> CariPasienAsync(string idnya)
        {
            return await _context.Tb_Pasien.FirstOrDefaultAsync(x => x.Id == idnya);
        }

        public async Task<bool> HapusPasienAsync(Pasien datanya)
        {
            _context.Remove(datanya);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UbahPasienAsync(Pasien datanya)
        {
            _context.Update(datanya);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
