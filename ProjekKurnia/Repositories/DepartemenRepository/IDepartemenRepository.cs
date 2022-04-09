using ProjekKurnia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia.Repositories.DepartemenRepository
{
    public interface IDepartemenRepository
    {
        Task<List<Departemen>> AmbilSemuaDepartemenAsync();
        Task<bool> BuatDepartemenBaruAsync(Departemen baru);
        Task<Departemen> AmbilDepartemenIdAsync(string id);
        Task<bool> HapusDepartemenAsync(Departemen datanya);
        Task<Departemen> CariDepartemenAsync(string idnya);
    }
}
