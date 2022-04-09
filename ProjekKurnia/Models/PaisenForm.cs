using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia.Models
{
    public class PaisenForm
    {
        [DisplayName("Kode Pasien")]
        public string Id { get; set; }

        [Required]
        [DisplayName("Nama Pasien")]
        public string NamaP { get; set; }

        [Required]
        [DisplayName("Tempat Lahir")]
        public string TempatL { get; set; }

        [Required]
        [DisplayName("Tanggal Lahir")]
        public DateTime TanggalL { get; set; }

        [Required]
        [DisplayName("Alamat")]
        public string Alamat { get; set; }

        [Required]
        [DisplayName("No Hp")]
        public string NoHp { get; set; }

        [Required]
        [DisplayName("Foto Pasien")]
        public string Image { get; set; }
    }

    public class PasDashboard
    {
        public List<Pasien> pas { get; set; }
        public List<Dokter> dok { get; set; }

        public PasDashboard()
        {
            pas = new List<Pasien>();
            dok = new List<Dokter>();
        }
    }
}
