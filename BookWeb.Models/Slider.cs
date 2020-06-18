using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookWeb.Models
{
    public partial class Slider
    {
        [Key]
        public int Idslider { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
        public string Urlimagen { get; set; }

    }
}
