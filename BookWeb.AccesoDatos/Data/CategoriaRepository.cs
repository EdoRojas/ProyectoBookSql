using BookWeb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookWeb.AccesoDatos.Data.Repository
{
    public class CategoriaRepository : Repository<Categorias>, ICategoriaRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoriaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetListaCategorias()
        {
            return _db.Categorias.Select(i => new SelectListItem()
            {
                Text = i.Nombre,
                Value = i.Idcategorias.ToString()
            });
        }

        public void Update(Categorias categorias)
        {
            var objdesdeDb = _db.Categorias.FirstOrDefault(s => s.Idcategorias == categorias.Idcategorias);
            objdesdeDb.Nombre = categorias.Nombre;
            objdesdeDb.Idpadre = categorias.Idpadre;
            _db.SaveChanges();
        }
    }
}
