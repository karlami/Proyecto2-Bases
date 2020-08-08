using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hospital_TECNologico.Models.Views
{
    public class vEmpleado
    {
        public vEmpleado()
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
        public string direccion { get; set; }
        public int iddireccion { get; set; }
        public DateTime fechaingreso { get; set; }
        public int idpuesto { get; set; }
        public string nombrepuesto { get; set; }
    }
}
