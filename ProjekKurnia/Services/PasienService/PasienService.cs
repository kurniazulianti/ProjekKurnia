using Microsoft.AspNetCore.Http;
using ProjekKurnia.Data;
using ProjekKurnia.Helper;
using ProjekKurnia.Models;
using ProjekKurnia.Repositories.PasienRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia.Services.PasienService
{
    public class PasienService : IPasienService
    {
        private readonly IPasienRepository _pasienRepo;
        private readonly FileService _file;
        private readonly AppDbContext _context;
        public PasienService(IPasienRepository pasienRepo, FileService file, AppDbContext context)
        {
            _pasienRepo = pasienRepo;
            _file = file;
            _context = context;
        }
        public Pasien AmbilPasienId(string id)
        {
            return _pasienRepo.AmbilPasienIdAsync(id).Result;
        }

        public List<Pasien> AmbilSemuaPasien()
        {
            return _pasienRepo.AmbilSemuaPasienAsync().Result;
        }

        public bool BuatPasienBaru(Pasien baru, IFormFile Image)
        {
            string[] Id = _context.Tb_Pasien.Select(x => x.Id).ToArray();

            int temp;
            foreach (var item in Id)
            {
                temp = Int32.Parse(item.Split("-")[1]);
                baru.Id = "PS-" + (temp + 1);
            }

            if (baru.Id == null)
            {
                baru.Id = "PS-1";
            }

            baru.Image = _file.SimpanFile(Image).Result;

            return _pasienRepo.BuatPasienBaruAsync(baru).Result;

        }

        public bool HapusPasien(string idnya)
        {
            var cari = _pasienRepo.CariPasienAsync(idnya).Result;
            return _pasienRepo.HapusPasienAsync(cari).Result;
        }

        public bool UbahPasien(Pasien dariView, IFormFile Image)
        {
            var cari = _pasienRepo.CariPasienAsync(dariView.Id).Result;

            if (cari != null)
            {
                cari.Id = dariView.Id;
                cari.NamaP = dariView.NamaP;
                cari.TempatL = dariView.TempatL;
                cari.TanggalL = dariView.TanggalL;
                cari.Alamat = dariView.Alamat;
                cari.NoHp = dariView.NoHp;

                if (Image != null) cari.Image = _file.SimpanFile(Image).Result;
                else cari.Image = cari.Image;

                return _pasienRepo.UbahPasienAsync(cari).Result;
            }
            return false;
        }
    }
}
