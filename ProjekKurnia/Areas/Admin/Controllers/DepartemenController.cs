using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjekKurnia.Models;
using ProjekKurnia.Services.DepartemenService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class DepartemenController : Controller
    {
        private readonly IDepartemenService _service;
        public DepartemenController(IDepartemenService d)
        {
            _service = d;
        }
        public IActionResult Index()
        
        {
            var banyakData = new DepDashboard();

            banyakData.dep = _service.AmbilSemuaDepartemen();

            return View(banyakData);
        }

        public IActionResult Detail(string id)
        {
            Departemen cari = _service.AmbilDepartemenId(id);

            if(cari != null)
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
        public IActionResult Create(Departemen departemen)
        {
            if (ModelState.IsValid)
            {
                _service.BuatDepartemenBaru(departemen);
                return Redirect("/Admin/Departemen/Index");
            }
            return View(departemen);
        }

        public IActionResult Delete(string id)
        {
            var cari = _service.AmbilDepartemenId(id);

            if(cari != null)
            {
                _service.HapusDepartemen(id);
                return RedirectToAction("Index");
            }
            return NotFound();
        }
    }
}
