using BookWeb.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookWeb.AccesoDatos.Data.Repository
{
    public interface IInventarioRepository : IRepository<Inventario>
    {
        //Meotodo lista inventario
        //IEnumerable<SelectListItem> GetListaInventario();

        //Metodo actualizar
        void Update(Inventario inventario);

    }
}
