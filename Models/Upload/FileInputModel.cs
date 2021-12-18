using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RentalKendaraan_101.Models.Upload
{
    public class FileInputModel : Controller
    {
        public IFormFile FileToUpload { get; set; }
    }
}
