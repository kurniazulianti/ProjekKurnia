using Microsoft.AspNetCore.Http;
using ProjekKurnia.Data;
using ProjekKurnia.Helper;
using ProjekKurnia.Models;
using ProjekKurnia.Repositories.JalanRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia.Services.JalanService
{
    public class JalanService : IJalanService
    {
        private readonly IJalanRepository _jalanRepo;
        private readonly AppDbContext _context;
        public JalanService(IJalanRepository jalanRepo, AppDbContext context)
        {
            _jalanRepo = jalanRepo;
            _context = context;
        }
        public Jalan AmbilJalanId(string id)
        {
            return _jalanRepo.AmbilJalanIdAsync(id).Result;
        }

        public List<Jalan> AmbilSemuaJalan()
        {
            return _jalanRepo.AmbilSemuaJalanAsync().Result;
        }

        public bool BuatJalanBaru(Jalan baru)
        {
            string[] Id = _context.Tb_RawatJalan.Select(x => x.Id).ToArray();

            int temp;
            foreach (var item in Id)
            {
                temp = Int32.Parse(item.Split("-")[1]);
                baru.Id = "RJ-" + (temp + 1);
            }

            if (baru.Id == null)
            {
                baru.Id = "RJ-1";
            }

            return _jalanRepo.BuatJalanBaruAsync(baru).Result;
        }

        public bool HapusJalan(string idnya)
        {
            var cari = _jalanRepo.CariJalanAsync(idnya).Result;
            return _jalanRepo.HapusJalanAsync(cari).Result;
        }

        public bool UbahJalan(Jalan dariView)
        {
            var cari = _jalanRepo.CariJalanAsync(dariView.Id).Result;

            if(cari != null)
            {
                cari.Id = dariView.Id;
                cari.Biaya = dariView.Biaya;
                cari.Pasien = dariView.Pasien;
                cari.Dokter = dariView.Dokter;
                cari.Departemen = dariView.Departemen;

                return _jalanRepo.UbahJalanAsync(cari).Result;
            }
            return false;
        }
    }
}
