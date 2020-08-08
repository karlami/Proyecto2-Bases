using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hospital_TECNologico.Models.Views
{
    public class vSalon
    {
        public vSalon()
        {
        }

        [Key]
        public int numerosalon { get; set; }
        public string nombre { get; set; }
        public int cantidadcama { get; set; }
        public int numeropiso { get; set; }
        public string tipo { get; set; }
    }
}
