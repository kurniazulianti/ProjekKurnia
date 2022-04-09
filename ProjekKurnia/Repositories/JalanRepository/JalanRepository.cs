using Microsoft.EntityFrameworkCore;
using ProjekKurnia.Data;
using ProjekKurnia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia.Repositories.JalanRepository
{
    public class JalanRepository : IJalanRepository
    {
        private readonly AppDbContext _context;
        public JalanRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Jalan> AmbilJalanIdAsync(string id)
        {
            return await _context.Tb_RawatJalan.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Jalan>> AmbilSemuaJalanAsync()
        {
            return await _context.Tb_RawatJalan.ToListAsync();
        }

        public async Task<bool> BuatJalanBaruAsync(Jalan baru)
        {
            _context.Add(baru);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Jalan> CariJalanAsync(string idnya)
        {
            return await _context.Tb_RawatJalan.FirstOrDefaultAsync(x => x.Id == idnya);
        }

        public async Task<bool> HapusJalanAsync(Jalan datanya)
        {
            _context.Remove(datanya);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UbahJalanAsync(Jalan datanya)
        {
            _context.Update(datanya);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
