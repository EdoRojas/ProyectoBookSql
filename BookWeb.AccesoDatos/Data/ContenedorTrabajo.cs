using System;
using System.Collections.Generic;
using System.Text;

namespace BookWeb.AccesoDatos.Data.Repository
{
    public class ContenedorTrabajo : IContenedorTrabajo
    {
        private readonly ApplicationDbContext _db;

        public ContenedorTrabajo(ApplicationDbContext db)
        {
            _db = db;
            Inventario = new InventarioRepository(_db);
            Categoria = new CategoriaRepository(_db);
            Slider = new SliderRepository(_db);
            Perfiles = new PerfilesRepository(_db);
            Empleado = new EmpleadoRepository(_db);
            Empresa = new EmpresaRepository(_db);
            Rubro = new RubroRepository(_db);
        }

        public IInventarioRepository Inventario { get; private set; }
        public ICategoriaRepository Categoria { get; private set; }
        public ISliderRepository Slider { get; private set; }
        public IPerfilesRepository Perfiles { get; private set; }
        public IEmpleadoRepository Empleado { get; private set; }
        public IUsuarioRepository Usuario { get; private set; }
        public IEmpresaRepository Empresa { get; private set; }
        public IRubroRepository Rubro { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
