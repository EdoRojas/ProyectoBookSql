using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookWeb.Models.ViewModels
{
    public class InventarioVM
    {
        public Inventario Inventario { get; set; }
        public IEnumerable<SelectListItem> ListaCategorias { get; set; }

    }
}
