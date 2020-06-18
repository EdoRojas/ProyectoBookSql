using System;
using System.Collections.Generic;
using System.Text;

namespace BookWeb.Models.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Slider> Slider { get; set; }
        public IEnumerable<Inventario> ListaInventarios { get; set; }
    }
}
