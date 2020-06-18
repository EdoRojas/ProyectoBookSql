using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookWeb.Models.ViewModels
{
    public class EmpleadoVM
    {
        public Empleados Empleados { get; set; }
        public IEnumerable<SelectListItem> ListaPerfiles { get; set; }
    }
}
