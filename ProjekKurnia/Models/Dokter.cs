using System;
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

        [Required]
        [DisplayName("Nama Dokter")]
        public string NamaD { get; set; }

        [Required]
        [DisplayName("No Hp")]
        public string Hp { get; set; }

        [Required]
        [DisplayName("Alamat")]
        public string alamat { get; set; }

        [Required]
        [DisplayName("Spesialis")]
        public string Specialis { get; set; }

        [Required]
        [DisplayName("No Ijin Praktek")]
        public string Ijin { get; set; }


    }
}
