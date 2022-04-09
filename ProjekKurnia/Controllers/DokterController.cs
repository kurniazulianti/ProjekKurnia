//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using ProjekKurnia.Data;
//using ProjekKurnia.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace ProjekKurnia.Controllers
//{
//    public class DokterController : Controller
//    {
//        private readonly AppDbContext _context;

//        public DokterController(AppDbContext context)
//        {
//            _context = context;
//        }
//        public IActionResult Index()
//        {
//            var data = _context.Tb_Dokter.ToList();
//            return View(data);
//        }

//        public IActionResult Create()
//        {
//            return View();
//        }

//        [HttpPost]
//        public async Task<IActionResult> Create(DokterForm parameter) 
//        {
//            string[] Id = _context.Tb_Dokter.Select(x => x.Id).ToArray();

//            int temp;
//            foreach (var item in Id)
//            {
//                temp = Int32.Parse(item.Split("-")[1]);
//                parameter.Id = "DK-" + (temp + 1);
//            }

//            if (parameter.Id == null)
//            {
//                parameter.Id = "DK-1";
//            }

//            var get = new Dokter
//            {
//                Alamat = parameter.Alamat,
//                Hp = parameter.Hp,
//                Id = parameter.Id,
//                NamaD = parameter.NamaD,
//                Specialis = parameter.Specialis,
//                TanggalD = parameter.TanggalD
//            };

//            if (ModelState.IsValid)
//            {
//                _context.Add(get);
//                await _context.SaveChangesAsync();

//                return RedirectToAction("Index");
//            }

//            return View(parameter);
//        }
//    }
//}
