using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjekKurnia.Data;
using ProjekKurnia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ProjekKurnia.Controllers
{
    public class AkunController : Controller
    {
        private readonly AppDbContext _context;

        public AkunController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Daftar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Daftar(User datanya)
        {
            var deklarRole = _context.Tb_Roles.Where(x => x.Id == "1").FirstOrDefault();

            datanya.Roles = deklarRole;

            _context.Add(datanya);
            _context.SaveChanges();

            return RedirectToAction("Masuk");
        }

        public IActionResult Masuk()
        {
            return View();
        }

        [HttpPost]

        public async Task<IActionResult> Masuk(User datanya)
        {
            var cari = _context.Tb_User.Where(
                bebas =>
                bebas.Username == datanya.Username
                &&
                bebas.Password == datanya.Password
            ).FirstOrDefault();

            var cariusername = _context.Tb_User.Where(
                bebas =>
                bebas.Username == datanya.Username
            ).FirstOrDefault();

            if (cariusername != null)
            {
                var cekpassword = _context.Tb_User.Where(
                    bebas =>
                    bebas.Username == datanya.Username
                    &&
                    bebas.Password == datanya.Password
                )
                    .Include(bebas2 => bebas2.Roles)
                    .FirstOrDefault();

                if (cekpassword != null)
                {
                    var daftar = new List<Claim>
                    {
                        new Claim("Username", cariusername.Username),
                        new Claim("Role", cariusername.Roles.Id)
                    };

                   
                    await HttpContext.SignInAsync(
                        new ClaimsPrincipal(
                            new ClaimsIdentity(daftar, "Cookie", "Username", "Role")
                    ));

                    if (cariusername.Roles.Id == "1") 
                    {

                        return RedirectToAction(controllerName: "Pasien", actionName: "Index");

                    }

                    return RedirectToAction(controllerName: "Dokter", actionName: "Index"); 
                }

                ViewBag.pesan = "Passwordnya Salah";

                return View(datanya);
            }   

            ViewBag.pesan = "Usernamenya Tidak Ada";

            return View(datanya);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
