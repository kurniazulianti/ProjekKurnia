using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjekKurnia.Models;
using ProjekKurnia.Services.DokterService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Dokter dokter, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                _servicedok.BuatDokterBaru(dokter, Image);
                return Redirect("/Admin/Dokter");
            }
            return View(dokter);
        }

        public IActionResult Edit(string id)
        {
            var cari = _servicedok.AmbilDokterId(id);

            if (cari != null)
            {
                return View(cari);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(Dokter dokter, IFormFile Foto)
        {
            if (ModelState.IsValid)
            {
                var cari = _servicedok.AmbilDokterId(dokter.Id);

                if(cari != null)
                {
                    _servicedok.UbahDokter(dokter, Foto);

                    return Redirect("/Admin/Dokter/Index");
                }
                return NotFound();
            }
            return View(dokter);
        }

        public IActionResult Delete(string id)
        {
            var cari = _servicedok.AmbilDokterId(id);

            if (cari != null)
            {
                _servicedok.HapusDokter(id);
                return RedirectToAction("Index");
            }

            return NotFound();
        }
    }
}
