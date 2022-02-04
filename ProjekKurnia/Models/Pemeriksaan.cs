using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia.Models
{
    public class Pemeriksaan
    {
        [Key]
        [DisplayName("No Berobat")]
        public string Id { get; set; }

        [Required]
        [DisplayName("Tanggal Berobat")]
        public DateTime TanggalB { get; set; }

        [Required]
        [DisplayName("Keluhan Pasien")]
        public string Keluhan { get; set; }

        [Required]
        [DisplayName("Diagnosis Dokter")]
        public string Diagnosis { get; set; }

        [Required]
        [DisplayName("Tindakan Pengobatan")]
        public string Tindakan { get; set; }

        [Required]
        [DisplayName("No Pasien")]
        public string Pasien { get; set; }

        [Required]
        [DisplayName("No Dokter")]
        public string Dokter { get; set; }

    }
}
