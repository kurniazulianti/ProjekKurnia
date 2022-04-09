using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia.Models
{
    public class JalanForm
    {
        [DisplayName("Kode Rawat Jalan")]
        public string Id { get; set; }

        [Required]
        [DisplayName("Biaya Perawatan")]
        public string Biaya { get; set; }

        [Required]
        [DisplayName("Kode Pasien")]
        public string Pasien { get; set; }

        [Required]
        [DisplayName("Kode Dokter")]
        public string Dokter { get; set; }

        [Required]
        [DisplayName("Kode Departemen")]
        public string Departemen { get; set; }
    }

    public class JalanDashboard
    {
        public List<Jalan> jalan { get; set; }

        public JalanDashboard()
        {
            jalan = new List<Jalan>();
        }
    }
}
