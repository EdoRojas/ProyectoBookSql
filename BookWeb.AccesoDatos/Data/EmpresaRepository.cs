using BookWeb.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookWeb.AccesoDatos.Data.Repository
{
    public class EmpresaRepository : Repository<Empresas>, IEmpresaRepository
    {
        private readonly ApplicationDbContext _db;

        public EmpresaRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public IEnumerable<SelectListItem> GetListaEmpresas()
        {
            return _db.empresas.Select(i => new SelectListItem()
            {
                Text = i.Nombre,
                Value = i.idempresa.ToString()
            });
        }

        public void Update(Empresas empresas)
        {
            var objdesdeDb = _db.empresas.FirstOrDefault(s => s.idempresa == empresas.idempresa);
            objdesdeDb.Nombre = empresas.Nombre;
            objdesdeDb.Urlimagen = empresas.Urlimagen;
            objdesdeDb.Idrubro = empresas.Idrubro;
            _db.SaveChanges();
        }
    }
}
