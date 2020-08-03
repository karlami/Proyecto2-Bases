using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hospital_TECNologico.Models
{
    public class Equipo
    {
        public Equipo()
        {
        }

        [Key]
        public int idequipo { get; set; }
        public string nombre { get; set; }
        public string proveedor { get; set; }
        public int cantidad { get; set; }

    }
}
