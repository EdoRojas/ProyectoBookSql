using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookWeb.Models.ViewModels
{
    public class EmpresaVM
    {

        public Empresas Empresas { get; set; }
        public IEnumerable<SelectListItem> ListaRubros { get; set; }

    }
}
