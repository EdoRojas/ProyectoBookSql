using BookWeb.AccesoDatos.Data.Repository;
using BookWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookWeb.AccesoDatos.Data.Repository
{
    public class InventarioRepository : Repository<Inventario>, IInventarioRepository
    {
        private readonly ApplicationDbContext _db;

        public InventarioRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        //public IEnumerable<SelectListItem> GetListaInventario()
        //{
        //    return _db.Inventario.Select(i => new SelectListItem()
        //    {
        //        Text = i.Nombre,
        //        Value = i.id.ToString()
        //    });
        //}

        public void Update(Inventario inventario)
        {
            var objdesdeDb = _db.Inventario.FirstOrDefault(s => s.id == inventario.id);
            objdesdeDb.Nombre = inventario.Nombre;
            objdesdeDb.Nombredescripcion = inventario.Nombredescripcion;
            objdesdeDb.Stock = inventario.Stock;
            objdesdeDb.Precio = inventario.Precio;
            objdesdeDb.Idcategoria = inventario.Idcategoria;
            objdesdeDb.Urlimagen = inventario.Urlimagen;
            _db.SaveChanges();
        }
    }
}
