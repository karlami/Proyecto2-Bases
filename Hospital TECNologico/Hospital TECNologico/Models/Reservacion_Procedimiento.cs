using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hospital_TECNologico.Models
{
    public class Reservacion_Procedimiento
    {
        public Reservacion_Procedimiento()
        {
        }

        [Key]
        public int idreservacionprocedimiento { get; set; } //AGREGAR A BASE DE DATOS ??
        public int idreservacion { get; set; }
        public int idprocedimiento { get; set; }       
    }
}
