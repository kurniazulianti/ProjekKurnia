using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjekKurnia.Models;
using ProjekKurnia.Services.InapService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    [Area("User")]
    public class InapController : Controller
    {
        private readonly IInapService _serviceinap;
        public InapController(IInapService i)
        {
            _serviceinap = i;
        }
        public IActionResult Index()
        {
            var banyakData = new InapDashboard();

            banyakData.inap = _serviceinap.AmbilSemuaInap();

            return View(banyakData);
        }

        public IActionResult Detail(string id)
        {
            Inap cari = _serviceinap.AmbilInapId(id);

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
        public IActionResult Create(Inap inap)
        {
            if (ModelState.IsValid)
            {
                _serviceinap.BuatInapBaru(inap);
                return Redirect("/User/Inap/Index");
            }
            return View(inap);
        }

        public IActionResult Edit(string id)
        {
            var cari = _serviceinap.AmbilInapId(id);

            if (cari != null)
            {
                return View(cari);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(Inap inap)
        {
            if (ModelState.IsValid)
            {
                var cari = _serviceinap.AmbilInapId(inap.Id);

                if (cari != null)
                {
                    _serviceinap.UbahInap(inap);

                    return Redirect("/User/Inap/Index");
                }
                return NotFound();
            }
            return View(inap);
        }

        public IActionResult Delete(string id)
        {
            var cari = _serviceinap.AmbilInapId(id);

            if (cari != null)
            {
                _serviceinap.HapusInap(id);
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
