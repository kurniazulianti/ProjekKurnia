using Microsoft.EntityFrameworkCore;
using ProjekKurnia.Data;
using ProjekKurnia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia.Repositories.DokterRepository
{
    public class DokterRepository : IDokterRepository
    {
        private readonly AppDbContext _context;
        public DokterRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Dokter> AmbilDokterIdAsync(string id)
        {
            return await _context.Tb_Dokter.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Dokter>> AmbilSemuaDokterAsync()
        {
            return await _context.Tb_Dokter.ToListAsync();
        }

        public async Task<bool> BuatDokterBaruAsync(Dokter baru)
        {
            _context.Add(baru);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Dokter> CariDokterAsync(string idnya)
        {
            return await _context.Tb_Dokter.FirstOrDefaultAsync(x => x.Id == idnya);
        }

        public async Task<bool> HapusDokterAsync(Dokter datanya)
        {
            _context.Remove(datanya);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UbahDokterAsync(Dokter datanya)
        {
            _context.Update(datanya);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
