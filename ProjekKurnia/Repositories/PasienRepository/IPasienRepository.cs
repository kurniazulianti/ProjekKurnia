using ProjekKurnia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia.Repositories.PasienRepository
{
    public interface IPasienRepository
    {
        Task<List<Pasien>> AmbilSemuaPasienAsync();
        Task<bool> BuatPasienBaruAsync(Pasien baru);
        Task<bool> UbahPasienAsync(Pasien datanya);
        Task<Pasien> AmbilPasienIdAsync(string id);
        Task<bool> HapusPasienAsync(Pasien datanya);
        Task<Pasien> CariPasienAsync(string idnya);
    }
}
