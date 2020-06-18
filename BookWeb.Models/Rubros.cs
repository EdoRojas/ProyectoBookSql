using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookWeb.Models
{
    public partial class Rubros
    {
        public Rubros()
        {

        }

        [Key]
        public int Idrubros { get; set; }

        [Required(ErrorMessage = "Ingrese nombre rubro")]
        [Display(Name = "Nombre empresa")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese descripcion")]
        [Display(Name = "Descripcion")]
        public string Descripcion { get; set; }

    }
}
