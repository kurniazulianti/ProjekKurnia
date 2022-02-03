using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia.Models
{
    public class Db_Pemeriksaan
    {
        [Key]
        public string Id { get; set; }

        public DateTime TanggalB { get; set; }

        public string Keluhan { get; set; }

        public string Diagnosis { get; set; }

        public string Tindakan { get; set; }

        [ForeignKey("Id")]
        public Pasien Pasien { get; set; }

        [ForeignKey("Id")]
        public Dokter Dokter { get; set; }
    }
}
