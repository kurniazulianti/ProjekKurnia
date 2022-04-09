using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjekKurnia.Models;
using ProjekKurnia.Services.JalanService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
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
