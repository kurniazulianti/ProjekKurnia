using Microsoft.AspNetCore.Http;
using ProjekKurnia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia.Services.JalanService
{
    public interface IJalanService
    {
        List<Jalan> AmbilSemuaJalan();
        bool BuatJalanBaru(Jalan baru);
        bool UbahJalan(Jalan dariView);
        Jalan AmbilJalanId(string id);
        bool HapusJalan(string idnya);
    }
}
