using ProjekKurnia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia.Repositories.InapRepository
{
    public interface IInapRepository
    {
        Task<List<Inap>> AmbilSemuaInapAsync();
        Task<bool> BuatInapBaruAsync(Inap baru);
        Task<bool> UbahInapAsync(Inap datanya);
        Task<Inap> AmbilInapIdAsync(string id);
        Task<bool> HapusInapAsync(Inap datanya);
        Task<Inap> CariInapAsync(string idnya);
    }
}
