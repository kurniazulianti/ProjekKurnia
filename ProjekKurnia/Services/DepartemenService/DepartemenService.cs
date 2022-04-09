using ProjekKurnia.Data;
using ProjekKurnia.Helper;
using ProjekKurnia.Models;
using ProjekKurnia.Repositories.DepartemenRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia.Services.DepartemenService
{
    public class DepartemenService : IDepartemenService
    {
        private readonly IDepartemenRepository _depRepo;
        private readonly AppDbContext _context;
        public DepartemenService(IDepartemenRepository depRepo, AppDbContext context)
        {
            _depRepo = depRepo;
            _context = context;
        }

        public Departemen AmbilDepartemenId(string id)
        {
            return _depRepo.AmbilDepartemenIdAsync(id).Result;
        }

        public List<Departemen> AmbilSemuaDepartemen()
        {
            return _depRepo.AmbilSemuaDepartemenAsync().Result;
        }

        public bool BuatDepartemenBaru(Departemen baru)
        {
            string[] Id = _context.Tb_Departemen.Select(x => x.Id).ToArray();

            int temp;
            foreach (var item in Id)
            {
                temp = Int32.Parse(item.Split("-")[1]);
                baru.Id = "DP-" + (temp + 1);
            }

            if (baru.Id == null)
            {
                baru.Id = "DP-1";
            }

            return _depRepo.BuatDepartemenBaruAsync(baru).Result;
        }

        public bool HapusDepartemen(string idnya)
        {
            var cari = _depRepo.CariDepartemenAsync(idnya).Result;
            return _depRepo.HapusDepartemenAsync(cari).Result;
        }
    }
}
