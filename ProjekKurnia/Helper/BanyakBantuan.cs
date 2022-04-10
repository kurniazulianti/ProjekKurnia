using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia.Helper
{
    public class BanyakBantuan
    {
        public int BuatOtp()
        {
            Random start = new Random();

            int valuenya = start.Next(1000, 9999);

            return valuenya;
        }

        public Object BuatResponAPI(int respon_code, string message, Object data)
        {
            return new
            {
                status = respon_code == 200 ? "SUKSES" : "GAGAL",
                respon_code,
                message,
                data
            };
        }

        //API
        public int CodeOK = 200;
        public int CodeBadRequest = 400;
        public int CodeInternalServerError = 500;

        public string PesanGetSukses(string rest)
        {
            return "Berhasil ambil data " + rest;
        }

        public string PesanTambahSukses(string rest)
        {
            return "Berhasil menambah data " + rest;
        }
        public string PesanUbahSukses(string rest)
        {
            return "Berhasil ubah data " + rest;
        }
        public string PesanHapusSukses(string rest)
        {
            return "Berhasil hapus data" + rest;
        }
        public string PesanTidakDitemukan (string rest)
        {
            return "Data " + rest + "tidak ditemukan";
        }
        public string PesanInputanSalah(string rest)
        {
            return "Inputan untuk data " + rest + "salah";
        }
    }
}
