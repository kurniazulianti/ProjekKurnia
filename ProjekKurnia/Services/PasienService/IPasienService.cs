using Microsoft.AspNetCore.Http;
using ProjekKurnia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia.Services.PasienService
{
    public interface IPasienService
    {
        List<Pasien> AmbilSemuaPasien();
        bool BuatPasienBaru(Pasien baru, IFormFile Image);
        bool UbahPasien(Pasien dariView, IFormFile Image);
        Pasien AmbilPasienId(string id);
        bool HapusPasien(string idnya);
    }
}
