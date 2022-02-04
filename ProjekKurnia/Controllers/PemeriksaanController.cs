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
    public class PemeriksaanController : Controller
    {
        private readonly AppDbContext _context;
        
        

        public PemeriksaanController(AppDbContext context)
        {
            _context = context;

        }
        public IActionResult Index()
        {
            var data = _context.Tb_Pemeriksaan.ToList();
            return View(data);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Create(Pemeriksaan parameter)
        {
            string[] Id = _context.Tb_Pemeriksaan.Select(x => x.Id).ToArray();

            int temp;
            foreach (var item in Id)
            {
                temp = Int32.Parse(item.Split("-")[1]);
                parameter.Id = "PM-" + (temp + 1);
            }

            if (parameter.Id == null)
            {
                parameter.Id = "PM-1";
            }

            var get = new Db_Pemeriksaan
            {
                Id = parameter.Id,
                TanggalB = parameter.TanggalB,
                Keluhan = parameter.Keluhan,
                Diagnosis = parameter.Diagnosis,
                Tindakan = parameter.Tindakan,
                PasienId = parameter.Pasien,
                DokterId = parameter.Dokter
            };

            if (ModelState.IsValid)
            {
                _context.Add(get);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
