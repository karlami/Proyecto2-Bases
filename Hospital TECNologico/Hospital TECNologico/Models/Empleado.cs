using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hospital_TECNologico.Models
{
    public class Empleado
    {
        public Empleado()
        {
        }

        [Key]
        public int idempleado { get; set; }
        public int cedula { get; set; }
        public string nombre { get; set; }
        public string primerapellido { get; set; }
        public string segundoapellido { get; set; }
        public int telefono { get; set; }
        public DateTime fechanacimiento { get; set; }
        public string contrasena { get; set; }
        public int iddireccion { get; set; }
        public DateTime fechaingreso { get; set; }
        public int idpuesto { get; set; }
    }
}
