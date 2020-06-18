using BookWeb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookWeb.AccesoDatos.Data.Repository
{
    public interface ICategoriaRepository : IRepository<Categorias>
    {
        //Meotodo lista inventario
        IEnumerable<SelectListItem> GetListaCategorias();

        //Metodo actualizar
        void Update(Categorias categorias);

    }
}
