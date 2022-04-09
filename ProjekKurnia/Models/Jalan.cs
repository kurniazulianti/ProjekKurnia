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

        [DisplayName("Biaya Perawatan")]
        public string Biaya { get; set; }

        [DisplayName("Kode Pasien")]
        public Pasien Pasien { get; set; }

        [DisplayName("Kode Dokter")]
        public Dokter Dokter { get; set; }

        [DisplayName("Kode Departemen")]
        public Departemen Departemen { get; set; }
    }
}
