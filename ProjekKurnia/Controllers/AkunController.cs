﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia.Controllers
{
    public class AkunController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
