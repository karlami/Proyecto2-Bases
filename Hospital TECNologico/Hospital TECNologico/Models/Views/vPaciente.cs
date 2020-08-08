using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hospital_TECNologico.Models.Views
{
    public class vPaciente
    {
        public vPaciente()
        {
        }

        [Key]
        public int idpaciente { get; set; }
        public int cedula { get; set; }
        public string nombrepaciente { get; set; }
        public int telefono { get; set; }
        public string direccion { get; set; }
        public DateTime fechanacimiento { get; set; }
        public string contrasena { get; set; }
        public string patologia { get; set; } 
        public string tratamiento { get; set; }
    }
}
