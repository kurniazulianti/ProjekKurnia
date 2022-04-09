using ProjekKurnia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia.Services.DepartemenService
{
    public interface IDepartemenService
    {
        List<Departemen> AmbilSemuaDepartemen();
        bool BuatDepartemenBaru(Departemen baru);
        Departemen AmbilDepartemenId(string id);
        bool HapusDepartemen(string idnya);
    }
}
