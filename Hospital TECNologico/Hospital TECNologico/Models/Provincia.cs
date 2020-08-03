using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hospital_TECNologico.Models
{
    public class Provincia
    {
        public Provincia()
        {
        }

        [Key]
        public int idprovincia { get; set; }
        public string provincia { get; set; }
    }

    
}
