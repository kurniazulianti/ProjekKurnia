using ProjekKurnia.Data;
using ProjekKurnia.Models;
using ProjekKurnia.Repositories.InapRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia.Services.InapService
{
    public class InapService : IInapService
    {
        private readonly IInapRepository _inapRepo;
        private readonly AppDbContext _context;
        public InapService(IInapRepository inapRepo, AppDbContext context)
        {
            _inapRepo = inapRepo;
            _context = context;
        }
        public Inap AmbilInapId(string id)
        {
            return _inapRepo.AmbilInapIdAsync(id).Result;
        }

        public List<Inap> AmbilSemuaInap()
        {
            return _inapRepo.AmbilSemuaInapAsync().Result;
        }

        public bool BuatInapBaru(Inap baru)
        {
            string[] Id = _context.Tb_RawatInap.Select(x => x.Id).ToArray();

            int temp;
            foreach (var item in Id)
            {
                temp = Int32.Parse(item.Split("-")[1]);
                baru.Id = "RN" + (temp + 1);
            }

            if (baru.Id == null)
            {
                baru.Id = "RN-1";
            }

            return _inapRepo.BuatInapBaruAsync(baru).Result;
        }

        public bool HapusInap(string idnya)
        {
            var cari = _inapRepo.CariInapAsync(idnya).Result;
            return _inapRepo.HapusInapAsync(cari).Result;
        }

        public bool UbahInap(Inap dariView)
        {
            var cari = _inapRepo.CariInapAsync(dariView.Id).Result;

            if (cari != null)
            {
                cari.Id = dariView.Id;
                cari.Ruangan = dariView.Ruangan;
                cari.BiayaInap = dariView.BiayaInap;
                cari.Pasien = dariView.Pasien;
                cari.Dokter = dariView.Dokter;
                cari.Departemen = dariView.Departemen;

                return _inapRepo.UbahInapAsync(cari).Result;
            }
            return false;
        }
    }
}
