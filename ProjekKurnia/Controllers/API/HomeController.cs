using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjekKurnia.Helper;
using ProjekKurnia.Models;
using ProjekKurnia.Services.AkunService;
using ProjekKurnia.Services.DepartemenService;
using ProjekKurnia.Services.DokterService;
using ProjekKurnia.Services.InapService;
using ProjekKurnia.Services.JalanService;
using ProjekKurnia.Services.PasienService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia.Controllers.API
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        //service
        private readonly IDepartemenService _depservice;
        private readonly IDokterService _dokservice;
        private readonly IPasienService _passervice;
        private readonly IJalanService _jalanservice;
        private readonly IInapService _inapservice;

        //class
        private BanyakBantuan _bantu = new();

        //tampungan objek
        private object _respon;
        private object _objek;

        //tampungan model
        private Departemen _MDep;
        private Dokter _MDok;
        private Pasien _MPas;
        private Jalan _MJalan;
        private Inap _MInap;

        //tampungan string
        private string SDepartemen = "Departemen";
        private string SDokter = "Dokter";
        private string SPasien = "Pasien";
        private string SJalan = "Jalan";
        private string SInap = "Inap";

        public HomeController(IDepartemenService depservice, IDokterService dokservice, IPasienService passervice, IJalanService jalanservice, IInapService inapService)
        {
            _depservice = depservice;
            _dokservice = dokservice;
            _passervice = passervice;
            _jalanservice = jalanservice;
            _inapservice = inapService;
        }

        //Departemen
        [Route("departemen")]
        public IActionResult Departemen()
        {
            _objek = _depservice.AmbilSemuaDepartemen();

            _respon = _bantu.BuatResponAPI(_bantu.CodeOK, _bantu.PesanGetSukses(SDepartemen), _objek);
            return Ok(_respon);
        }

        [Route("departemen")]
        [HttpPost]
        public IActionResult TambahDepartemen(Departemen parameternya)
        {
            if (ModelState.IsValid)
            {
                _depservice.BuatDepartemenBaru(parameternya);

                _respon = _bantu.BuatResponAPI(_bantu.CodeOK, _bantu.PesanTambahSukses(SDepartemen), parameternya);
                return Ok(_respon);
            }
            _respon = _bantu.BuatResponAPI(_bantu.CodeBadRequest, _bantu.PesanInputanSalah(SDepartemen), null);
            return Ok(_respon);
        }

        [Route("departemen/{idnya}")]
        [HttpDelete]
        public IActionResult HapusDepartemen(string idnya)
        {
            try
            {
                _MDep = _depservice.AmbilDepartemenId(idnya);

                if(_MDep != null)
                {
                    _depservice.HapusDepartemen(idnya);

                    _respon = _bantu.BuatResponAPI(_bantu.CodeOK, _bantu.PesanHapusSukses(SDepartemen), _MDep);
                    return Ok(_respon);
                }
                _respon = _bantu.BuatResponAPI(_bantu.CodeInternalServerError, _bantu.PesanTidakDitemukan(SDepartemen), null);
                return Ok(_respon);
            }
            catch
            {
                _respon = _bantu.BuatResponAPI(_bantu.CodeBadRequest, _bantu.PesanInputanSalah(SDepartemen), null);
                return Ok(_respon);
            }
        }

        [Route("departemen/{idnya}")]
        public IActionResult DetailDepartemen(string idnya)
        {
            _MDep = _depservice.AmbilDepartemenId(idnya);

            if (_MDep != null)
            {
                _respon = _bantu.BuatResponAPI(_bantu.CodeOK, _bantu.PesanGetSukses(SDepartemen), _MDep);
                return Ok(_respon);
            }

            _respon = _bantu.BuatResponAPI(_bantu.CodeBadRequest, _bantu.PesanTidakDitemukan(SDepartemen), null);
            return Ok(_respon);
        }

        //Dokter
        [Route("dokter")]
        public IActionResult Dokter()
        {
            _objek = _dokservice.AmbilSemuaDokter();

            _respon = _bantu.BuatResponAPI(_bantu.CodeOK, _bantu.PesanGetSukses(SDokter), _objek);
            return Ok(_respon);
        }

        [Route("dokter")]
        [HttpPost]
        public IActionResult TambahDokter(Dokter parameternya, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                _dokservice.BuatDokterBaru(parameternya, Image);

                _respon = _bantu.BuatResponAPI(_bantu.CodeOK, _bantu.PesanTambahSukses(SDokter), parameternya);
                return Ok(_respon);
            }
            _respon = _bantu.BuatResponAPI(_bantu.CodeBadRequest, _bantu.PesanInputanSalah(SDokter), null);
            return Ok(_respon);
        }

        [Route("dokter")]
        [HttpPut]
        public IActionResult UbahDokter(Dokter parameternya, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                _MDok = _dokservice.AmbilDokterId(parameternya.Id);
                if (_MDok != null)
                {
                    _dokservice.UbahDokter(parameternya, Image);

                    _MDok = _dokservice.AmbilDokterId(parameternya.Id);

                    _respon = _bantu.BuatResponAPI(_bantu.CodeOK, _bantu.PesanUbahSukses(SDokter), _MDok);
                    return Ok(_respon);
                }

                _respon = _bantu.BuatResponAPI(_bantu.CodeInternalServerError, _bantu.PesanTidakDitemukan(SDokter), null);
                return Ok(_respon);
            }

            _respon = _bantu.BuatResponAPI(_bantu.CodeBadRequest, _bantu.PesanInputanSalah(SDokter), null);
            return Ok(_respon);
        }

        [Route("dokter/{idnya}")]
        [HttpDelete]
        public IActionResult HapusDokter(string idnya)
        {
            try
            {
                _MDok = _dokservice.AmbilDokterId(idnya);

                if (_MDok != null)
                {
                    _dokservice.HapusDokter(idnya);

                    _respon = _bantu.BuatResponAPI(_bantu.CodeOK, _bantu.PesanHapusSukses(SDokter), _MDok);
                    return Ok(_respon);
                }
                _respon = _bantu.BuatResponAPI(_bantu.CodeInternalServerError, _bantu.PesanTidakDitemukan(SDokter), null);
                return Ok(_respon);
            }
            catch
            {
                _respon = _bantu.BuatResponAPI(_bantu.CodeBadRequest, _bantu.PesanInputanSalah(SDokter), null);
                return Ok(_respon);
            }
        }

        [Route("dokter/{idnya}")]
        public IActionResult DetailDokter(string idnya)
        {
            _MDok = _dokservice.AmbilDokterId(idnya);

            if (_MDep != null)
            {
                _respon = _bantu.BuatResponAPI(_bantu.CodeOK, _bantu.PesanGetSukses(SDokter), _MDok);
                return Ok(_respon);
            }

            _respon = _bantu.BuatResponAPI(_bantu.CodeBadRequest, _bantu.PesanTidakDitemukan(SDokter), null);
            return Ok(_respon);
        }

        //Pasien
        [Route("pasien")]
        public IActionResult Pasien()
        {
            _objek = _passervice.AmbilSemuaPasien();

            _respon = _bantu.BuatResponAPI(_bantu.CodeOK, _bantu.PesanGetSukses(SPasien), _objek);
            return Ok(_respon);
        }

        [Route("pasien")]
        [HttpPost]
        public IActionResult TambahPasien(Pasien parameternya, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                _passervice.BuatPasienBaru(parameternya, Image);

                _respon = _bantu.BuatResponAPI(_bantu.CodeOK, _bantu.PesanTambahSukses(SPasien), parameternya);
                return Ok(_respon);
            }
            _respon = _bantu.BuatResponAPI(_bantu.CodeBadRequest, _bantu.PesanInputanSalah(SPasien), null);
            return Ok(_respon);
        }

        [Route("pasien")]
        [HttpPut]
        public IActionResult UbahPasien(Pasien parameternya, IFormFile Image)
        {
            if (ModelState.IsValid)
            {
                _MPas = _passervice.AmbilPasienId(parameternya.Id);
                if (_MPas != null)
                {
                    _passervice.UbahPasien(parameternya, Image);

                    _MPas = _passervice.AmbilPasienId(parameternya.Id);

                    _respon = _bantu.BuatResponAPI(_bantu.CodeOK, _bantu.PesanUbahSukses(SPasien), _MPas);
                    return Ok(_respon);
                }

                _respon = _bantu.BuatResponAPI(_bantu.CodeInternalServerError, _bantu.PesanTidakDitemukan(SPasien), null);
                return Ok(_respon);
            }

            _respon = _bantu.BuatResponAPI(_bantu.CodeBadRequest, _bantu.PesanInputanSalah(SPasien), null);
            return Ok(_respon);
        }

        [Route("pasien/{idnya}")]
        [HttpDelete]
        public IActionResult HapusPasien(string idnya)
        {
            try
            {
                _MPas = _passervice.AmbilPasienId(idnya);

                if (_MPas != null)
                {
                    _passervice.HapusPasien(idnya);

                    _respon = _bantu.BuatResponAPI(_bantu.CodeOK, _bantu.PesanHapusSukses(SPasien), _MPas);
                    return Ok(_respon);
                }
                _respon = _bantu.BuatResponAPI(_bantu.CodeInternalServerError, _bantu.PesanTidakDitemukan(SPasien), null);
                return Ok(_respon);
            }
            catch
            {
                _respon = _bantu.BuatResponAPI(_bantu.CodeBadRequest, _bantu.PesanInputanSalah(SPasien), null);
                return Ok(_respon);
            }
        }

        [Route("pasien/{idnya}")]
        public IActionResult DetailPasien(string idnya)
        {
            _MPas = _passervice.AmbilPasienId(idnya);

            if (_MPas != null)
            {
                _respon = _bantu.BuatResponAPI(_bantu.CodeOK, _bantu.PesanGetSukses(SPasien), _MPas);
                return Ok(_respon);
            }

            _respon = _bantu.BuatResponAPI(_bantu.CodeBadRequest, _bantu.PesanTidakDitemukan(SPasien), null);
            return Ok(_respon);
        }

        //RawatJalan
        [Route("jalan")]
        public IActionResult Jalan()
        {
            _objek = _jalanservice.AmbilSemuaJalan();

            _respon = _bantu.BuatResponAPI(_bantu.CodeOK, _bantu.PesanGetSukses(SJalan), _objek);
            return Ok(_respon);
        }

        [Route("jalan")]
        [HttpPost]
        public IActionResult TambahJalan(Jalan parameternya)
        {
            if (ModelState.IsValid)
            {
                _jalanservice.BuatJalanBaru(parameternya);

                _respon = _bantu.BuatResponAPI(_bantu.CodeOK, _bantu.PesanTambahSukses(SJalan), parameternya);
                return Ok(_respon);
            }
            _respon = _bantu.BuatResponAPI(_bantu.CodeBadRequest, _bantu.PesanInputanSalah(SJalan), null);
            return Ok(_respon);
        }

        [Route("jalan")]
        [HttpPut]
        public IActionResult UbahJalan(Jalan parameternya)
        {
            if (ModelState.IsValid)
            {
                _MJalan = _jalanservice.AmbilJalanId(parameternya.Id);
                if (_MJalan != null)
                {
                    _jalanservice.UbahJalan(parameternya);

                    _MJalan = _jalanservice.AmbilJalanId(parameternya.Id);

                    _respon = _bantu.BuatResponAPI(_bantu.CodeOK, _bantu.PesanUbahSukses(SJalan), _MJalan);
                    return Ok(_respon);
                }

                _respon = _bantu.BuatResponAPI(_bantu.CodeInternalServerError, _bantu.PesanTidakDitemukan(SJalan), null);
                return Ok(_respon);
            }

            _respon = _bantu.BuatResponAPI(_bantu.CodeBadRequest, _bantu.PesanInputanSalah(SJalan), null);
            return Ok(_respon);
        }

        [Route("jalan/{idnya}")]
        [HttpDelete]
        public IActionResult HapusJalan(string idnya)
        {
            try
            {
                _MJalan = _jalanservice.AmbilJalanId(idnya);

                if (_MJalan != null)
                {
                    _jalanservice.HapusJalan(idnya);

                    _respon = _bantu.BuatResponAPI(_bantu.CodeOK, _bantu.PesanHapusSukses(SJalan), _MJalan);
                    return Ok(_respon);
                }
                _respon = _bantu.BuatResponAPI(_bantu.CodeInternalServerError, _bantu.PesanTidakDitemukan(SJalan), null);
                return Ok(_respon);
            }
            catch
            {
                _respon = _bantu.BuatResponAPI(_bantu.CodeBadRequest, _bantu.PesanInputanSalah(SJalan), null);
                return Ok(_respon);
            }
        }

        [Route("jalan/{idnya}")]
        public IActionResult DetailJalan(string idnya)
        {
            _MJalan = _jalanservice.AmbilJalanId(idnya);

            if (_MJalan != null)
            {
                _respon = _bantu.BuatResponAPI(_bantu.CodeOK, _bantu.PesanGetSukses(SJalan), _MJalan);
                return Ok(_respon);
            }

            _respon = _bantu.BuatResponAPI(_bantu.CodeBadRequest, _bantu.PesanTidakDitemukan(SJalan), null);
            return Ok(_respon);
        }

        //RawatInap
        [Route("inap")]
        public IActionResult Inap()
        {
            _objek = _inapservice.AmbilSemuaInap();

            _respon = _bantu.BuatResponAPI(_bantu.CodeOK, _bantu.PesanGetSukses(SInap), _objek);
            return Ok(_respon);
        }

        [Route("inap")]
        [HttpPost]
        public IActionResult TambahInap(Inap parameternya)
        {
            if (ModelState.IsValid)
            {
                _inapservice.BuatInapBaru(parameternya);

                _respon = _bantu.BuatResponAPI(_bantu.CodeOK, _bantu.PesanTambahSukses(SInap), parameternya);
                return Ok(_respon);
            }
            _respon = _bantu.BuatResponAPI(_bantu.CodeBadRequest, _bantu.PesanInputanSalah(SInap), null);
            return Ok(_respon);
        }

        [Route("inap")]
        [HttpPut]
        public IActionResult UbahInap(Inap parameternya)
        {
            if (ModelState.IsValid)
            {
                _MInap = _inapservice.AmbilInapId(parameternya.Id);
                if (_MInap != null)
                {
                    _inapservice.UbahInap(parameternya);

                    _MInap = _inapservice.AmbilInapId(parameternya.Id);

                    _respon = _bantu.BuatResponAPI(_bantu.CodeOK, _bantu.PesanUbahSukses(SInap), _MInap);
                    return Ok(_respon);
                }

                _respon = _bantu.BuatResponAPI(_bantu.CodeInternalServerError, _bantu.PesanTidakDitemukan(SInap), null);
                return Ok(_respon);
            }

            _respon = _bantu.BuatResponAPI(_bantu.CodeBadRequest, _bantu.PesanInputanSalah(SInap), null);
            return Ok(_respon);
        }

        [Route("inap/{idnya}")]
        [HttpDelete]
        public IActionResult HapusInap(string idnya)
        {
            try
            {
                _MInap = _inapservice.AmbilInapId(idnya);

                if (_MInap != null)
                {
                    _inapservice.HapusInap(idnya);

                    _respon = _bantu.BuatResponAPI(_bantu.CodeOK, _bantu.PesanHapusSukses(SInap), _MInap);
                    return Ok(_respon);
                }
                _respon = _bantu.BuatResponAPI(_bantu.CodeInternalServerError, _bantu.PesanTidakDitemukan(SInap), null);
                return Ok(_respon);
            }
            catch
            {
                _respon = _bantu.BuatResponAPI(_bantu.CodeBadRequest, _bantu.PesanInputanSalah(SInap), null);
                return Ok(_respon);
            }
        }

        [Route("inap/{idnya}")]
        public IActionResult DetailInap(string idnya)
        {
            _MInap = _inapservice.AmbilInapId(idnya);

            if (_MInap != null)
            {
                _respon = _bantu.BuatResponAPI(_bantu.CodeOK, _bantu.PesanGetSukses(SInap), _MInap);
                return Ok(_respon);
            }

            _respon = _bantu.BuatResponAPI(_bantu.CodeBadRequest, _bantu.PesanTidakDitemukan(SInap), null);
            return Ok(_respon);
        }
    }
}