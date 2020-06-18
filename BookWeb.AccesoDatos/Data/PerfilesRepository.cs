using BookWeb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookWeb.AccesoDatos.Data.Repository
{
    public class PerfilesRepository : Repository<Perfiles>, IPerfilesRepository
    {
        private readonly ApplicationDbContext _db;

        public PerfilesRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public IEnumerable<SelectListItem> GetListaPerfiles()
        {
            return _db.perfiles.Select(i => new SelectListItem()
            {
                Text = i.Nombre,
                Value = i.Idperfil.ToString()
            });
        }

        public void Update(Perfiles perfiles)
        {
            var objdesdeDb = _db.perfiles.FirstOrDefault(s => s.Idperfil == perfiles.Idperfil);
            objdesdeDb.Nombre = perfiles.Nombre;
            _db.SaveChanges();
        }




    }
}
