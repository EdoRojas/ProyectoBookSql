using BookWeb.AccesoDatos.Data.Repository;
using BookWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookWeb.AccesoDatos.Data
{
    public class UsuarioRepository : Repository<ApplicationUser>, IUsuarioRepository
    {
        private readonly ApplicationDbContext _db;

        public UsuarioRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void BloqueaUsuario(string IdUsuario)
        {
            var usarioDesdeDb = _db.ApplicationUser.FirstOrDefault(u => u.Id == IdUsuario);
            usarioDesdeDb.LockoutEnd = DateTime.Now.AddYears(100);
            _db.SaveChanges();
        }

        public void DesbloquearUsuario(string IdUsuario)
        {
            var usarioDesdeDb = _db.ApplicationUser.FirstOrDefault(u => u.Id == IdUsuario);
            usarioDesdeDb.LockoutEnd = DateTime.Now;
            _db.SaveChanges();
        }
    }
}
