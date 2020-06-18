using BookWeb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookWeb.AccesoDatos.Data.Repository
{
    public interface IEmpresaRepository : IRepository<Empresas>
    {
        //Meotodo lista empresas
        IEnumerable<SelectListItem> GetListaEmpresas();

        //Metodo actualizar
        void Update(Empresas empresas);

    }
}
