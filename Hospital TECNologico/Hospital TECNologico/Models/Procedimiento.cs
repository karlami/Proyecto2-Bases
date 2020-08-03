using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
        public string diasrecuperacion { get; set; }
    }
}
