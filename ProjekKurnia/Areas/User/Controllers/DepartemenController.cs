using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjekKurnia.Models;
using ProjekKurnia.Services.DepartemenService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia.Areas.User.Controllers
{
    [Authorize(Roles = "User")]
    [Area("User")]
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

            if (cari != null)
            {
                return View(cari);
            }
            return NotFound();
        }
    }
}
