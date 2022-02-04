using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia.Models
{
    public class Db_Pemeriksaan
    {
        [Key]
        [DisplayName("No Berobat")]
        public string Id { get; set; }

        [DisplayName("Tanggal Berobat")]
        public DateTime TanggalB { get; set; }

        [DisplayName("Keluhan Pasien")]
        public string Keluhan { get; set; }

        [DisplayName("Diagnosis Dokter")]
        public string Diagnosis { get; set; }

        [DisplayName("Tindakan Pengobatan")]
        public string Tindakan { get; set; }

        [DisplayName("No Pasien")]
        public string PasienId { get; set; }

        [DisplayName("No Dokter")]
        public string DokterId { get; set; }


        [ForeignKey("PasienId")]
        public Pasien PasienFk { get; set; }

        [ForeignKey("DokterId")]
        public Dokter DokterFk { get; set; }

    }
}
