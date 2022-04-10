using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia.Models
{
    public class InapForm
    {
        [DisplayName("Kode Rawat Inap")]
        public string Id { get; set; }


        [Required]
        [DisplayName("Kode Pasien")]
        public Pasien Pasien { get; set; }

        [Required]
        [DisplayName("Kode Dokter")]
        public Dokter Dokter { get; set; }

        [Required]
        [DisplayName("Kode Departemen")]
        public Departemen Departemen { get; set; }

        [Required]
        [DisplayName("Jenis Ruangan")]
        public string Ruangan { get; set; }

        [Required]
        [DisplayName("Biaya Rawat Inap")]
        public string BiayaInap { get; set; }

    }

    public class InapDashboard
    {
        public List<Inap> inap { get; set; }

        public InapDashboard()
        {
            inap = new List<Inap>();
        }
    }
}
