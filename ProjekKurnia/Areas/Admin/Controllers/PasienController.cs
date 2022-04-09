using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjekKurnia.Models;
using ProjekKurnia.Services.PasienService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class PasienController : Controller
    {
        private readonly IPasienService _servicepas;
        public PasienController(IPasienService p)
        {
            _servicepas = p;       
        }
        public IActionResult Index()
        {
            var banyakData = new PasDashboard();

            banyakData.pas = _servicepas.AmbilSemuaPasien();

            return View(banyakData);
        }

        public IActionResult Detail(string id)
        {
            Pasien cari = _servicepas.AmbilPasienId(id);

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
        public IActionResult Create(Pasien pasien, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                _servicepas.BuatPasienBaru(pasien, Image);
                return Redirect("/Admin/Pasien/Index");
            }
            return View(pasien);
        }

        public IActionResult Edit(string id)
        {
            var cari = _servicepas.AmbilPasienId(id);

            if (cari != null)
            {
                return View(cari);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(Pasien pasien, IFormFile Foto)
        {
            if (ModelState.IsValid)
            {
                var cari = _servicepas.AmbilPasienId(pasien.Id);

                if (cari != null)
                {
                    _servicepas.UbahPasien(pasien, Foto);

                    return Redirect("/Admin/Pasien/Index");
                }
                return NotFound();
            }
            return View(pasien);
        }

        public IActionResult Delete(string id)
        {
            var cari = _servicepas.AmbilPasienId(id);

            if (cari != null)
            {
                _servicepas.HapusPasien(id);
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
