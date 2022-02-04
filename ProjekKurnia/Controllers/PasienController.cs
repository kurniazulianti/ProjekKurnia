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
    [Authorize]
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
        public async Task<IActionResult> Create(PaisenForm parameter)
        {
                string[] Id = _context.Tb_Pasien.Select(x => x.Id).ToArray();

                int temp;
                foreach (var item in Id)
                {
                    temp = Int32.Parse(item.Split("-")[1]);
                    parameter.Id = "PS-" + (temp + 1);
                }

                if (parameter.Id == null)
                {
                    parameter.Id = "PS-1";
                }

                var get = new Pasien
                {
                    Id = parameter.Id,
                    GolD = parameter.GolD,
                    Jk = parameter.Jk,
                    NamaIbu = parameter.NamaIbu,
                    NamaP = parameter.NamaP,
                    StatusM = parameter.StatusM,
                    TanggalL = parameter.TanggalL,
                    TempatL = parameter.TempatL
                };

            if (ModelState.IsValid)
            {
                _context.Add(get);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View(parameter);
        }
    }
}
