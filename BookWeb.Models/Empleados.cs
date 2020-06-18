using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookWeb.Models
{
    public partial class Empleados
    {
        [Key]
        public int Idempleados { get; set; }
        public string Nombre { get; set; }
        public string Apa { get; set; }
        public string Ama { get; set; }

        public int? Idperfiles { get; set; }
        [ForeignKey("Idperfiles")]
        public Perfiles perfiles { get; set; }

    }
}
