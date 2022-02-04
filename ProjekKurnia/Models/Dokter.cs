﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia.Models
{
    public class Dokter
    {

        [Key]
        [DisplayName("No Dokter")]
        public string Id { get; set; }

        [DisplayName("Nama Dokter")]
        public string NamaD { get; set; }

        [DisplayName("No Hp")]
        public string Hp { get; set; }

        [DisplayName("Alamat")]
        public string Alamat { get; set; }

        [DisplayName("Tanggal Lahir")]
        public DateTime TanggalD { get; set; }

        [DisplayName("Spesialis")]
        public string Specialis { get; set; }



    }
}
