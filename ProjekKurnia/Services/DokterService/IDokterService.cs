using Microsoft.AspNetCore.Http;
using ProjekKurnia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia.Services.DokterService
{
    public interface IDokterService
    {
        List<Dokter> AmbilSemuaDokter();
        bool BuatDokterBaru(Dokter baru, IFormFile Image);
        bool UbahDokter(Dokter dariView, IFormFile Image);
        Dokter AmbilDokterId(string id);
        bool HapusDokter(string idnya);
    }
}
