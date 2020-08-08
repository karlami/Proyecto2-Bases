using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hospital_TECNologico.Models.Views
{
    public class vReservacion_Procedimiento
    {
        public vReservacion_Procedimiento()
        {
        }

        [Key]
        public int idreservacion_procedimiento { get; set; }
        public int idreservacion { get; set; }
        public int idprocedimiento { get; set; }
        public string nombre { get; set; }
        public int diasrecuperacion { get; set; }
    }
}
