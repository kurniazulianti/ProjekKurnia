using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia.Models
{
    public class Departemen
    {
        [Key]
        [DisplayName("Kode Departemen")]
        public string Id { get; set; }

        [DisplayName("Nama Departemen")]
        public string NamaDep { get; set; }
    }
}
