using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia.Models
{
    public class Jalan
    {
        [Key]
        [DisplayName("Kode Rawat Jalan")]
        public string Id { get; set; }

        [DisplayName("Kode Pasien")]
        public string Pasien { get; set; }

        [DisplayName("Kode Dokter")]
        public string Dokter { get; set; }

        [DisplayName("Kode Departemen")]
        public string Departemen { get; set; }

        [DisplayName("Biaya Perawatan")]
        public string Biaya { get; set; }

    }
}
