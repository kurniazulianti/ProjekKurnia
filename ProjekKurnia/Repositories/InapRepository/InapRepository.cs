using Microsoft.EntityFrameworkCore;
using ProjekKurnia.Data;
using ProjekKurnia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia.Repositories.InapRepository
{
    public class InapRepository : IInapRepository
    {
        private readonly AppDbContext _context;
        public InapRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Inap> AmbilInapIdAsync(string id)
        {
            return await _context.Tb_RawatInap.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Inap>> AmbilSemuaInapAsync()
        {
            return await _context.Tb_RawatInap.ToListAsync();
        }

        public async Task<bool> BuatInapBaruAsync(Inap baru)
        {
            _context.Add(baru);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Inap> CariInapAsync(string idnya)
        {
            return await _context.Tb_RawatInap.FirstOrDefaultAsync(x => x.Id == idnya);
        }

        public async Task<bool> HapusInapAsync(Inap datanya)
        {
            _context.Remove(datanya);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> UbahInapAsync(Inap datanya)
        {
            _context.Update(datanya);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
