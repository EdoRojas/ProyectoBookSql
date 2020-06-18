using BookWeb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookWeb.AccesoDatos.Data.Repository
{
    public interface IRubroRepository : IRepository<Rubros>
    {
        //Meotodo lista empresas
        IEnumerable<SelectListItem> GetListaRubros();

        //Metodo actualizar
        void Update(Rubros rubros);

    }
}
