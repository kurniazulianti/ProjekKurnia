using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia.Models
{
    public class DepartemenForm
    {
        [DisplayName("Kode Departemen")]
        public string Id { get; set; }

        [Required]
        [DisplayName("Nama Departemen")]
        public string NamaDep { get; set; }
    }

    public class DepDashboard
    {
        public List<Departemen> dep { get; set; }

        public DepDashboard()
        {
            dep = new List<Departemen>();
        }
    }
}
