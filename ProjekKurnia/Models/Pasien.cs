﻿using System;
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
        [DisplayName("No Pasien")]
        public string Id { get; set; }

        [DisplayName("Nama Pasien")]
        public string NamaP { get; set; }

        [DisplayName("Jenis Kelamin")]
        public string Jk { get; set; }

        [DisplayName("Golongan Darah")]
        public string GolD { get; set; }

        [DisplayName("Tempat Lahir")]
        public string TempatL { get; set; }

        [DisplayName("Tanggal Lahir")]
        public DateTime TanggalL { get; set; }

        [DisplayName("Nama Ibu")]
        public string NamaIbu { get; set; }

        [DisplayName("Status Menikah")]
        public string StatusM { get; set; }
    }
}
