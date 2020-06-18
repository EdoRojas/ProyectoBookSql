using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookWeb.Models
{
    public class Categorias
    {

        public Categorias()
        {
            //Inventario = new HashSet<Inventario>();
            //InverseIdpadreNavigation = new HashSet<Categorias>();
        }

        [Key]
        public int Idcategorias { get; set; }

        [Required(ErrorMessage = "Ingrese nombre categoria")]
        [Display(Name = "Nombre Categoria")]
        public string Nombre { get; set; }

        public int? Idpadre { get; set; }
        [ForeignKey("Idpadre")]

        public Categorias categorias { get; set; }

    }
}
