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
        [DisplayName("No Pasien")]
        public string Id { get; set; }

        [Required]
        [DisplayName("Nama Pasien")]
        public string NamaP { get; set; }

        [Required]
        [DisplayName("Jenis Kelamin")]
        public string Jk { get; set; }

        [Required]
        [DisplayName("Golongan Darah")]
        public string GolD { get; set; }

        [Required]
        [DisplayName("Tempat Lahir")]
        public string TempatL { get; set; }

        [Required]
        [DisplayName("Tanggal Lahir")]
        public DateTime TanggalL { get; set; }

        [Required]
        [DisplayName("Nama Ibu")]
        public string NamaIbu { get; set; }

        [Required]
        [DisplayName("Status Menikah")]
        public string StatusM { get; set; }
    }
}
