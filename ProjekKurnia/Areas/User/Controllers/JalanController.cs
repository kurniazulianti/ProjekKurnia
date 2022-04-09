using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjekKurnia.Models;
using ProjekKurnia.Services.JalanService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    [Area("User")]
    public class JalanController : Controller
    {
        private readonly IJalanService _servicejalan;
        public JalanController(IJalanService j)
        {
            _servicejalan = j;
        }
        public IActionResult Index()
        {
            var banyakData = new JalanDashboard();

            banyakData.jalan = _servicejalan.AmbilSemuaJalan();

            return View(banyakData);
        }

        public IActionResult Detail(string id)
        {
            Jalan cari = _servicejalan.AmbilJalanId(id);

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
        public IActionResult Create(Jalan jalan)
        {
            if (ModelState.IsValid)
            {
                _servicejalan.BuatJalanBaru(jalan);
                return Redirect("/User/Jalan/Index");
            }
            return View(jalan);
        }

        public IActionResult Edit(string id)
        {
            var cari = _servicejalan.AmbilJalanId(id);

            if (cari != null)
            {
                return View(cari);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Edit(Jalan jalan)
        {
            if (ModelState.IsValid)
            {
                var cari = _servicejalan.AmbilJalanId(jalan.Id);

                if (cari != null)
                {
                    _servicejalan.UbahJalan(jalan);

                    return Redirect("/User/Jalan/Index");
                }
                return NotFound();
            }
            return View(jalan);
        }

        public IActionResult Delete(string id)
        {
            var cari = _servicejalan.AmbilJalanId(id);

            if (cari != null)
            {
                _servicejalan.HapusJalan(id);
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
