using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hospital_TECNologico.Models
{
    public class Persona
    {
        public Persona()
        {
        }

        [Key]
        public int cedula { get; set; }
        public string nombre { get; set; }
        public string primerapellido { get; set; }
        public string segundoapellido { get; set; }
        public int telefono { get; set; }
        public DateTime fechanacimiento { get; set; }
        public string contrasena { get; set; }
        public int iddireccion { get; set; }
    }
}
