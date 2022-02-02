using Microsoft.AspNetCore.Mvc;
using ProjekKurnia.Data;
using ProjekKurnia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia.Controllers
{
    public class PasienController : Controller
    {
        private readonly AppDbContext _context;

        public PasienController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Create(Pasien parameter)
        {
            if (ModelState.IsValid)
            {
              //  parameter.Id = parameter..Ticks.ToString("x");
                _context.Add(parameter);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(parameter);
        }
    }
}
