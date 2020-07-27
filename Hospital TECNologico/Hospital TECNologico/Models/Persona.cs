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
        public string cedula { get; set; }
        public string nombre { get; set; }
        public string primerApellido { get; set; }
        public string segundoApellido { get; set; }
        public string telefono { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public int idDireccion { get; set; }
    }
}
