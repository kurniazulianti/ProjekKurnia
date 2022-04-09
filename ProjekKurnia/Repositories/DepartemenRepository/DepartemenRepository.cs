using Microsoft.EntityFrameworkCore;
using ProjekKurnia.Data;
using ProjekKurnia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia.Repositories.DepartemenRepository
{
    public class DepartemenRepository : IDepartemenRepository
    {
        private readonly AppDbContext _context;
        public DepartemenRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Departemen> AmbilDepartemenIdAsync(string id)
        {
            return await _context.Tb_Departemen.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Departemen>> AmbilSemuaDepartemenAsync()
        {
            return await _context.Tb_Departemen.ToListAsync();
        }

        public async Task<bool> BuatDepartemenBaruAsync(Departemen baru)
        {
            _context.Add(baru);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Departemen> CariDepartemenAsync(string idnya)
        {
            return await _context.Tb_Departemen.FirstOrDefaultAsync(x => x.Id == idnya);
        }

        public async Task<bool> HapusDepartemenAsync(Departemen datanya)
        {
            _context.Remove(datanya);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
