using BookWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookWeb.AccesoDatos.Data.Repository
{
    public class EmpleadoRepository : Repository<Empleados>, IEmpleadoRepository
    {
        private readonly ApplicationDbContext _db;

        public EmpleadoRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Empleados empleados)
        {

            var objdesdeDb = _db.empleados.FirstOrDefault(s => s.Idempleados == empleados.Idempleados);
            objdesdeDb.Nombre = empleados.Nombre;
            objdesdeDb.Apa = empleados.Apa;
            objdesdeDb.Ama = empleados.Ama;
            objdesdeDb.Idperfiles = empleados.Idperfiles;
            _db.SaveChanges();

        }
    }
}
