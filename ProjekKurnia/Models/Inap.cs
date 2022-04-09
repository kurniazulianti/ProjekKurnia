using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia.Models
{
    public class Inap
    {
        [Key]
        [DisplayName("Kode Rawat Inap")]
        public string Id { get; set; }

        [DisplayName("Jenis Ruangan")]
        public string Ruangan { get; set; }

        [DisplayName("Biaya Rawat Inap")]
        public string BiayaInap { get; set; }

        [DisplayName("Kode Pasien")]
        public Pasien Pasien { get; set; }

        [DisplayName("Kode Dokter")]
        public Dokter Dokter { get; set; }

        [DisplayName("Kode Departemen")]
        public Departemen Departemen { get; set; }
    }
}
