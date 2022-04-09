using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia.Services
{
    public class FileService
    {
        IWebHostEnvironment _alat;
        public FileService(IWebHostEnvironment e)
        {
            _alat = e;
        }

        public async Task<string> SimpanFile(IFormFile filenya)
        {
            string namaFolder = "namaFoldernya";

            if (filenya == null)
            {
                return string.Empty;
            }

            var savepath = Path.Combine(_alat.WebRootPath, namaFolder);

            if (!Directory.Exists(savepath))
            {
                Directory.CreateDirectory(savepath);
            }

            var namaFilenya = filenya.FileName;
            var alamatFilenya = Path.Combine(savepath, namaFilenya);

            using (var stream = new FileStream(alamatFilenya, FileMode.Create))
            {
                await filenya.CopyToAsync(stream);
            }

            return Path.Combine("/" + namaFolder + "/", namaFilenya);
        }
    }
}
