using System;

namespace ProjekKurnia.Controllers
{
    public class PemeriksaanForm
    {
        public string Id { get; internal set; }
        public DateTime TanggalB { get; internal set; }
        public string Keluhan { get; internal set; }
        public string Diagnosis { get; internal set; }
        public string Tindakan { get; internal set; }
        public object Pasien { get; internal set; }
    }
}