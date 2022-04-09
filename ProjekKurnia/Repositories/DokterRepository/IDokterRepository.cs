using ProjekKurnia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia.Repositories.DokterRepository
{
    public interface IDokterRepository
    {
        Task<List<Dokter>> AmbilSemuaDokterAsync();
        Task<bool> BuatDokterBaruAsync(Dokter baru);
        Task<bool> UbahDokterAsync(Dokter datanya);
        Task<Dokter> AmbilDokterIdAsync(string id);
        Task<bool> HapusDokterAsync(Dokter datanya);
        Task<Dokter> CariDokterAsync(string idnya);
    }
}