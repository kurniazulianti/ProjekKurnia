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
        [DisplayName("Kode Dokter")]
        public string Id { get; set; }

        [DisplayName("Nama Dokter")]
        public string NamaD { get; set; }

        [DisplayName("No Hp")]
        public string Hp { get; set; }

        [DisplayName("Alamat")]
        public string Alamat { get; set; }

        [DisplayName("Tempat Lahir")]
        public string TempatD { get; set; }

        [DisplayName("Tanggal Lahir")]
        public DateTime TanggalD { get; set; }

        [DisplayName("Foto Dokter")]
        public string Image { get; set; }

        [DisplayName("Kode Departemen")]
        public string Departemen { get; set; }



    }
}
