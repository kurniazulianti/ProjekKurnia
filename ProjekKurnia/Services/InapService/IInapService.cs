using ProjekKurnia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia.Services.InapService
{
    public interface IInapService
    {
        List<Inap> AmbilSemuaInap();
        bool BuatInapBaru(Inap baru);
        bool UbahInap(Inap dariView);
        Inap AmbilInapId(string id);
        bool HapusInap(string idnya);
    }
}
