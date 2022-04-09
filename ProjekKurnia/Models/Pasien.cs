using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia.Models
{
    public class Pasien
    {
        [Key]
        [DisplayName("Kode Pasien")]
        public string Id { get; set; }

        [DisplayName("Nama Pasien")]
        public string NamaP { get; set; }

        [DisplayName("Tempat Lahir")]
        public string TempatL { get; set; }

        [DisplayName("Tanggal Lahir")]
        public DateTime TanggalL { get; set; }

        [DisplayName("Alamat")]
        public string Alamat { get; set; }

        [DisplayName("No Hp")]
        public string NoHp { get; set; }

        [DisplayName("Foto Pasien")]
        public string Image { get; set; }
    }
}
