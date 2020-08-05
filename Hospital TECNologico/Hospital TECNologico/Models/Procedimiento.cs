﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hospital_TECNologico.Models
{
    public class Procedimiento
    {
        public Procedimiento()
        {
        }

        [Key]
        public int idprocedimiento { get; set; }
        public string nombre { get; set; }
        public int diasrecuperacion { get; set; }
    }
}