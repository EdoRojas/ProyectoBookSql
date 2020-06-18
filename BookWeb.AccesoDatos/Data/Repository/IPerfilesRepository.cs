using BookWeb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookWeb.AccesoDatos.Data.Repository
{
    public interface IPerfilesRepository : IRepository<Perfiles>
    {
        IEnumerable<SelectListItem> GetListaPerfiles();

        void Update(Perfiles perfiles);
    }
}
