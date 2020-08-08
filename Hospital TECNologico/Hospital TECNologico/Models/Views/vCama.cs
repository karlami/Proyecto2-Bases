using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Hospital_TECNologico.Models.Views
{
    public class vCama
    {
        public vCama()
        {
        }

        [Key]
        public int numerocama { get; set; }
        public string nombreequipo { get; set; }
        public string nombresalon { get; set; }
        public bool uci { get; set; }
    }
}
