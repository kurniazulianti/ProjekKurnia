using Microsoft.AspNetCore.Http;
using ProjekKurnia.Data;
using ProjekKurnia.Helper;
using ProjekKurnia.Models;
using ProjekKurnia.Repositories.DokterRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia.Services.DokterService
{
    public class DokterService : IDokterService
    {
        private readonly IDokterRepository _dokterRepo;
        private readonly FileService _file;
        private readonly AppDbContext _context;
        public DokterService(IDokterRepository dokterRepo, FileService file, AppDbContext context)
        {
            _dokterRepo = dokterRepo;
            _file = file;
            _context = context;
        }
        public Dokter AmbilDokterId(string id)
        {
            return _dokterRepo.AmbilDokterIdAsync(id).Result;
        }

        public List<Dokter> AmbilSemuaDokter()
        {
            return _dokterRepo.AmbilSemuaDokterAsync().Result;
        }

        public bool BuatDokterBaru(Dokter baru, IFormFile Image)
        {
            string[] Id = _context.Tb_Dokter.Select(x => x.Id).ToArray();

            int temp;
            foreach (var item in Id)
            {
                temp = Int32.Parse(item.Split("-")[1]);
                baru.Id = "DK-" + (temp + 1);
            }

            if (baru.Id == null)
            {
                baru.Id = "DK-1";
            }

            baru.Image = _file.SimpanFile(Image).Result;

            return _dokterRepo.BuatDokterBaruAsync(baru).Result;

        }

        public bool HapusDokter(string idnya)
        {
            var cari = _dokterRepo.CariDokterAsync(idnya).Result;
            return _dokterRepo.HapusDokterAsync(cari).Result;
        }

        public bool UbahDokter(Dokter dariView, IFormFile Image)
        {
            var cari = _dokterRepo.CariDokterAsync(dariView.Id).Result;

            if (cari != null)
            {
                cari.Id = dariView.Id;
                cari.NamaD = dariView.NamaD;
                cari.TempatD = dariView.TempatD;
                cari.TanggalD = dariView.TanggalD;
                cari.Alamat = dariView.Alamat;
                cari.Hp = dariView.Hp;

                if (Image != null) cari.Image = _file.SimpanFile(Image).Result;
                else cari.Image = cari.Image;

                return _dokterRepo.UbahDokterAsync(cari).Result;
            }
            return false;
        }
    }
}
