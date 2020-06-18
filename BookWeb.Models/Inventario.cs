using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookWeb.Models
{
    public partial class Inventario
    {
        [Key]
        public int id { get; set; }
        public string Nombre { get; set; }
        public string Nombredescripcion { get; set; }
        public int? Stock { get; set; }
        public double? Precio { get; set; }
        public string Urlimagen { get; set; }

        public int? Idcategoria { get; set; }
        [ForeignKey("Idcategoria")]
        public Categorias categorias { get; set; }

        //public virtual Categorias IdcategoriaNavigation { get; set; }
    }
}
