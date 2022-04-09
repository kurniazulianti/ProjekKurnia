using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjekKurnia.Models;
using ProjekKurnia.Services.DokterService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    [Area("User")]
    public class DokterController : Controller
    {
        private readonly IDokterService _servicedok;
        public DokterController(IDokterService servicedok)
        {
            _servicedok = servicedok;
        }
        public IActionResult Index()
        {
            var banyakData = new DokDashboard();

            banyakData.dokter = _servicedok.AmbilSemuaDokter();

            return View(banyakData);
        }

        public IActionResult Detail(string id)
        {
            Dokter cari = _servicedok.AmbilDokterId(id);

            if (cari != null)
            {
                return View(cari);
            }
            return NotFound();
        }
    }
}
