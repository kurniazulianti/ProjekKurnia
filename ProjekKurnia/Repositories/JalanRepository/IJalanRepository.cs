using ProjekKurnia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia.Repositories.JalanRepository
{
    public interface IJalanRepository
    {
        Task<List<Jalan>> AmbilSemuaJalanAsync();
        Task<bool> BuatJalanBaruAsync(Jalan baru);
        Task<bool> UbahJalanAsync(Jalan datanya);
        Task<Jalan> AmbilJalanIdAsync(string id);
        Task<bool> HapusJalanAsync (Jalan datanya);
        Task<Jalan> CariJalanAsync(string idnya);
    }
}
