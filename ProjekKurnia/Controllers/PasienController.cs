using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjekKurnia.Data;
using ProjekKurnia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia.Controllers
{
    //[Authorize]
    public class PasienController : Controller
    {
        private readonly AppDbContext _context;

        public PasienController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var data = _context.Tb_Pasien.ToList();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Pasien parameter)
        {
            if (ModelState.IsValid)
            {
                parameter.Id = parameter.TanggalL.Ticks.ToString("x");
                _context.Add(parameter);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(parameter);
        }
    }
}
