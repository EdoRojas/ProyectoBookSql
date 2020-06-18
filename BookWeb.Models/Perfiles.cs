using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookWeb.Models
{
    public partial class Perfiles
    {

        [Key]
        public int Idperfil { get; set; }
        public string Nombre { get; set; }


    }
}
