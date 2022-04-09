using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia.Helper
{
    public class BuatPrimaryKey
    {
        public static string BuatPrimaryDenganGuild()
        {
            Guid buat = Guid.NewGuid();
            return buat.ToString();
        }
    }
}
