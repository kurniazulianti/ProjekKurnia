﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjekKurnia.Models
{
    public class Roles
    {
        [Key]
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
