using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookWeb.Models
{
    public partial class Empresas
    {
        public Empresas()
        {

        }

        [Key]
        public int idempresa { get; set; }

        [Required(ErrorMessage = "Ingrese nombre empresa")]
        [Display(Name = "Nombre empresa")]
        public string Nombre { get; set; }

        //[Required(ErrorMessage = "Seleccione imagen")]
        [Display(Name = "URL Imagen")]
        public string Urlimagen { get; set; }

        public int? Idrubro { get; set; }
        [ForeignKey("Idrubro")]
        public Rubros rubros { get; set; }


    }
}
