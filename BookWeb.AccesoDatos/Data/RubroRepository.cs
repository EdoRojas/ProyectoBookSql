using BookWeb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookWeb.AccesoDatos.Data.Repository
{
    public class RubroRepository : Repository<Rubros>, IRubroRepository
    {
        private readonly ApplicationDbContext _db;

        public RubroRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }



        public IEnumerable<SelectListItem> GetListaRubros()
        {
            return _db.rubros.Select(i => new SelectListItem()
            {
                Text = i.Nombre,
                Value = i.Idrubros.ToString()
            });
        }

        public void Update(Rubros rubros)
        {
            var objdesdeDb = _db.rubros.FirstOrDefault(s => s.Idrubros == rubros.Idrubros);
            objdesdeDb.Nombre = rubros.Nombre;
            objdesdeDb.Descripcion = rubros.Descripcion;
            _db.SaveChanges();
        }
    }
}
