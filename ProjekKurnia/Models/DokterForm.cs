using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia.Models
{
    public class DokterForm
    {
        [DisplayName("Kode Dokter")]
        public string Id { get; set; }

        [Required]
        [DisplayName("Nama Dokter")]
        public string NamaD { get; set; }

        [Required]
        [DisplayName("No Hp")]
        public string Hp { get; set; }

        [Required]
        [DisplayName("Alamat")]
        public string Alamat { get; set; }

        [Required]
        [DisplayName("Tempat Lahir")]
        public string TempatD { get; set; }

        [Required]
        [DisplayName("Tanggal Lahir")]
        public DateTime TanggalD { get; set; }

        [Required]
        [DisplayName("Foto Dokter")]
        public string Image { get; set; }

        [Required]
        [DisplayName("Kode Departemen")]
        public Departemen Departemen { get; set; }
    }

    public class DokDashboard
    {
        public List<Dokter> dokter { get; set; }

        public DokDashboard()
        {
            dokter = new List<Dokter>();
        }
    }
}
